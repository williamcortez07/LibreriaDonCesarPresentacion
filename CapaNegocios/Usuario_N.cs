using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class Usuario_N
    {
        private UsuarioDT usuario = new UsuarioDT();

        public List<Usuario> listar()
        {

            return usuario.listar();

        }

        public int Registrar(Usuario usuarios, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (usuarios.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }

            if (usuarios.Clave == "")
            {

                Mensaje = "La contraseña es obligatoria";

            }
            if (usuarios.Rol == "")
            {

                Mensaje = "El Rol es obligatorio";

            }
            if (usuarios.Nombre == "" && usuarios.Clave == "" && usuarios.Rol == "")
            {

                Mensaje = "Los campos no pueden estar vacíos ";

            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {

                return usuario.Registrar(usuarios, out Mensaje);
            }

            

        }

        public bool Editar(Usuario usuarios, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (usuarios.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }

            if (usuarios.Clave == "")
            {

                Mensaje = "La contraseña es obligatoria";

            }
            if (usuarios.Rol == "")
            {

                Mensaje = "El Rol es obligatorio";

            }
            if (usuarios.Nombre == "" && usuarios.Clave == "" && usuarios.Rol == "")
            {

                Mensaje = "Los campos no pueden estar vacíos ";

            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return usuario.Editar(usuarios, out Mensaje);
            }
            

        }

        public bool Eliminar(Usuario usuarios, out string Mensaje)
        {

            return usuario.Eliminar(usuarios, out Mensaje);

        }







    }
}
