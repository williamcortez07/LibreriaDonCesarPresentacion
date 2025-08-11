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
using System.Windows.Controls;
using System.Windows.Forms;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new Compra_N().ObtenerCompra(txtNumCompra.Text);

            if (oCompra.Id_Compra != 0)
            {

                txtNumcompracopia.Text = oCompra.NumCompra;
                txtFecha.Text = oCompra.Fecha;
                txtUsuario.Text = oCompra.oUsuario.Nombre;
                txtNombreProveedor.Text = oCompra.oproveedor.Nombre;
                txtApellido.Text = oCompra.oproveedor.Apellido;

                dgvData.Rows.Clear();

                foreach (DetalleCompra dc in oCompra.oDetalleCompras)
                {
                    dgvData.Rows.Add(new object[]{dc.oProducto.oArticulo.Nombre,dc.Cantidad,dc.PrecioUnitario, dc.SubTotal });

                }
                txtTotal.Text = oCompra.Total.ToString("0.00");


            }
            else
            {

                MessageBox.Show("Error, No se encontró resultados para su búsqueda");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtNombreProveedor.Text = "";
            txtNumCompra.Text = "";
            txtApellido.Text = "";
            txtNumcompracopia.Text = "";
            txtTotal.Text = "0.00";
            txtUsuario.Text = "";
            dgvData.Rows.Clear();

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (txtNumCompra.Text == "")
            {
                MessageBox.Show("No hay datos para descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            string Texto_Html = Properties.Resources.plantillaCompra.ToString();

            Negocio oDatos = new Negocio_N().ObtenerDatos();
            Texto_Html = Texto_Html.Replace("@nombre", oDatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@RUC", oDatos.RUC);
            Texto_Html = Texto_Html.Replace("@Direccion", oDatos.Direccion);

            Texto_Html = Texto_Html.Replace("@NumCompra", txtNumCompra.Text);

            Texto_Html = Texto_Html.Replace("@NombreProveedor", txtNombreProveedor.Text);

            Texto_Html = Texto_Html.Replace("@ApellidoProveedor", txtApellido.Text);

            Texto_Html = Texto_Html.Replace("@Fecha", txtFecha.Text);

            Texto_Html = Texto_Html.Replace("@Usuario", txtUsuario.Text);


            string filas = string.Empty;

            foreach (DataGridViewRow row in dgvData.Rows)
            {

                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";              
                filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";




            }
            Texto_Html = Texto_Html.Replace("filas", filas);
            Texto_Html = Texto_Html.Replace("@Total", txtTotal.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = string.Format("Compras_{0}.pdf",txtNumCompra.Text);
            saveFileDialog.Filter = "pdf Files | *.pdf";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream streem = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document Pdf = new Document(PageSize.A4,25,25,100,25);
                    PdfWriter writer = PdfWriter.GetInstance(Pdf,streem);
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
                        
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer,Pdf, sr);



                    }

                    Pdf.Close();
                    streem.Close();
                    MessageBox.Show("PDF generado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }


        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
