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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {

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


            List<Stock> listar = new Stock_N().listar();

            foreach (Stock stock in listar)
            {
                dgvData.Rows.Add(new object[] {stock.Id_Stock, stock.oProducto.oArticulo.Nombre, stock.CatidadBase, stock.PrecioC, stock.PrecioV });

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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
