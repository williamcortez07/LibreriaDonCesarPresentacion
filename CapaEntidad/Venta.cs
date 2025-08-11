using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Venta
    {
        public int Id_Venta { get; set; }
        public string Fecha { get; set; }
        public Usuario oUsuario {  get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }
        public decimal Total { get; set; }
        public string NumVenta { get; set; }
        public decimal Descuento { get; set; }

    }
}
