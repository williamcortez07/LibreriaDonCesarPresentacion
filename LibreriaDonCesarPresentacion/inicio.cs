using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using CapaEntidad;
using CapaNegocios;
namespace LibreriaDonCesarPresentacion
{
    public partial class inicio : Form
    {
        private static Usuario usuarioA;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;


        public inicio( Usuario usuario)
        {
            usuarioA = usuario;
            InitializeComponent();
        }

        private void AbrirFormularios(IconMenuItem menu, Form formularioMostrar)
        {

            
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
             FormularioActivo.Close();

            }

            FormularioActivo = formularioMostrar;
            formularioMostrar.TopLevel = false;
            formularioMostrar.FormBorderStyle = FormBorderStyle.None;
            formularioMostrar.Dock = DockStyle.Fill;
            panelmostrarTodo.Controls.Add(formularioMostrar);
            formularioMostrar.BackColor = System.Drawing.Color.DarkSlateBlue;
            formularioMostrar.Show();



        }
        

        

        private void iconMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listapermisos = new Permisos_N().listar(usuarioA.Id_Usuario);

            foreach (IconMenuItem iconmenu in menuprincipal.Items)
            {

               bool  menuMostrar =  listapermisos.Any(m => m.NombrePantalla == iconmenu.Name);

                if (menuMostrar == false)
                {
                    iconmenu.Visible = false;
                }
                
            }

            lblNombreUsuario.Text = usuarioA.Nombre;

        }

        private void menuInventario_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmArticulos());
        }

        private void subMenuProduto_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmProductos());
        }

        private void subMenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmProveedores());
        }

        private void subMenuVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmVentas(usuarioA));

        }

        private void subMenuStock_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmStock());
        }

        private void iconMenuItem7_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuClasificacion, new frmCategoria());
        }

        private void subMenuSubCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuClasificacion, new frmSubCategorias());
        }

        private void SubMenuPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuClasificacion, new frmPresentacion());
        }

        private void SubMenuGestionAtributos_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuClasificacion, new frmGestionAtributos());
        }

        private void subMenuBajaInventario_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmBajaInventario());
        }

        

        private void subMenuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmUsuarios());
        }

       

        private void submenuTienda_Click(object sender, EventArgs e)
        {
            AbrirFormularios((IconMenuItem)sender, new frmNegocio());
        }

        private void submenuRegistraCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuOperaciones, new frmCompras(usuarioA));
        }

        private void subMenuDetalleCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuOperaciones, new frmDetalleCompra());

        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario , new frmDetalleVenta());
        }

        private void submenureportesCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuReportes, new frmReportesCompras());
        }

        private void submenureportesVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuReportes, new frmReportesVentas());
        }

        private void submenubaja_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmBajaInventario());
        }

        private void submenuatributos_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuInventario, new frmGestionAtributos());
        }

        private void submenuregistrarventas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuOperaciones, new frmVentas(usuarioA));
        }

        private void submenudetallesventas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuOperaciones, new frmDetalleVenta());
        }

        private void submenuproveedores_Click_1(object sender, EventArgs e)
        {
            AbrirFormularios(menuOperaciones, new frmProveedores());
        }

        private void submenuUsuarios_Click_1(object sender, EventArgs e)
        {
            AbrirFormularios(menuAdministracion, new frmUsuarios());

        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormularios(menuAdministracion, new frmNegocio()); 
        }
    }
}
