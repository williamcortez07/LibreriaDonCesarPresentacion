using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Categoria_N
    {

        private CategoriaDT categoria = new CategoriaDT();

        public List<Categoria> listar()
        {

            return categoria.listar();

        }

        public int Registrar(Categoria categorias, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (categorias.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }

            if (categorias.Descripcion == "")
            {
                Mensaje = "por favor agrege una descripción";
            }
           
            if (categorias.Nombre == "" && categorias.Descripcion == "")
            {

                Mensaje = "Los campos no pueden estar vacíos ";

            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
               return categoria.Registrar(categorias, out Mensaje);
            }



        }

        public Categoria ObtenerPorId(int id)
        {
            return categoria.ObtenerPorId(id);
        }


        public bool Editar(Categoria categorias, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (categorias.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }

            if (categorias.Descripcion == "")
            {

                Mensaje = "por favor agrege una descripción";

            }
            
            if (categorias.Nombre == "" && categorias.Descripcion == "")
            {

                Mensaje = "Los campos no pueden estar vacíos ";

            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return categoria.Editar(categorias, out Mensaje);
            }


        }

        public bool Eliminar(Categoria categorias, out string Mensaje)
        {

            return categoria.Eliminar(categorias, out Mensaje);

        }




    }
}
