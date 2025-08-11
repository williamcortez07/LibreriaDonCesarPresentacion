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
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;
        public frmCompras(Usuario oUsuario = null)
        {

            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";
            txtIdProveedor.Text = "0";

        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {

                    txtIdProveedor.Text = modal._proveedor.Id_Proveedor.ToString();
                    txtNombreProveedor.Text = modal._proveedor.Nombre.ToString();
                    txtApellido.Text = modal._proveedor.Apellido.ToString();

                }
                else
                {
                    txtNombreProveedor.Select();

                }


            }
        }

        private void btnbuscarProducto_Click(object sender, EventArgs e)
        {

            using (var modal = new mdProducto ())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {

                    txtIdProducto.Text = modal._Producto.Id_Producto.ToString();
                    txtNombreProducto.Text = modal._Producto.oArticulo.Nombre.ToString();
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
               
                Producto oProducto =  new Producto_N().listar().Where(p => p.oArticulo.Nombre == txtNombreProducto.Text).FirstOrDefault();
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
                txttotal.Text = total.ToString("0.00");


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

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {

                MessageBox.Show("Debe seleccionar un proveedor para continuar con la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DataTable DetalleCompra = new DataTable();
            DetalleCompra.Columns.Add("Id_Producto", typeof(int));
            DetalleCompra.Columns.Add("Cantidad", typeof(int));
            DetalleCompra.Columns.Add("PrecioUnitario", typeof(decimal));
            DetalleCompra.Columns.Add("SubTotal", typeof(decimal));


            foreach (DataGridViewRow row in dgvData.Rows)
            {
                DetalleCompra.Rows.Add(new object[]
                {
                   Convert.ToInt32(row.Cells["Id_Producto"].Value.ToString()),
                   row.Cells["Cantidad"].Value.ToString(),
                   row.Cells["PrecioUnitario"].Value.ToString(),
                   row.Cells["SubTotal"].Value.ToString()
                });

            }


            int Id_Correlativo = new Compra_N().obtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", Id_Correlativo);

            Compra ocompra = new Compra()
            {
                oUsuario = new Usuario() { Id_Usuario = _Usuario.Id_Usuario },
                oproveedor = new Proveedor() { Id_Proveedor = Convert.ToInt32(txtIdProveedor.Text)},
                Total =Convert.ToDecimal( txttotal.Text),
                NumCompra = numeroDocumento

               

            };

            string mensaje = string.Empty;
            bool Respuesta =  new Compra_N().Registrar(ocompra,DetalleCompra,out mensaje);

            if (Respuesta)
            {
                var resultado = MessageBox.Show("Compra registrada " + numeroDocumento);

                txtIdProveedor.Text = "0";
                txtNombreProveedor.Text = "";
                txtApellido.Text = "";
                txtNombreProducto.Text = "";
                txtPrecio.Text = "0";
                numCantidad.Value = 1;
                dgvData.Rows.Clear();
                CalcularTotal();


            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

    }
}
