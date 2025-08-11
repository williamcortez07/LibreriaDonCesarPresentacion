using CapaEntidad;
using CapaNegocios;
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

namespace LibreriaDonCesarPresentacion.Modales
{

    public partial class mdProducto : Form
    {
        public Producto _Producto { get; set; }
        public Stock _Stock { get; set; }

        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {

            // Cargar las columnas filtrables en el ComboBox
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;

            // Cargar los productos en el DataGridView
            CargarProductos();
        }


              private void CargarProductos()
        {
            dgvData.Rows.Clear();
            List<Producto> listar = new Producto_N().listar();
            Ventas_N ventasNegocio = new Ventas_N();

            foreach (Producto obj in listar)
            {
                Stock stock = ventasNegocio.ObtenerStockCompleto(obj.Id_Producto);
                obj.stock = stock; // Asignamos el stock al producto

                dgvData.Rows.Add(new object[] {
            obj.Id_Producto,
            obj.oArticulo.Id_Articulo,
            obj.oArticulo.Nombre,
            obj.oMarca.Id_Marca,
            obj.oMarca.Nombre,
            obj.osubCategoria.Id_SubCat,
            obj.osubCategoria.Nombre,
            obj.oPresentacion.Id_Presentacion,
            obj.oPresentacion.Nombre,
            stock != null ? stock.CatidadBase : 0 // Mostramos la cantidad base
        });
            }
        }





        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            int column = e.ColumnIndex;

            if (row >= 0 && column > 0)
            {
                int idProducto = Convert.ToInt32(dgvData.Rows[row].Cells["Id"].Value);

                // Buscamos el producto en la lista ya cargada (más eficiente que consultar de nuevo)
                List<Producto> productos = new Producto_N().listar();
                Producto productoSeleccionado = productos.FirstOrDefault(p => p.Id_Producto == idProducto);

                if (productoSeleccionado != null && productoSeleccionado.stock != null)
                {
                    _Producto = productoSeleccionado;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontró información de stock para este producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FiltrarProductos()
        {
            if (cmbbusquedaFiltro.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un filtro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string filtrarColumna = ((CargarCombos)cmbbusquedaFiltro.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[filtrarColumna].Value != null && row.Cells[filtrarColumna].Value.ToString().Trim().ToUpper().Contains(txtescrituraFiltro.Text.Trim().ToUpper()))
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            FiltrarProductos();
        }

        private void LimpiarFiltros()
        {
            txtescrituraFiltro.Text = "";
            CargarProductos(); // Simplemente recargar todos los productos

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
    }
}
