using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class SubCategoria_N
    {


        private SubCategoriaDT subcategoria = new SubCategoriaDT();

        public List<SubCategoria> listar()
        {

            return subcategoria.listar();

        }

        public int Registrar(SubCategoria subcategorias, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (subcategorias.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return subcategoria.Registrar(subcategorias, out Mensaje);
            }



        }

        public bool Editar(SubCategoria subcategorias, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (subcategorias.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }

           
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return subcategoria.Editar(subcategorias, out Mensaje);
            }


        }

        public bool Eliminar(SubCategoria subcategorias, out string Mensaje)
        {

            return subcategoria.Eliminar(subcategorias, out Mensaje);

        }




    }
}
