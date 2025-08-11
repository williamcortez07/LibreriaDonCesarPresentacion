using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibreriaDonCesarPresentacion.Complementos;
using CapaEntidad;
using CapaNegocios;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {


            foreach (DataGridViewColumn columna in dgvUsuarios.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "Clave" )
                {

                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name , Texto = columna.HeaderText});

                }

            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;


            List<Usuario> listarUsuarios = new Usuario_N().listar();

            foreach (Usuario usuario in listarUsuarios)
            {
                dgvUsuarios.Rows.Add(new object[] { "", usuario.Id_Usuario, usuario.Nombre, usuario.Clave, usuario.Rol });

            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario usuarios = new Usuario()
            {
                Id_Usuario = Convert.ToInt32(txtId_Usuario.Text),
                Nombre = txtNombre.Text,
                Clave = txtClave.Text,
                Rol = txtRol.Text
            };

            if (usuarios.Id_Usuario == 0)

            {
                int Id_UsuarioGenerado = new Usuario_N().Registrar(usuarios, out mensaje);

                if (Id_UsuarioGenerado != 0)
                {
                    dgvUsuarios.Rows.Add(new object[] { "",Id_UsuarioGenerado, txtNombre.Text, txtClave.Text, txtRol.Text });
                    MessageBox.Show("Usuario agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }

            else
            {
                bool resultado = new Usuario_N().Editar(usuarios, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvUsuarios.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id_Usuario"].Value = txtId_Usuario.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Rol"].Value = txtRol.Text;
                    MessageBox.Show("Se ha editado al Usuario");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }                                              
        }

        private void LimpiarCampos()
        {
            txtIndice.Text = "-1";
            txtId_Usuario.Text = "0";
            txtIndice.Text = "";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtRol.Text = "";
        }

        private void dgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)   return; 

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.circlecheck.Width;
                var h = Properties.Resources.circlecheck.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height- h) / 2;

                e.Graphics.DrawImage(Properties.Resources.circlecheck, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice.Text = index.ToString();
                    txtId_Usuario.Text = dgvUsuarios.Rows[index].Cells["Id_Usuario"].Value.ToString();
                    txtNombre.Text = dgvUsuarios.Rows[index].Cells["Nombre"].Value.ToString();
                    txtClave.Text = dgvUsuarios.Rows[index].Cells["Clave"].Value.ToString();
                    txtRol.Text = dgvUsuarios.Rows[index].Cells["Rol"].Value.ToString();

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Usuario.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente el usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Usuario usuarios = new Usuario()
                    {
                                                            
                        Id_Usuario = Convert.ToInt32(txtId_Usuario.Text)

                    };

                    bool respuesta = new Usuario_N().Eliminar(usuarios, out mensaje);

                    if (respuesta)
                    {

                        dgvUsuarios.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Usuario elimidado con éxito");
                        LimpiarCampos(); 
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar al usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
               

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtrarColumna = ((CargarCombos)cmbbusquedaFiltro.SelectedItem).Valor.ToString();
            if (dgvUsuarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUsuarios.Rows)
                {
                    if (row.Cells[filtrarColumna].Value.ToString().Trim().ToUpper().Contains(txtescrituraFiltro.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }

                }
            }

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtescrituraFiltro.Text = "";

            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                row.Visible = true;

            }

        }

        private void cmbbusquedaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
