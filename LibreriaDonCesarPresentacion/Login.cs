using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocios;
using CapaEntidad;

namespace LibreriaDonCesarPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           this.Close();

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            List<Usuario> cUsuario = new List<Usuario>();

            Usuario usuario = new Usuario_N().listar().Where(u => u.Nombre == txtNomUsuario.Text && u.Clave == txtClave.Text).FirstOrDefault();

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {txtNomUsuario.Text}");
                inicio frminicio = new inicio(usuario);
                frminicio.Show();
                this.Hide();

                frminicio.FormClosing += frm_Closing;



            }
            else
            {
                MessageBox.Show("Lo sentimos, no hemos encontrado tu Usuario");

            }

        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            txtNomUsuario.Text = "Nombre de Usuario";
            txtClave.Text = "**********";
            this.Show();

        }

        

        private void txtClave_MouseDown(object sender, MouseEventArgs e)
        {
            txtClave.Text = "";
        }

      

        private void txtNomUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            txtNomUsuario.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
