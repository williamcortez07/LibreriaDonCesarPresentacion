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
    public partial class frmUnidadMedida : Form
    {
        public frmUnidadMedida()
        {
            InitializeComponent();
        }

            private void frmUnidadMedida_Load(object sender, EventArgs e)
            {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;

            List<UnidadMedida> listar = new UnidadMedida_N().listar();

            foreach (UnidadMedida Unidad in listar)
            {
                dgvData.Rows.Add(new object[] { "", Unidad.Id_Unidad, Unidad.Nombre });
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            UnidadMedida obj = new UnidadMedida()
            {
                Id_Unidad = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text
            };

            if (obj.Id_Unidad == 0)
            {
                int Id_Generado = new UnidadMedida_N().Registrar(obj, out mensaje);

                if (Id_Generado != 0)
                {
                    dgvData.Rows.Add(new object[] { "", Id_Generado, txtNombre.Text });
                    MessageBox.Show("Unidad agregada con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new UnidadMedida_N().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id_Unidad"].Value = txtId.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    MessageBox.Show("Se ha editado la Unidad");
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
            txtId.Text = "0";
            txtNombre.Text = "";
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice.Text = index.ToString();
                    txtId.Text = dgvData.Rows[index].Cells["Id"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[index].Cells["Nombre"].Value.ToString();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente la Unidad?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    UnidadMedida obj = new UnidadMedida()
                    {
                        Id_Unidad = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new UnidadMedida_N().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Unidad elimidada con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Unidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
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

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;

            }
        }
    }
}
