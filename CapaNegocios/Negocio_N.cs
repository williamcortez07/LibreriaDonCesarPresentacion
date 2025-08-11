using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Negocio_N
    {


        private NegocioDT obj = new NegocioDT();

        public Negocio ObtenerDatos()
        {
            return obj.ObtenerDatos();
        }


        public bool Guardar(Negocio negocio, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (negocio.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }

            if (negocio.RUC== "")
            {
                Mensaje = "El Ruc es obligatorio";
            }

            if (negocio.Direccion == "")
            {
                Mensaje = "La dirección obligatoria";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return obj.Guardar(negocio, out Mensaje);
            }



        }


        public byte[] obtenerLogo(out bool obtenido)
        {
           return  obj.Logo(out obtenido);
        }


        public bool ActualizarLogo(byte[] imagen, out string mensage)
        {
            return obj.actualizarLogo(imagen, out mensage);
        }



    }
}
