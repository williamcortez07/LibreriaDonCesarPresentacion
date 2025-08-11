using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class DetalleCompra
    {
        public int Id_DetalleCompra {  get; set; }
        public Producto oProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public List<Stock> oStock {  get; set; }
        public decimal SubTotal { get; set; }

    }
}
