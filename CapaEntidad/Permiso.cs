using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public class Permiso
    {
        public int Id_Permiso {  get; set; }
        public Usuario oUsuario { get; set; }
        public string NombrePantalla { get; set; }
    }
}
