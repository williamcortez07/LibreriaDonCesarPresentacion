using CapaDatos;
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
    public partial class frmSubCategorias : Form
    {
        public frmSubCategorias()
        {
            InitializeComponent();
        }

        private void frmSubCategorias_Load(object sender, EventArgs e)
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


           

                        // se carga en el com box las categorias exixtentes en la base de datos
                        List<Categoria> listarCate = new Categoria_N().listar();

                        foreach (Categoria item in listarCate)
                        {
                            cmbCategoria.Items.Add(new CargarCombos() { Valor = item.Id_Categoria, Texto = item.Nombre});

                        }
                        cmbCategoria.DisplayMember = "Texto";
                        cmbCategoria.ValueMember = "Valor";
                        cmbCategoria.SelectedIndex = -1;



            // mostrar las subcategorias
            List<SubCategoria> listar = new SubCategoria_N().listar();

            foreach (SubCategoria obj in listar)
            {
                dgvData.Rows.Add(new object[] { 
                "",
                obj.Id_SubCat,
                obj.Nombre,
                obj.oId_Categoria.Id_Categoria,
                obj.oId_Categoria.Nombre,
                obj.oId_Categoria.Descripcion                
                
                });
            }

        


        }

   

   


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string mensaje = string.Empty;

            if (cmbCategoria.SelectedIndex == -1)
            {

                MessageBox.Show("por favor debe seleccionar una categoria");
            }
            else
            {



                SubCategoria obj = new SubCategoria()
                {
                    Id_SubCat = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    oId_Categoria = new Categoria() { Id_Categoria = Convert.ToInt32(((CargarCombos)cmbCategoria.SelectedItem).Valor) }
                };

                int idCategoriaSeleccionada = Convert.ToInt32(((CargarCombos)cmbCategoria.SelectedItem).Valor);
                Categoria categoriaSeleccionada = new Categoria_N().ObtenerPorId(idCategoriaSeleccionada);

                string descripcionCategoria = categoriaSeleccionada != null ? categoriaSeleccionada.Descripcion : "";

                if (obj.Id_SubCat == 0)
                {
                    int Id_Generado = new SubCategoria_N().Registrar(obj, out mensaje);

                    if (Id_Generado != 0)
                    {
                        dgvData.Rows.Add(new object[] {
                "",
                Id_Generado,
                txtNombre.Text,
                idCategoriaSeleccionada.ToString(),
                ((CargarCombos)cmbCategoria.SelectedItem).Texto.ToString(),
                descripcionCategoria
            });

                        MessageBox.Show("Subcategoría agregada con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    bool resultado = new SubCategoria_N().Editar(obj, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["Id"].Value = txtId.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Id_Categoria"].Value = idCategoriaSeleccionada.ToString();
                        row.Cells["Categoria"].Value = ((CargarCombos)cmbCategoria.SelectedItem).Texto.ToString();
                        row.Cells["Descripcion"].Value = descripcionCategoria;

                        MessageBox.Show("Se ha editado la Subcategoría");
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
            cmbCategoria.SelectedIndex = -1;

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



                    foreach (CargarCombos cc in cmbCategoria.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Categoria"].Value))
                        {
                            int indice = cmbCategoria.Items.IndexOf(cc);
                            cmbCategoria.SelectedIndex = indice;
                            break;

                        }

                    }
                    
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente la Subcategoria?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    SubCategoria obj = new SubCategoria()
                    {

                        Id_SubCat = Convert.ToInt32(txtId.Text)

                    };

                    bool respuesta = new SubCategoria_N().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {

                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("SubCategoria elimidada con éxito");
                        LimpiarCampos();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar la Subcategoria", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
