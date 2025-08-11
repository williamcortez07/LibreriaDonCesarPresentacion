using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Colores_N
    {

        private ColoresDT color = new ColoresDT();

        public List<Colores> listar()
        {
            return color.Listar();
        }


        public int Registrar(Colores colores, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (colores.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return color.Registrar(colores, out Mensaje);
            }
        }

        public bool Editar(Colores colores, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (colores.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return color.Editar(colores, out Mensaje);
            }
        }

        public bool Eliminar(Colores colores, out string Mensaje)
        {

            return color.Eliminar(colores, out Mensaje);

        }

    }
}
