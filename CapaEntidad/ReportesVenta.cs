using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
public class ReportesVenta
    {
      public string fecha {  get; set; }
        public string NumVenta { get; set; }
        public string Total { get; set; }
        public string Usuario { get; set; }  
        public string NomProducto { get; set; }
        public string PrecioC { get; set; }
        public string PrecioV { get; set; }
        public string Cantidad  { get; set; }
        public string SubTotal { get; set; }
        public string nomSubCategoria { get; set; }
        public string nomColor { get; set; }
        public string nomMarca { get; set; }

    }
}
