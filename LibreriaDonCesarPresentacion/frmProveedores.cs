using CapaEntidad;
using CapaNegocios;
using LibreriaDonCesarPresentacion.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvProveedor.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {

                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;


            List<Proveedor> listarProvvedores = new Proveedor_N().listar();

            foreach (Proveedor proveedor in listarProvvedores)
            {
                dgvProveedor.Rows.Add(new object[] { "", proveedor.Id_Proveedor, proveedor.Nombre, proveedor.Apellido, proveedor.Telefono, proveedor.Correo });

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Proveedor proveedores = new Proveedor()
            {
                Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
            };

            if (proveedores.Id_Proveedor == 0)

            {
                int Id_ProveedorGenerado = new Proveedor_N().Registrar(proveedores, out mensaje);

                if (Id_ProveedorGenerado != 0)
                {
                    dgvProveedor.Rows.Add(new object[] { "", Id_ProveedorGenerado, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCorreo.Text});
                    MessageBox.Show("Proveedor agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }


            }

            else
            {
                bool resultado = new Proveedor_N().Editar(proveedores, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvProveedor.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id_Proveedor"].Value = txtId_Proveedor.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Apellido"].Value = txtApellido.Text;
                    row.Cells["Telefono"].Value = txtApellido.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    MessageBox.Show("Se ha editado al Proveedor");
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
            txtId_Proveedor.Text = "0";
            txtIndice.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = ""; 
        }

        private void dgvProveedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.circlecheck.Width;
                var h = Properties.Resources.circlecheck.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.circlecheck, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedor.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice.Text = index.ToString();
                    txtId_Proveedor.Text = dgvProveedor.Rows[index].Cells["Id_Proveedor"].Value.ToString();
                    txtNombre.Text = dgvProveedor.Rows[index].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = dgvProveedor.Rows[index].Cells["Apellido"].Value.ToString();
                    txtTelefono.Text = dgvProveedor.Rows[index].Cells["Telefono"].Value.ToString();
                    txtCorreo.Text = dgvProveedor.Rows[index].Cells["Correo"].Value.ToString();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Proveedor.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente el Proveedor?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Proveedor proveedores = new Proveedor()
                    {

                        Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text)

                    };

                    bool respuesta = new Proveedor_N().Eliminar(proveedores, out mensaje);

                    if (respuesta)
                    {

                        dgvProveedor.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Proveedor elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar al Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            if (dgvProveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedor.Rows)
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

            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                row.Visible = true;

            }
        }
    }   
}
