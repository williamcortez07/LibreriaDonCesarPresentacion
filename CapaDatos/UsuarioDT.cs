using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CapaDatos
{
    public  class UsuarioDT
    {
        public List<Usuario> listar()
        { 
            List<Usuario> lista = new List<Usuario>();  

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    string query = "Select Id_Usuario,Nombre,Clave,Rol from Usuario";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Rol = reader["Rol"].ToString()

                            });
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los usuarios, 'Motivo': { ex.Message }, por favor inténtelo de nuevo.");
                   lista = new List<Usuario>();
                }
            }
            return lista;
        }




        public int Registrar( Usuario usuarios, out string Mensaje)
        {
            int Id_UsuarioGenerado= 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARUSUARIO", con);
                    cmd.Parameters.AddWithValue("Nombre", usuarios.Nombre);
                    cmd.Parameters.AddWithValue("Clave",usuarios.Clave);
                    cmd.Parameters.AddWithValue("Rol",usuarios.Rol);
                    cmd.Parameters.Add("Id_UsuarioResultado" ,SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_UsuarioGenerado = Convert.ToInt32(cmd.Parameters["Id_UsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                Id_UsuarioGenerado = 0;
                Mensaje = ex.Message;

               
            }

            return Id_UsuarioGenerado;



        }







        public bool Editar(Usuario usuarios,out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARUSUARIO", con);
                    cmd.Parameters.AddWithValue("Id_Usuario", usuarios.Id_Usuario);
                    cmd.Parameters.AddWithValue("Nombre",usuarios.Nombre);
                    cmd.Parameters.AddWithValue("Clave", usuarios.Clave);
                    cmd.Parameters.AddWithValue("Rol", usuarios.Rol);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
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


        public bool Eliminar(Usuario usuarios, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARUSUARIO", con);
                    cmd.Parameters.AddWithValue("Id_Usuario", usuarios.Id_Usuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
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
