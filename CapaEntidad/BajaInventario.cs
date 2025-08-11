using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class BajaInventario
    {
        public int Id_Baja { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
        public string Fecha { get; set; }
        public Producto oProducto { get; set; }
    }
}
