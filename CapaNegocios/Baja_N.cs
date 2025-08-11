using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Baja_N
    {


        private BajaInventarioDT ojt = new BajaInventarioDT();

        public List<BajaInventario> listar()
        {

            return ojt.listar();

        }

        public int Registrar(BajaInventario baja, out string Mensaje)
        {
            Mensaje = string.Empty;           

            if (baja.Cantidad < 1)
            {

                Mensaje = "La cantidad debe ser mayor a cero";

            }
            if (baja.Motivo == "")
            {

                Mensaje = "El Motivo de la Baja es obligatorio";

            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {

                return ojt.Registrar (baja, out Mensaje);
            }



        }

        public bool Editar(BajaInventario baja, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (baja.Cantidad < 1)
            {

                Mensaje = "La cantidad debe ser mayor a cero";

            }
            if (baja.Motivo == "")
            {

                Mensaje = "El Motivo de la Baja es obligatorio";

            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return ojt.Editar(baja, out Mensaje);
            }


        }

        public bool Eliminar(BajaInventario baja, out string Mensaje)
        {

            return ojt.Eliminar(baja, out Mensaje);

        }




    }
}
