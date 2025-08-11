using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class Stock
    {
        public int Id_Stock { get; set; }
        public Producto oProducto { get; set; }
        public Proveedor oproveedor { get; set; }
        public int CatidadBase { get; set; }
        public decimal PrecioC {  get; set; }
        public decimal PrecioV { get; set; }
    }
}
