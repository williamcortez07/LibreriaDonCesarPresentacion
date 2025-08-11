using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Articulo_N
    {

        private ArticuloDT articulo = new ArticuloDT();

        public List<Articulo> listar()
        {
            return articulo.Listar();
        }


        public int Registrar(Articulo articulos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (articulos.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return articulo.Registrar(articulos, out Mensaje);
            }
        }

        public bool Editar(Articulo articulos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (articulos.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return articulo.Editar(articulos, out Mensaje);
            }
        }

        public bool Eliminar(Articulo articulos, out string Mensaje)
        {

            return articulo.Eliminar(articulos, out Mensaje);

        }
    }
}
