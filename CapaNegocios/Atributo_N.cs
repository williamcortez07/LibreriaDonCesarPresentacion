using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Atributo_N
    {

        private AtributosDT atributo = new AtributosDT();

        public List<Atributo> listar()
        {
            return atributo.Listar();
        }


        public int Registrar(Atributo atributos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (atributos.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return atributo.Registrar(atributos, out Mensaje);
            }
        }

        public bool Editar(Atributo atributos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (atributos.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return atributo.Editar(atributos, out Mensaje);
            }
        }

        public bool Eliminar(Atributo atributos, out string Mensaje)
        {

            return atributo.Eliminar(atributos, out Mensaje);

        }


    }
}
