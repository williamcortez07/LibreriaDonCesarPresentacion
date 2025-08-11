using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class ProveedorDT
    {


        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    string query = "Select Id_Proveedor,Nombre,Apellido,Telefono, Correo from Proveedor";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                Id_Proveedor = Convert.ToInt32(reader["Id_Proveedor"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Correo = reader["Correo"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los Proveedores: {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }




        public int Registrar(Proveedor proveedores, out string Mensaje)
        {
            int Id_ProveedorGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARPROVEEDOR", con);
                    cmd.Parameters.AddWithValue("Nombre", proveedores.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", proveedores.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", proveedores.Telefono);
                    cmd.Parameters.AddWithValue("Correo", proveedores.Correo);
                    cmd.Parameters.Add("Id_ProveedorResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_ProveedorGenerado = Convert.ToInt32(cmd.Parameters["Id_ProveedorResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                Id_ProveedorGenerado = 0;
                Mensaje = ex.Message;


            }

            return Id_ProveedorGenerado;



        }







        public bool Editar(Proveedor proveedores, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARPROVEEDOR", con);
                    cmd.Parameters.AddWithValue("Id_Proveedor", proveedores.Id_Proveedor);
                    cmd.Parameters.AddWithValue("Nombre", proveedores.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", proveedores.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", proveedores.Telefono);
                    cmd.Parameters.AddWithValue("Correo", proveedores.Correo);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;


            }

            return respuesta;



        }


        public bool Eliminar(Proveedor proveedores, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARPROVEEDOR", con);
                    cmd.Parameters.AddWithValue("Id_Proveedor", proveedores.Id_Proveedor);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }

            return respuesta;

        }



    }
}
