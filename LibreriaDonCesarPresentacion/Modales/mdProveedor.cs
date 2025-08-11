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

namespace LibreriaDonCesarPresentacion.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor _proveedor {  get; set; }

        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvProveedor.Columns)
            {
                if (columna.Visible == true)
                {

                    cmbbusquedaFiltro.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbbusquedaFiltro.DisplayMember = "Texto";
            cmbbusquedaFiltro.ValueMember = "Valor";
            cmbbusquedaFiltro.SelectedIndex = -1;



            List<Proveedor> listarProvvedores = new Proveedor_N().listar();

            foreach (Proveedor proveedor in listarProvvedores)
            {
                dgvProveedor.Rows.Add(new object[] { proveedor.Id_Proveedor, proveedor.Nombre, proveedor.Apellido});

            }
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icolumn = e.ColumnIndex;

            if (irow >= 0 && icolumn > 0)
            {

                _proveedor = new Proveedor()
                {

                    Id_Proveedor = Convert.ToInt32(dgvProveedor.Rows[irow].Cells["Id"].Value.ToString()),
                    Nombre = dgvProveedor.Rows[irow].Cells["Nombre"].Value.ToString(),
                    Apellido = dgvProveedor.Rows[irow].Cells["Apellido"].Value.ToString()


                };

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtrarColumna = ((CargarCombos)cmbbusquedaFiltro.SelectedItem).Valor.ToString();
            if (dgvProveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedor.Rows)
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

            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                row.Visible = true;

            }
        }
    }
}
