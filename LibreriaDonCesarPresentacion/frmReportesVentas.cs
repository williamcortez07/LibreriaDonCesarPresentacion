using CapaEntidad;
using CapaNegocios;
using ClosedXML.Excel;
using LibreriaDonCesarPresentacion.Complementos;
using LibreriaDonCesarPresentacion.Modales;
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
    public partial class frmReportesVentas : Form
    {
        public frmReportesVentas()
        {
            InitializeComponent();
        }

        private void frmReportesVentas_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {

                    cmbfiltrar.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbfiltrar.DisplayMember = "Texto";
            cmbfiltrar.ValueMember = "Valor";
            cmbfiltrar.SelectedIndex = -1;



        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            string formatoFecha = "dd/MM/yyyy";

            //int Id_Proveedor = Convert.ToInt32(((CargarCombos)cmbproveedor.SelectedItem).Valor.ToString());
            List<ReportesVenta> lista = new List<ReportesVenta>();

            lista = new Reportes_N().venta(
                dtfechainicio.Value.ToString(formatoFecha),
                dtfechafin.Value.ToString(formatoFecha)
              
                );



            dgvData.Rows.Clear();
            foreach (ReportesVenta rp in lista)
            {
                dgvData.Rows.Add(new object[]
                {
                   rp.fecha,
                   rp.NumVenta,
                   rp.Total,
                   rp.Usuario,
                   rp.NomProducto,
                   rp.PrecioC,
                   rp.PrecioV,
                   rp.Cantidad,
                   rp.SubTotal,
                   rp.nomSubCategoria,
                   rp.nomColor,
                   rp.nomMarca,
                });


            }
        }

        private void btnbuscarfiltros_Click(object sender, EventArgs e)
        {

            string filtrarColumna = ((CargarCombos)cmbfiltrar.SelectedItem).Valor.ToString();
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

        private void btnlimpiar_Click(object sender, EventArgs e)
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
                MessageBox.Show("No se encontró datos para la descarga", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    if (columna.HeaderText != "")
                        dt.Columns.Add(columna.HeaderText, typeof(string));




                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                        row.Cells[0].Value.ToString(),
                         row.Cells[1].Value.ToString(),
                          row.Cells[2].Value.ToString(),
                           row.Cells[3].Value.ToString(),
                           row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),

                        });


                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = string.Format("Reportes Ventas_{0}", DateTime.Now.ToString("ddMMyyyyHHmmSS"));
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
