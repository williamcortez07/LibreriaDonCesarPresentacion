using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra

    { 
        public int Id_Compra {  get; set; }
        public string Fecha { get; set; }
        public Usuario oUsuario { get; set; }
        public Proveedor oproveedor { get; set; }
        public string  NumCompra {  get; set; }
        public List<DetalleCompra> oDetalleCompras { get; set; }
        public decimal Total { get; set; }
    }
}
