using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Proveedor_N
    {

        private ProveedorDT proveedor = new ProveedorDT();

        public List<Proveedor> listar()
        {

            return proveedor.listar();

        }

        public int Registrar(Proveedor proveedores, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (proveedores.Nombre == "")
            {
                Mensaje = "El nombre es obligatorio";
            }

            if (proveedores.Telefono == "" && proveedores.Correo == "")
            {
                Mensaje = "El Teléfono o el Correo es obligatorio";
            }                   

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {

                return proveedor.Registrar(proveedores, out Mensaje);
            }



        }

        public bool Editar(Proveedor proveedores, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (proveedores.Nombre == "")
            {

                Mensaje = "El nombre es obligatorio";

            }

            if (proveedores.Telefono == "" && proveedores.Correo == "")
            {
                Mensaje = "El Teléfono o el Correo es obligatorio";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {

                return proveedor.Editar(proveedores, out Mensaje);
            }


        }

        public bool Eliminar(Proveedor proveedores, out string Mensaje)
        {

            return proveedor.Eliminar(proveedores, out Mensaje);

        }
    }
}
