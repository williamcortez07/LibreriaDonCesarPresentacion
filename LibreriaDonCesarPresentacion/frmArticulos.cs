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
    public partial class frmArticulos : Form
    {
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
             foreach (DataGridViewColumn columna in dgvArticulo.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "Clave")
                {

                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;



            List<Articulo> listarArticulos = new Articulo_N().listar();

            foreach (Articulo articulo in listarArticulos)
            {
                dgvArticulo.Rows.Add(new object[] { "", articulo.Id_Articulo, articulo.Nombre});
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Articulo articulo = new Articulo()
            {
                Id_Articulo = Convert.ToInt32(txtId_Articulo.Text),
                Nombre = txtNombre.Text
            };

            if (articulo.Id_Articulo == 0)
            {
                int Id_ArticuloGenerado = new Articulo_N().Registrar(articulo, out mensaje);

                if (Id_ArticuloGenerado != 0)
                {
                    dgvArticulo.Rows.Add(new object[] { "", Id_ArticuloGenerado, txtNombre.Text });
                    MessageBox.Show("Artículo agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new Articulo_N().Editar(articulo, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvArticulo.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id_Articulo"].Value = txtId_Articulo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text; 
                    MessageBox.Show("Se ha editado el artículo");
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
            txtId_Articulo.Text = "0";
            txtNombre.Text = "";
            
        }

        private void dgvArticulo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticulo.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice.Text = index.ToString();
                    txtId_Articulo.Text = dgvArticulo.Rows[index].Cells["Id_Articulo"].Value.ToString();
                    txtNombre.Text = dgvArticulo.Rows[index].Cells["Nombre"].Value.ToString();      
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Articulo.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente el artículo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Articulo articulo = new Articulo()
                    {
                        Id_Articulo = Convert.ToInt32(txtId_Articulo.Text)
                    };

                    bool respuesta = new Articulo_N().Eliminar(articulo, out mensaje);

                    if (respuesta)
                    {
                        dgvArticulo.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Articulo elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                       MessageBox.Show("No se pudo eliminar al Articulo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dgvArticulo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvArticulo.Rows)
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

            foreach (DataGridViewRow row in dgvArticulo.Rows)
            {
                row.Visible = true;

            }
        }
    }
}
