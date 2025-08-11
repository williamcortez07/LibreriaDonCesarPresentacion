using CapaEntidad;
using CapaNegocios;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
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



            List<Articulo> listaA = new Articulo_N().listar();

            foreach (Articulo item in listaA)
            {
                cmbArticulo.Items.Add(new CargarCombos() { Valor = item.Id_Articulo, Texto = item.Nombre });

            }
            cmbArticulo.DisplayMember = "Texto";
            cmbArticulo.ValueMember = "Valor";
            cmbArticulo.SelectedIndex = -1;

            List<Marca> listaM = new Marca_N().listar();

            foreach (Marca item in listaM)
            {
                cmbMarca.Items.Add(new CargarCombos() { Valor = item.Id_Marca, Texto = item.Nombre });

            }
            cmbMarca.DisplayMember = "Texto";
            cmbMarca.ValueMember = "Valor";
            cmbMarca.SelectedIndex = -1;

            List<Colores> listaC = new Colores_N().listar();

            foreach (Colores item in listaC)
            {
                cmbColor.Items.Add(new CargarCombos() { Valor = item.Id_Color, Texto = item.Nombre });

            }
            cmbColor.DisplayMember = "Texto";
            cmbColor.ValueMember = "Valor";
            cmbColor.SelectedIndex = -1;

            List<SubCategoria> listaS = new SubCategoria_N().listar();

            foreach (SubCategoria item in listaS)
            {
                cmbSubCat.Items.Add(new CargarCombos() { Valor = item.Id_SubCat, Texto = item.Nombre });

            }
            cmbSubCat.DisplayMember = "Texto";
            cmbSubCat.ValueMember = "Valor";
            cmbSubCat.SelectedIndex = -1;

            
            List<Presentacion> listaP = new Presentacion_N().listar();

            foreach (Presentacion item in listaP)
            {
                cmbPresentacion.Items.Add(new CargarCombos() { Valor = item.Id_Presentacion, Texto = item.Nombre });

            }
             cmbPresentacion.DisplayMember = "Texto";
             cmbPresentacion.ValueMember = "Valor";
             cmbPresentacion.SelectedIndex = -1;

            


         





            // mostrar Los productos
            List<Producto> listar = new Producto_N().listar();

            foreach (Producto obj in listar)
            {
                dgvData.Rows.Add(new object[] {
                "",
                obj.Id_Producto,
                obj.oArticulo.Id_Articulo,
                obj.oArticulo.Nombre,
                obj.oMarca.Id_Marca,
                obj.oMarca.Nombre,
                obj.oColor.Id_Color,
                obj.oColor.Nombre,
                obj.osubCategoria.Id_SubCat,
                obj.osubCategoria.Nombre,
                obj.oPresentacion.Id_Presentacion,
                obj.oPresentacion.Nombre,
                obj.Descripcion

                });
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (cmbArticulo.SelectedIndex == -1 && cmbMarca.SelectedIndex == -1 && cmbColor.SelectedIndex == -1 && cmbSubCat.SelectedIndex == -1 && cmbPresentacion.SelectedIndex == -1)
            {
                MessageBox.Show("Porfavor complete los datos para agregar un producto");


            }
            else
            {





                Producto obj = new Producto()
                {
                    Id_Producto = Convert.ToInt32(txtId.Text),
                    oArticulo = new Articulo() { Id_Articulo = Convert.ToInt32(((CargarCombos)cmbArticulo.SelectedItem).Valor) },
                    oMarca = new Marca() { Id_Marca = Convert.ToInt32(((CargarCombos)cmbMarca.SelectedItem).Valor) },
                    oColor = new Colores() { Id_Color = Convert.ToInt32(((CargarCombos)cmbColor.SelectedItem).Valor) },
                    osubCategoria = new SubCategoria() { Id_SubCat = Convert.ToInt32(((CargarCombos)cmbSubCat.SelectedItem).Valor) },
                    oPresentacion = new Presentacion() { Id_Presentacion = Convert.ToInt32(((CargarCombos)cmbPresentacion.SelectedItem).Valor) },
                    Descripcion = txtDescripcion.Text,
                };


                if (obj.Id_Producto == 0)
                {
                    int Id_Generado = new Producto_N().Registrar(obj, out mensaje);

                    if (Id_Generado != 0)
                    {
                        dgvData.Rows.Add(new object[] {
                "",
                Id_Generado,
                ((CargarCombos)cmbArticulo.SelectedItem).Valor.ToString(),
                ((CargarCombos)cmbArticulo.SelectedItem).Texto.ToString(),

                 ((CargarCombos)cmbMarca.SelectedItem).Valor.ToString(),
                 ((CargarCombos)cmbMarca.SelectedItem).Texto.ToString(),


                 ((CargarCombos)cmbColor.SelectedItem).Valor.ToString(),
                 ((CargarCombos)cmbColor.SelectedItem).Texto.ToString(),


                 ((CargarCombos)cmbSubCat.SelectedItem).Valor.ToString(),
                 ((CargarCombos)cmbSubCat.SelectedItem).Texto.ToString(),

                 ((CargarCombos)cmbPresentacion.SelectedItem).Valor.ToString(),
                 ((CargarCombos)cmbPresentacion.SelectedItem).Texto.ToString(),

                  txtDescripcion.Text

            });

                        MessageBox.Show("Producto agregado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    bool resultado = new Producto_N().Editar(obj, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["Id"].Value = txtId.Text;

                        row.Cells["Id_Articulo"].Value = ((CargarCombos)cmbArticulo.SelectedItem).Valor.ToString();
                        row.Cells["Articulo"].Value = ((CargarCombos)cmbArticulo.SelectedItem).Texto.ToString();

                        row.Cells["Id_Marca"].Value = ((CargarCombos)cmbMarca.SelectedItem).Valor.ToString();
                        row.Cells["Marca"].Value = ((CargarCombos)cmbMarca.SelectedItem).Texto.ToString();

                        row.Cells["Id_Color"].Value = ((CargarCombos)cmbColor.SelectedItem).Valor.ToString();
                        row.Cells["Color"].Value = ((CargarCombos)cmbColor.SelectedItem).Texto.ToString();

                        row.Cells["Id_SubCat"].Value = ((CargarCombos)cmbSubCat.SelectedItem).Valor.ToString();
                        row.Cells["SubCat"].Value = ((CargarCombos)cmbSubCat.SelectedItem).Texto.ToString();

                        row.Cells["Id_Presentacion"].Value = ((CargarCombos)cmbPresentacion.SelectedItem).Valor.ToString();
                        row.Cells["Presentacion"].Value = ((CargarCombos)cmbPresentacion.SelectedItem).Texto.ToString();

                        row.Cells["Descripcion"].Value = txtDescripcion.Text;

                        MessageBox.Show("Se ha editado el Producto");
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
            cmbArticulo.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            cmbSubCat.SelectedIndex = -1;
            cmbPresentacion.SelectedIndex = -1;
            txtDescripcion.Text = "";




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
                    txtDescripcion.Text = dgvData.Rows[index].Cells["Descripcion"].Value.ToString();



                    foreach (CargarCombos cc in cmbArticulo.Items)
                    {
                         if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Articulo"].Value))
                        {
                            int indice = cmbArticulo.Items.IndexOf(cc);
                            cmbArticulo.SelectedIndex = indice;
                            break;

                        }

                    }

                    foreach (CargarCombos cc in cmbMarca.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Marca"].Value))
                        {
                            int indice = cmbMarca.Items.IndexOf(cc);
                            cmbMarca.SelectedIndex = indice;
                            break;

                        }

                    }

                    foreach (CargarCombos cc in cmbColor.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Color"].Value))
                        {
                            int indice = cmbColor.Items.IndexOf(cc);
                            cmbColor.SelectedIndex = indice;
                            break;

                        }

                    }


                    foreach (CargarCombos cc in cmbSubCat.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_SubCat"].Value))
                        {
                            int indice = cmbSubCat.Items.IndexOf(cc);
                            cmbSubCat.SelectedIndex = indice;
                            break;

                        }
                    }


                    foreach (CargarCombos cc in cmbPresentacion.Items)
                    {
                        if (Convert.ToInt32(cc.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["Id_Presentacion"].Value))
                        {
                            int indice = cmbPresentacion.Items.IndexOf(cc);
                            cmbPresentacion.SelectedIndex = indice;
                            break;

                        }



                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show($"¿Desea eliminar de forma permanente el producto?{cmbArticulo.Text}", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Producto obj = new Producto()
                    {

                        Id_Producto = Convert.ToInt32(txtId.Text)

                    };

                    bool respuesta = new Producto_N().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {

                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show("Producto elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {

                        MessageBox.Show("No se pudo eliminar el Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            if (dgvData.Rows.Count <1 )
            {
                MessageBox.Show("No hay datos para Descargar" ,"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add( columna.HeaderText,typeof(string));


                   

                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                    dt.Rows.Add(new object[]
                    {
                        row.Cells[3].Value.ToString(),
                         row.Cells[5].Value.ToString(),
                          row.Cells[7].Value.ToString(),
                           row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                             row.Cells[12].Value.ToString(),

                    });


                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = string.Format("Reportes Productos_{0}",DateTime.Now.ToString("ddMMyyyyHHmmSS"));
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