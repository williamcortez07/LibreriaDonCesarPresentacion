using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Reportes_N
    {
        private ReportesDT objreportes = new ReportesDT();

        public List<ReportesCompra> compra(string fechainicio, string fechafin, int id_Proveedor)
        {
            return objreportes.Compras(fechainicio, fechafin, id_Proveedor);
        }


        public List<ReportesVenta> venta(string fechainicio, string fechafin)
        {
            return objreportes.Ventas(fechainicio, fechafin);
        }





    }
}
