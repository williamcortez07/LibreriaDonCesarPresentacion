using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Marca_N
    {

        private MarcaDT marca = new MarcaDT();

        public List<Marca> listar()
        {
            return marca.Listar();
        }


        public int Registrar(Marca marcas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (marcas.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return marca.Registrar(marcas, out Mensaje);
            }
        }

        public bool Editar(Marca marcas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (marcas.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return marca.Editar(marcas, out Mensaje);
            }
        }

        public bool Eliminar(Marca marcas, out string Mensaje)
        {

            return marca.Eliminar(marcas, out Mensaje);

        }
    }
}
