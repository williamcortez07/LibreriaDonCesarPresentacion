using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class SubCategoria
    {
        public int Id_SubCat { get; set; }
        public string Nombre { get; set; }
        public Categoria oId_Categoria { get; set; }


    }
}
