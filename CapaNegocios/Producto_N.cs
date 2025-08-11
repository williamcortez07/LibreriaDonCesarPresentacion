using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Producto_N
    {



        private ProductoDT ojb = new ProductoDT();

        public List<Producto> listar()
        {

            return ojb.listar();

        }

        public int Registrar(Producto producto, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (producto.Descripcion == "")
            {
                Mensaje = "La Descrición es obligatoria";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ojb.Registrar(producto, out Mensaje);
            }



        }

        public bool Editar(Producto producto, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (producto.Descripcion == "")
            {

                Mensaje = "La Descripción es obligatoria";

            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return ojb.Editar(producto, out Mensaje);
            }


        }

        public bool Eliminar(Producto producto, out string Mensaje)
        {

            return ojb.Eliminar(producto, out Mensaje);

        }




    }
}
