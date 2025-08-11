using CapaEntidad;
using CapaNegocios;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Venta obj = new Ventas_N().obtenerVenta(txtNumVenta.Text);
            if (obj.Id_Venta != 0)
            {
                txtcodigoVenta.Text = obj.NumVenta;
                txtFecha.Text = obj.Fecha;
                txtUsuario.Text = obj.oUsuario.Nombre;


                dgvData.Rows.Clear();

                foreach (DetalleVenta dv in obj.oDetalleVenta)
                {
                    dgvData.Rows.Add(new object[] { dv.oProducto.oArticulo.Nombre,   dv.Cantidad, dv.PrecioUnitario, dv.SubTotal });
                }

                txtTotal.Text = obj.Total.ToString("0.00");
                txtDescuento.Text = obj.Descuento.ToString("0.00");


            }
            else
            {

                MessageBox.Show("Error, No se encontró resultados para su búsqueda");
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtNumVenta.Text = "";
            txtcodigoVenta.Text = "";
            txtTotal.Text = "0.00";
            txtUsuario.Text = "";
            txtDescuento.Text = "0";
            dgvData.Rows.Clear();

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            {
                if (txtNumVenta.Text == "")
                {
                    MessageBox.Show("No hay datos para descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                string Texto_Html = Properties.Resources.plantillaVentas.ToString();

                Negocio oDatos = new Negocio_N().ObtenerDatos();
                Texto_Html = Texto_Html.Replace("@nombre", oDatos.Nombre.ToUpper());
                Texto_Html = Texto_Html.Replace("@RUC", oDatos.RUC);
                Texto_Html = Texto_Html.Replace("@Direccion", oDatos.Direccion);

                Texto_Html = Texto_Html.Replace("@NumVenta", txtNumVenta.Text);

                Texto_Html = Texto_Html.Replace("@Fecha", txtFecha.Text);

                Texto_Html = Texto_Html.Replace("@Usuario", txtUsuario.Text);


                string filas = string.Empty;

                foreach (DataGridViewRow row in dgvData.Rows)
                {

                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                    filas += "</tr>";




                }
                Texto_Html = Texto_Html.Replace("filas", filas);
                Texto_Html = Texto_Html.Replace("@Descuento", txtDescuento.Text);
                Texto_Html = Texto_Html.Replace("@Total", txtTotal.Text);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = string.Format("Venta_{0}.pdf", txtNumVenta.Text);
                saveFileDialog.Filter = "pdf Files | *.pdf";


                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream streem = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document Pdf = new Document(PageSize.A4, 25, 25, 100, 25);
                        PdfWriter writer = PdfWriter.GetInstance(Pdf, streem);
                        Pdf.Open();

                        bool obtenido = true;
                        byte[] imagen = new Negocio_N().obtenerLogo(out obtenido);

                        if (obtenido)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagen);

                            img.ScaleToFit(100, 100);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(Pdf.Left, Pdf.GetTop(45));
                            Pdf.Add(img);



                        }


                        using (StringReader sr = new StringReader(Texto_Html))
                        {

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, Pdf, sr);



                        }

                        Pdf.Close();
                        streem.Close();
                        MessageBox.Show("PDF generado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }


            }
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {

            txtFecha.Text = "";
          
            txtNumVenta.Text = "";
           
            txtcodigoVenta.Text = "";
            txtTotal.Text = "0.00";
            txtUsuario.Text = "";
            txtDescuento.Text = "0";
            dgvData.Rows.Clear();

        }
    }
}
