using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Presentacion
    {
        public int Id_Presentacion {  get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public UnidadMedida oUnidadMedida { get; set; }
        public string FactorUnidad { get; set; }

    }
}
