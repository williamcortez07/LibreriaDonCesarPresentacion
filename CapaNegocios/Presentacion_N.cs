using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Presentacion_N
    {

        private PresentacionDT Presentacion = new PresentacionDT();

        public List<Presentacion> listar()
        {

            return Presentacion.listar();

        }

        public int Registrar(Presentacion Presentaciones, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (Presentaciones.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }

            if (Presentaciones.Cantidad < 0)
            {
                Mensaje = "El Catindad debe ser mayor a 0";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {

                return Presentacion.Registrar(Presentaciones, out Mensaje);
            }



        }

        public bool Editar(Presentacion Presentaciones, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (Presentaciones.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }


            if (Presentaciones.Cantidad < 0)
            {
                Mensaje = "El Catindad debe ser mayor a 0";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return Presentacion.Editar(Presentaciones, out Mensaje);
            }


        }

        public bool Eliminar(Presentacion Presentaciones, out string Mensaje)
        {

            return Presentacion.Eliminar(Presentaciones, out Mensaje);

        }


    }
}
