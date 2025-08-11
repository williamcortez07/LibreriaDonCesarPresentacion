using CapaEntidad;
using CapaNegocios;
using ClosedXML.Excel;
using LibreriaDonCesarPresentacion.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmBajaInventario : Form
    {
        public frmBajaInventario()
        {
            InitializeComponent();
        }

        private void frmBajaInventario_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

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

            List<BajaInventario> listar = new Baja_N().listar();

            foreach (BajaInventario baja in listar)
            {
                dgvData.Rows.Add(new object[] { "", baja.Id_Baja, baja.Cantidad,baja.Motivo, baja.Fecha, baja.oProducto.Id_Producto, baja.oProducto.oArticulo.Nombre});

            }

            List<Producto> producto = new Producto_N().listar();

            foreach (Producto item in producto)
            {
                cmbProducto.Items.Add(new CargarCombos() { Valor = item.Id_Producto, Texto = item.oArticulo.Nombre});
            }
            cmbProducto.DisplayMember = "Texto";
            cmbProducto.ValueMember = "Valor";
            cmbProducto.SelectedIndex = -1;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string mensaje = string.Empty;

            BajaInventario obj = new BajaInventario()
            {
                Id_Baja = Convert.ToInt32(txtId.Text),
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                Motivo = txtMotivo.Text,
                oProducto = new Producto() { Id_Producto = Convert.ToInt32(((CargarCombos)cmbProducto.SelectedItem).Valor) },

            };

            if (obj.Id_Baja == 0)

            {
                int Id_Generado = new Baja_N().Registrar(obj, out mensaje);

                if (Id_Generado != 0)
                {
                    dgvData.Rows.Add(new object[] {
                        "", 
                        Id_Generado,
                        txtCantidad.Text,
                        txtMotivo.Text,
                        txtFecha.Text,
                        ((CargarCombos)cmbProducto.SelectedItem).Valor.ToString(),
                        ((CargarCombos)cmbProducto.SelectedItem).Texto.ToString(),
});
                    MessageBox.Show("Baja agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }

            else
            {
                bool resultado = new Baja_N().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Cantidad"].Value = txtCantidad.Text;
                    row.Cells["Fecha"].Value = txtFecha.Text;
                    row.Cells["Id_Producto"].Value = ((CargarCombos)cmbProducto.SelectedItem).Valor.ToString();
                    row.Cells["Producto"].Value = ((CargarCombos)cmbProducto.SelectedItem).Texto.ToString();
                    MessageBox.Show("Se ha editado a la baja");
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
            txtId.Text = "0";
            txtIndice.Text = "-1";
            txtCantidad.Value = 1;
            txtMotivo.Text = "";
            cmbProducto.SelectedIndex = -1;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente la baja?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    BajaInventario obj = new BajaInventario()
                    {

                        Id_Baja = Convert.ToInt32(txtId.Text)

                    };

                    bool respuesta = new Baja_N().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {

                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Baja elimidada con éxito");
                        LimpiarCampos();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar la Baja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }


            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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
                    txtCantidad.Text = dgvData.Rows[index].Cells["Cantidad"].Value.ToString();
                    txtMotivo.Text = dgvData.Rows[index].Cells["Motivo"].Value.ToString();
                    txtFecha.Text = dgvData.Rows[index].Cells["Fecha"].Value.ToString();
                    foreach (CargarCombos cc in cmbProducto.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Producto"].Value))
                        {
                            int indice = cmbProducto.Items.IndexOf(cc);
                            cmbProducto.SelectedIndex = indice;
                            break;

                        }

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

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para Descargar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));




                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                        row.Cells[2].Value.ToString(),
                         row.Cells[3].Value.ToString(),
                          row.Cells[4].Value.ToString(),
                           row.Cells[6].Value.ToString(),

                        });


                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = string.Format("Reportes Bajas_{0}", DateTime.Now.ToString("ddMMyyyyHHmmSS"));
                saveFileDialog.Filter = "Excel Files | *.Xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        XLWorkbook xLWorkbook = new XLWorkbook();
                        var hoja = xLWorkbook.AddWorksheet(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        xLWorkbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Reporte generado con éxito");

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ha ocurrido un error al descargar el reporte");
                    }


                }

            

            }
        }
    }
}
