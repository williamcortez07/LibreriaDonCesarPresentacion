using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Permisos_N
    {
        
       private PermisosDT permisos = new PermisosDT();

        public List<Permiso> listar(int idUsuario)
        {

            return permisos.listar(idUsuario);

        }

    }
    
}
