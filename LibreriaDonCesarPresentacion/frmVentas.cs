using CapaEntidad;
using CapaNegocios;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {


        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";
           
            txtDescuento.Text = "0";

        }

        private void btnbuscarProducto_Click(object sender, EventArgs e)
        {

            using (var modal = new mdProducto())
            {
                //var result = modal.ShowDialog();

                if (modal.ShowDialog() == DialogResult.OK && modal._Producto != null)
                {
                    Producto productoSeleccionado = modal._Producto;
                    int stockDisponible = productoSeleccionado.stock?.CatidadBase ?? 0;

                        txtIdProducto.Text = modal._Producto.Id_Producto.ToString();
                        txtNombreProducto.Text = modal._Producto.oArticulo.Nombre.ToString();
                   
                        txtStock.Text = stockDisponible.ToString();

                         txtPrecio.Select();

                    
                }
                else
                {
                    txtNombreProducto.Select();

                }


            }
        }

        private void txtNombreProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Producto oProducto = new Producto_N().listar().Where(p => p.oArticulo.Nombre == txtNombreProducto.Text).FirstOrDefault();
                if (oProducto != null)
                {
                    txtNombreProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.Id_Producto.ToString();
                    txtPrecio.BackColor = System.Drawing.Color.Honeydew;
                    txtPrecio.Select();
                }
                else
                {
                    txtNombreProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtPrecio.BackColor = System.Drawing.Color.MistyRose;
                    txtNombreProducto.Select();
                    txtNombreProducto.Text = "";

                }




            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal Precio = 0;
            bool productoexiste = false;
            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("debe seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out Precio))
            {
                MessageBox.Show("Precio incorrecto - Formato moneda incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }



            foreach (DataGridViewRow fila in dgvData.Rows)
            {

                if (fila.Cells["Id_Producto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoexiste = true;
                    return;

                }

            }
            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(numCantidad.Value))
            {

                MessageBox.Show("No hay suficiente stock para el producto seleccionado");

                productoexiste = true;
                return;

            }

            if (!productoexiste)
            {

                dgvData.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtNombreProducto.Text,
                    numCantidad.Value.ToString(),
                    Precio.ToString("0.00"),
                    (numCantidad.Value * Precio).ToString("0.00")


                });
                CalcularTotal();
                Limpiarcampos();
                txtNombreProducto.Select();



            }

        }


        private void Limpiarcampos()
        {
            txtIdProducto.Text = "0";
            txtNombreProducto.Text = "";
            txtNombreProducto.BackColor = SystemColors.Control;
            txtPrecio.Text = "";
            numCantidad.Value = 1;
            txtStock.Text= "0";




        }


        private void CalcularTotal()
        {
            decimal total = 0;
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dgvData.Rows)

                {
                    total += Convert.ToDecimal(dr.Cells["SubTotal"].Value.ToString());


                }
                txtTotal.Text = total.ToString("0.00");


            }



        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.delete.Width;
                var h = Properties.Resources.delete.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    dgvData.Rows.RemoveAt(index);
                    CalcularTotal();

                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {

                    e.Handled = true;

                }
                else
                {

                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;


                    }
                    else
                    {
                        e.Handled = true;

                    }

                }
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDescuento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {

                    e.Handled = true;

                }
                else
                {

                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;


                    }
                    else
                    {
                        e.Handled = true;

                    }

                }
            }

        }


        private void totalapagar()
        {
            if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("No hay productos registrados para esta venta", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal descuento;
            decimal totalapagar = Convert.ToDecimal(txtTotal.Text);
            decimal total = Convert.ToDecimal(txtTotal.Text);

            if (txtDescuento.Text.Trim() == "")
            {
                txtTotalapagar.Text = total.ToString("0.00");
                txtDescuento.Text = "0";


            }


            if (decimal.TryParse(txtDescuento.Text.Trim(), out descuento))
            {
                if (descuento > total)
                {
                    MessageBox.Show("El descuento excede el total ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    decimal montofinal = total - descuento;
                    txtTotalapagar.Text = montofinal.ToString("0.00");
                }

            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                totalapagar();

            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {

                MessageBox.Show("Debe agregar productos para realizar la venta", "Mesanje", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }

            DataTable detalle_Venta = new DataTable();
            detalle_Venta.Columns.Add("Id_Producto", typeof(int));
            detalle_Venta.Columns.Add("Cantidad", typeof(int));
            detalle_Venta.Columns.Add("PrecioUnitario", typeof(decimal));
            detalle_Venta.Columns.Add("SubTotal", typeof(decimal));
           

            foreach (DataGridViewRow dt in dgvData.Rows)
            {
                detalle_Venta.Rows.Add(new object[]
                {
                    Convert.ToInt32(dt.Cells["Id_Producto"].Value.ToString()),
                    dt.Cells["Cantidad"].Value.ToString(),
                    dt.Cells["PrecioUnitario"].Value.ToString(),
                    dt.Cells["SubTotal"].Value.ToString(),
                   
                });


            }


            int idCorrelativo = new Ventas_N().obtenerCorrelativo();
            string numVenta = string.Format("{0:00000}", idCorrelativo);
            totalapagar();
            
            Venta oventa = new Venta()
            {
                oUsuario = new Usuario() { Id_Usuario = _Usuario.Id_Usuario},
                Total = Convert.ToDecimal(txtTotalapagar.Text),
                NumVenta = numVenta,
                Descuento = Convert.ToDecimal(txtDescuento.Text)
            };

            string mensaje = string.Empty;

            bool respuesta = new Ventas_N().Registrar(oventa, detalle_Venta, out  mensaje);
            if (respuesta)
            {
                var resultado = MessageBox.Show("Venta registrada \n" + numVenta + "\n\n Desea copiar e código?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                    Clipboard.SetText(numVenta);



                txtStock.Text = "0";
                txtTotal.Text = "";
                txtDescuento.Text = "0";
                txtTotalapagar.Text = "";
                dgvData.Rows.Clear();
                
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }


        }
    }
}
