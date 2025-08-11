using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaDonCesarPresentacion
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Image imageconn(byte[] imagenbytes)
        {

            MemoryStream stream = new MemoryStream();
            stream.Write(imagenbytes, 0, imagenbytes.Length);
            Image imagen = new Bitmap(stream);

            return imagen;
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimagen = new  Negocio_N().obtenerLogo(out  obtenido);
            if (obtenido )
                picLogo.Image = imageconn(byteimagen);

            Negocio datos = new Negocio_N().ObtenerDatos();
            txtNombre.Text = datos.Nombre;
            txtRuc.Text = datos.RUC;
            txtDireccion.Text = datos.Direccion;

        }

        

        private void btnCargar_Click(object sender, EventArgs e)
        {
           string mensaje = string.Empty;

            OpenFileDialog op = new OpenFileDialog();
            op.FileName = "Files|*.jpg;*.jpeg;*.png";

            if (op.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimagen = File.ReadAllBytes(op.FileName);
                bool respuesta = new Negocio_N().ActualizarLogo(byteimagen, out mensaje);

                if (respuesta)
                {
                    picLogo.Image = imageconn(byteimagen);

                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty ;

            Negocio obj = new Negocio()
            {
                Nombre = txtNombre.Text,
                RUC = txtRuc.Text,
                Direccion = txtDireccion.Text,

            };


            bool respuesta = new Negocio_N().Guardar(obj, out mensaje);

            if (respuesta)
            {

                MessageBox.Show("Los cambios fuero guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ocurrió un error al guadar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
    }
}
