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
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
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


            List<UnidadMedida> lista = new UnidadMedida_N().listar();

            foreach (UnidadMedida item in lista)
            {
                cmbUnidad.Items.Add(new CargarCombos() { Valor = item.Id_Unidad, Texto = item.Nombre });

            }
            cmbUnidad.DisplayMember = "Texto";
            cmbUnidad.ValueMember = "Valor";
            cmbUnidad.SelectedIndex = -1;

            List<Presentacion> listar = new Presentacion_N().listar();

            foreach (Presentacion obj in listar)
            {
                dgvData.Rows.Add(new object[] {
                "",
                obj.Id_Presentacion,
                obj.Nombre,
                obj.Cantidad,
                obj.oUnidadMedida.Id_Unidad,
                obj.oUnidadMedida.Nombre,
                obj.FactorUnidad

                });
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string mensaje = string.Empty;

            if (cmbUnidad.SelectedIndex == -1)
            {

                MessageBox.Show("Debe seleccionar una Unidad específica");

            }
            else
            {


          

                Presentacion obj = new Presentacion()
                {
                    Id_Presentacion = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Cantidad = Convert.ToDecimal(txtCantidad.Text),
                    oUnidadMedida = new UnidadMedida() { Id_Unidad = Convert.ToInt32(((CargarCombos)cmbUnidad.SelectedItem).Valor) },
                    FactorUnidad = txtFactorU.Text,
                };

            if (obj.Id_Presentacion == 0)
            {
                int Id_Generado = new Presentacion_N().Registrar(obj, out mensaje);

                if (Id_Generado != 0)
                {
                    dgvData.Rows.Add(new object[] {
                "",
                Id_Generado,
                txtNombre.Text,
                txtCantidad.Text,
                ((CargarCombos)cmbUnidad.SelectedItem).Valor.ToString(),
                ((CargarCombos)cmbUnidad.SelectedItem).Texto.ToString(),
                txtFactorU.Text,
            });

                    MessageBox.Show("Presentación agregada con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new Presentacion_N().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Cantidad"].Value = txtCantidad.Text;
                    row.Cells["Id_Unidad"].Value = ((CargarCombos)cmbUnidad.SelectedItem).Valor.ToString();
                    row.Cells["Unidad"].Value = ((CargarCombos)cmbUnidad.SelectedItem).Texto.ToString();
                    row.Cells["FactorUnidad"].Value = FactorU;

                    MessageBox.Show("Se ha editado la Presentación");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
             }
         }
        }



        private void LimpiarCampos()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtIndice.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "1";
            cmbUnidad.SelectedIndex = -1;
            txtFactorU.Text = "";
            txtNombre.Select();

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
                    txtCantidad.Text = dgvData.Rows[index].Cells["Cantidad"].Value.ToString();
                    txtFactorU.Text = dgvData.Rows[index].Cells["FactorU"].Value.ToString();



                    foreach (CargarCombos cc in cmbUnidad.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Unidad"].Value))
                        {
                            int indice = cmbUnidad.Items.IndexOf(cc);
                            cmbUnidad.SelectedIndex = indice;
                            break;

                        }

                    }

                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente la Presentación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Presentacion obj = new Presentacion()
                    {

                        Id_Presentacion = Convert.ToInt32(txtId.Text)

                    };

                    bool respuesta = new Presentacion_N().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {

                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Presentación elimidada con éxito");
                        LimpiarCampos();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar la Presentación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }


            }
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

        private void btnAgregarUnidades_Click(object sender, EventArgs e)
        {
            frmUnidadMedida frmUnidadMedida = new frmUnidadMedida();
            frmUnidadMedida.Show();
        }
    }
}
