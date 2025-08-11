using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class Producto
    {
        public int Id_Producto { get; set; }
        public Articulo oArticulo { get; set; }
        public Marca oMarca { get; set; }
        public Colores oColor { get; set; }
        public SubCategoria osubCategoria { get; set; }
        public Presentacion oPresentacion { get; set; }
        public Stock stock { get; set; }
        public string Descripcion { get; set; }
    }
}
