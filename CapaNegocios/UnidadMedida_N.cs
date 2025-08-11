using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class UnidadMedida_N
    {

        private UnidadMedidaDT UnidadMedida = new UnidadMedidaDT();

        public List<UnidadMedida> listar()
        {
            return UnidadMedida.Listar();
        }


        public int Registrar(UnidadMedida UnidadMedidas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (UnidadMedidas.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return UnidadMedida.Registrar(UnidadMedidas, out Mensaje);
            }
        }

        public bool Editar(UnidadMedida UnidadMedidas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (UnidadMedidas.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return UnidadMedida.Editar(UnidadMedidas, out Mensaje);
            }
        }

        public bool Eliminar(UnidadMedida UnidadMedidas, out string Mensaje)
        {

            return UnidadMedida.Eliminar(UnidadMedidas, out Mensaje);

        }

    }
}
