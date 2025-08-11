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
    public partial class frmGestionAtributos : Form
    {

        // aqui se crea la animacion de los paneles que corresponden a
        // gestionar las marcas, los colores y los atributos 
        // luego solo los mando a llamar las funciones.

        private Timer animationTimer;
        private Panel panelEnAnimacion; // Panel que se está animando actualmente

        private Panel panelAbiertoActual; // Panel que está o debería estar visible y quieto
        private Dictionary<Panel, Point> panelOriginalPositions;

        private int targetX; // Posición X objetivo para la animación
        private bool isSlidingOutCurrent; // Dirección de la animación actual
        private const int SLIDE_STEP = 30; // Velocidad de deslizamiento (píxeles por tick)
        private const int TIMER_INTERVAL = 10;


        public frmGestionAtributos()
        {
            InitializeComponent();

            //------------------------------------------
            // animacion de los paneles
            animationTimer = new Timer();
            animationTimer.Interval = TIMER_INTERVAL;
            animationTimer.Tick += AnimationTimer_Tick;



            panelOriginalPositions = new Dictionary<Panel, Point>();
            if (pnlColores != null) panelOriginalPositions[pnlColores] = pnlColores.Location;
            if (pnlMarcas != null) panelOriginalPositions[pnlMarcas] = pnlMarcas.Location;
            if (pnlGAtributos != null) panelOriginalPositions[pnlGAtributos] = pnlGAtributos.Location;

            OcultarTodosLosPanelesAlInicio();
        }







        private void frmGestionAtributos_Load(object sender, EventArgs e)
        {
            // Alimentar el combo box del buscador de los atributos

            foreach (DataGridViewColumn columna in dgvAtributo.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar3")
                {

                    cmbBuscador3.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbBuscador3.DisplayMember = "Texto";
            cmbBuscador3.ValueMember = "Valor";
            cmbBuscador3.SelectedIndex = -1;

            // listar los atributos disponibles

            List<Atributo> listarAtributo = new Atributo_N().listar();

            foreach (Atributo atributo in listarAtributo)
            {
                dgvAtributo.Rows.Add(new object[] { "", atributo.Id_Atributo, atributo.Nombre });
            }



            //Alimentar el combo box para el buscador de los colores


            foreach (DataGridViewColumn columna in dgvColor.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar2")
                {

                    cmbBuscador2.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbBuscador2.DisplayMember = "Texto";
            cmbBuscador2.ValueMember = "Valor";
            cmbBuscador2.SelectedIndex = -1;

            // listar los colores disponibles

            List<Colores> listarColor = new Colores_N().listar();

            foreach (Colores colores in listarColor)
            {
                dgvColor.Rows.Add(new object[] { "", colores.Id_Color, colores.Nombre });
            }


            // Alimientar el combo box de  buscar Marcas

            foreach(DataGridViewColumn columna in dgvMarca.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar1")
                {

                    cmbBuscador1.Items.Add(new CargarCombos() { Valor = columna.Name, Texto = columna.HeaderText });

                }

            }
            cmbBuscador1.DisplayMember = "Texto";
            cmbBuscador1.ValueMember = "Valor";
            cmbBuscador1.SelectedIndex = -1;

            // Cargar las marcas desde la base de datos


            List<Marca> listarMarca = new Marca_N().listar();

            foreach (Marca marca in listarMarca)
            {
                dgvMarca.Rows.Add(new object[] { "", marca.Id_Marca, marca.Nombre });
            }


        }









        // aqui entra la animación de los paneles
        private void OcultarTodosLosPanelesAlInicio()
        {

            if (pnlColores != null) pnlColores.Visible = false;
            if (pnlMarcas != null) pnlMarcas.Visible = false;
            if (pnlGAtributos != null) pnlGAtributos.Visible = false;

        }


        private void MostrarPanelConSlide(Panel panelToShow)
        {
            if (panelToShow == null) return;


            if (panelAbiertoActual == panelToShow && !animationTimer.Enabled && panelToShow.Visible)
            {
                return;
            }


            if (animationTimer.Enabled)
            {
                animationTimer.Stop();

                if (panelEnAnimacion != null && panelEnAnimacion != panelToShow)
                {
                    panelEnAnimacion.Visible = false;

                }
            }


            if (panelAbiertoActual != null && panelAbiertoActual != panelToShow && panelAbiertoActual.Visible)
            {
                panelAbiertoActual.Visible = false;

            }

            panelEnAnimacion = panelToShow;
            panelAbiertoActual = panelToShow;

            if (!panelOriginalPositions.ContainsKey(panelToShow))
            {

                panelOriginalPositions[panelToShow] = panelToShow.Location;

            }

            Point originalPos = panelOriginalPositions[panelToShow];


            panelToShow.Location = new Point(-panelToShow.Width, originalPos.Y);
            panelToShow.Visible = true;
            panelToShow.BringToFront();

            targetX = originalPos.X;
            isSlidingOutCurrent = false;

            animationTimer.Start();
        }


        private void OcultarPanelConSlideOut(Panel panelToHide)
        {
            if (panelToHide == null) return;



            if (animationTimer.Enabled)
            {
                animationTimer.Stop();

                if (panelEnAnimacion != null && panelEnAnimacion != panelToHide && !isSlidingOutCurrent)
                {
                    panelEnAnimacion.Visible = false;
                }
            }

            panelEnAnimacion = panelToHide;

            if (panelAbiertoActual == panelToHide)
            {

            }

            panelToHide.Visible = true;
            panelToHide.BringToFront();

            targetX = -panelToHide.Width;
            isSlidingOutCurrent = true;

            animationTimer.Start();
        }


        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (panelEnAnimacion == null)
            {
                animationTimer.Stop();
                return;
            }

            int currentX = panelEnAnimacion.Location.X;
            int newX;

            if (isSlidingOutCurrent)
            {
                newX = currentX - SLIDE_STEP;
                if (newX <= targetX)
                {
                    newX = targetX;
                    animationTimer.Stop();
                    panelEnAnimacion.Visible = false;
                    if (panelAbiertoActual == panelEnAnimacion)
                    {
                        panelAbiertoActual = null;
                    }
                    panelEnAnimacion = null;
                }
            }
            else
            {
                newX = currentX + SLIDE_STEP;
                if (newX >= targetX)
                {
                    newX = targetX;
                    animationTimer.Stop();

                    panelEnAnimacion = null;
                }
            }


            if (panelEnAnimacion != null)
            {
                panelEnAnimacion.Location = new Point(newX, panelEnAnimacion.Location.Y);
            }
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            MostrarPanelConSlide(pnlMarcas);
        }

        private void btnColores_Click(object sender, EventArgs e)
        {
            MostrarPanelConSlide(pnlColores);
        }

        private void btnAtributos_Click(object sender, EventArgs e)
        {
            MostrarPanelConSlide(pnlGAtributos);
        }
        // Cerrar los paneles 
        // cierra panel atributos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            OcultarPanelConSlideOut(pnlGAtributos);
        }

        // cierra panel Colores
        private void btnCerrarC_Click(object sender, EventArgs e)
        {
            OcultarPanelConSlideOut(pnlColores);
        }

        // cierra el panel Marcas

        private void btnCerrarMarcas_Click(object sender, EventArgs e)
        {
            OcultarPanelConSlideOut(pnlMarcas);
        }
        //-----------------------------------------------------------------
        // botones de guardar editar y eliminar ---------------------------------------

        // botones correspondientes al menu de Atributos
        private void btnGuardarAtributo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Atributo atributo = new Atributo()
            {
                Id_Atributo = Convert.ToInt32(txtId_Atributo.Text),
                Nombre = txtNombreAtributo.Text
            };

            if (atributo.Id_Atributo == 0)
            {
                int Id_AtributoGenerado = new Atributo_N().Registrar(atributo, out mensaje);

                if (Id_AtributoGenerado != 0)
                {
                    dgvAtributo.Rows.Add(new object[] { "", Id_AtributoGenerado, txtNombreAtributo.Text });
                    MessageBox.Show("Atributo agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new Atributo_N().Editar(atributo, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvAtributo.Rows[Convert.ToInt32(txtIndice3.Text)];
                    row.Cells["Id_Atributo"].Value = txtId_Atributo.Text;
                    row.Cells["NombreAtributo"].Value = txtNombreAtributo.Text;
                    MessageBox.Show("Se ha editado el atributo");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }



        private void btnEliminarAtributo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Atributo.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente el atributo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Atributo atributo = new Atributo()
                    {
                        Id_Atributo = Convert.ToInt32(txtId_Atributo.Text)
                    };

                    bool respuesta = new Atributo_N().Eliminar(atributo, out mensaje);

                    if (respuesta)
                    {
                        dgvAtributo.Rows.RemoveAt(Convert.ToInt32(txtIndice3.Text));
                        MessageBox.Show("Atributo elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Atributo ","Mensaje",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        }


        private void btnLimpiarAtributo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // fin  de botones de atributos 

        // comienzo de botones para menú colores 

        private void btnGuadarC_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Colores colores = new Colores()
            {
                Id_Color = Convert.ToInt32(txtId_Color.Text),
                Nombre = txtNombreC.Text
            };

            if (colores.Id_Color == 0)
            {
                int Id_ColorGenerado = new Colores_N().Registrar(colores, out mensaje);

                if (Id_ColorGenerado != 0)
                {
                    dgvColor.Rows.Add(new object[] { "", Id_ColorGenerado, txtNombreC.Text });
                    MessageBox.Show("Color agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new Colores_N().Editar(colores, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvColor.Rows[Convert.ToInt32(txtIndice2.Text)];
                    row.Cells["Id_Color"].Value = txtId_Color.Text;
                    row.Cells["NombreColor"].Value = txtNombreC.Text;
                    MessageBox.Show("Se ha editado el Color");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }

        }


        private void btnLimpiarC_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }


        private void btnEliminarC_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Color.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente el Color?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Colores color = new Colores ()
                    {
                        Id_Color = Convert.ToInt32(txtId_Color.Text)
                    };

                    bool respuesta = new Colores_N().Eliminar(color, out mensaje);

                    if (respuesta)
                    {
                        dgvColor.Rows.RemoveAt(Convert.ToInt32(txtIndice2.Text));
                        MessageBox.Show("Color elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Color ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }

        }



        // comienzo de botones para menú Marcas

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {

            string mensaje = string.Empty;

            Marca marca = new Marca()
            {
                Id_Marca = Convert.ToInt32(txtId_Marca.Text),
                Nombre = txtNombreMarca.Text
            };

            if (marca.Id_Marca == 0)
            {
                int Id_MarcaGenerado = new Marca_N().Registrar(marca, out mensaje);

                if (Id_MarcaGenerado != 0)
                {
                    dgvMarca.Rows.Add(new object[] { "", Id_MarcaGenerado, txtNombreMarca.Text });
                    MessageBox.Show("Marca agregado con éxito");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new Marca_N().Editar(marca, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvMarca.Rows[Convert.ToInt32(txtIndice1.Text)];
                    row.Cells["Id_Marca"].Value = txtId_Marca.Text;
                    row.Cells["NombreMarca"].Value = txtNombreMarca.Text;
                    MessageBox.Show("Se ha editado la marca");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }

        }

        private void btnLimpiarMarca_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId_Marca.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar de forma permanente la Marca?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Marca marca = new Marca()
                    {
                        Id_Marca = Convert.ToInt32(txtId_Marca.Text)
                    };

                    bool respuesta = new Marca_N().Eliminar(marca, out mensaje);

                    if (respuesta)
                    {
                        dgvMarca.Rows.RemoveAt(Convert.ToInt32(txtIndice1.Text));
                        MessageBox.Show("Marca elimidado con éxito");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Marca ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }

        }

        //------------------------------------------------------------------------------------


        private void LimpiarCampos()
        {
            txtIndice3.Text = "-1";
            txtId_Atributo.Text = "0";
            txtNombreAtributo.Text = "";

            txtIndice2.Text = "-1";
            txtId_Color.Text = "0";
            txtNombreC.Text = "";


            txtIndice1.Text = "-1";
            txtId_Marca.Text = "0";
            txtNombreMarca.Text = "";





        }

        // customizar los data grid 

        // data grid correspondiente a Atributos
        private void dgvAtributo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvAtributo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAtributo.Columns[e.ColumnIndex].Name == "btnSeleccionar3")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice3.Text = index.ToString();
                    txtId_Atributo.Text = dgvAtributo.Rows[index].Cells["Id_Atributo"].Value.ToString();
                    txtNombreAtributo.Text = dgvAtributo.Rows[index].Cells["NombreAtributo"].Value.ToString();
                }
            }
        }

        // data grid correspondiente a colores
        private void dgvColor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvColor.Columns[e.ColumnIndex].Name == "btnSeleccionar2")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice2.Text = index.ToString();
                    txtId_Color.Text = dgvColor.Rows[index].Cells["Id_Color"].Value.ToString();
                    txtNombreC.Text = dgvColor.Rows[index].Cells["NombreColor"].Value.ToString();
                }

            }
        }


        // data grid correspondiente a Marcas

        private void dgvMarca_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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


        private void dgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.Columns[e.ColumnIndex].Name == "btnSeleccionar1")
            {

                int index = e.RowIndex;

                if (index >= 0)
                {
                    txtIndice1.Text = index.ToString();
                    txtId_Marca.Text = dgvMarca.Rows[index].Cells["Id_Marca"].Value.ToString();
                    txtNombreMarca.Text = dgvMarca.Rows[index].Cells["NombreMarca"].Value.ToString();
                }

            
            }

        }




        // los buscadores de cada panel
        private void btnBuscarfiltros_Click(object sender, EventArgs e)
        {
            string filtrarColumna = ((CargarCombos)cmbBuscador3.SelectedItem).Valor.ToString();
            if (dgvAtributo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAtributo.Rows)
                {
                    if (row.Cells[filtrarColumna].Value.ToString().Trim().ToUpper().Contains(txtbuscadorFiltros3.Text.Trim().ToUpper()))
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

        private void btnLimpiarfiltros3_Click(object sender, EventArgs e)
        {
            txtbuscadorFiltros3.Text = "";

            foreach (DataGridViewRow row in dgvAtributo.Rows)
            {
                row.Visible = true;

            }
        }

      
        // filtros correspondientes a Marcas
        private void btnBuscador1_Click(object sender, EventArgs e)
        {

            string filtrarColumna = ((CargarCombos)cmbBuscador1.SelectedItem).Valor.ToString();
            if (dgvMarca.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMarca.Rows)
                {
                    if (row.Cells[filtrarColumna].Value.ToString().Trim().ToUpper().Contains(txtBuscador.Text.Trim().ToUpper()))
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

        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            txtBuscador.Text = "";

            foreach (DataGridViewRow row in dgvMarca.Rows)
            {
                row.Visible = true;

            }
        }

        private void btnFiltrarC_Click(object sender, EventArgs e)
        {
            string filtrarColumna = ((CargarCombos)cmbBuscador2.SelectedItem).Valor.ToString();
            if (dgvColor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvColor.Rows)
                {
                    if (row.Cells[filtrarColumna].Value.ToString().Trim().ToUpper().Contains(txtescrituraFiltroC.Text.Trim().ToUpper()))
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

        private void btnLimpiarFiltro2_Click(object sender, EventArgs e)
        {
            txtescrituraFiltroC.Text = "";

            foreach (DataGridViewRow row in dgvColor.Rows)
            {
                row.Visible = true;

            }
        }




































        //--------------------------------------------------------------------------------------------------
    }
}
