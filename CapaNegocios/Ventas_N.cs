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
    public class Ventas_N
    {

        private VentaDT objVenta = new VentaDT();

        public int obtenerCorrelativo()
        {

            return objVenta.ObtenerCorrelativo();

        }


        public Stock ObtenerStockCompleto(int Id_Producto)
        {
            return objVenta.ObtenerStockCompleto(Id_Producto);
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            Mensaje = string.Empty;

            return objVenta.Registrar(obj, DetalleVenta, out Mensaje);


        }

        public Venta obtenerVenta(string numero)
        {
            Venta obj = objVenta.obtnerventa(numero);

            if (obj.Id_Venta != 0)
            {
                List<DetalleVenta> odetalle = objVenta.ObtenerDetalleVenta(obj.Id_Venta);
                obj.oDetalleVenta = odetalle;

            }
            return obj;



        }

    }
}
