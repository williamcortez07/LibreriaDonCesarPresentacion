using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Compra_N
    {



        private CompraDT objCompra = new CompraDT();

        public int obtenerCorrelativo()
        {

            return objCompra.ObtenerCorrelativo();

        }

        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            Mensaje = string.Empty;

            return objCompra.Registrar(obj,DetalleCompra, out Mensaje);


        }


        public Compra ObtenerCompra( string numero)
        {
            Compra oCompra = objCompra.ObtenerCompra(numero);

            if (oCompra.Id_Compra != 0)
            { 
                List<DetalleCompra> odetalleCompra = objCompra.ObtenerDetalleCompra(oCompra.Id_Compra);
                oCompra.oDetalleCompras = odetalleCompra;

            }
            return oCompra;

        }

    }


    
}
