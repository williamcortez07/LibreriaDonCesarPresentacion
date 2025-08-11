using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
   public class NegocioDT
    {

        public Negocio ObtenerDatos() {
        
         Negocio obj = new Negocio();


            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    con.Open();
                    string query = "Select Id_Negocio, Nombre, RUC, Direccion FROM Negocio WHERE Id_Negocio = 1";
                    SqlCommand cmd = new SqlCommand(query, con); 
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            obj = new Negocio()
                            {
                                Id_Negocio = int.Parse((reader["Id_negocio"]).ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                RUC = reader["RUC"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            };
                        }
                    }

                }


            }
            catch (Exception)
            {

                obj = new Negocio();
            }
            return obj;
        }


        public bool Guardar(Negocio objet, out string mensaje )
        {

            mensaje = string.Empty;
            bool respuesta = true;


            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    con.Open();
                   
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Negocio SET Nombre = @Nombre,");
                    query.AppendLine("RUC = @RUC,");
                    query.AppendLine("Direccion = @Direccion");
                    query.AppendLine("WHERE Id_Negocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    
                    cmd.Parameters.AddWithValue("@Nombre",objet.Nombre);
                    cmd.Parameters.AddWithValue("@RUC", objet.RUC);
                    cmd.Parameters.AddWithValue("@Direccion", objet.Direccion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo guardar los datos";
                        respuesta = false;
                    }                  
                }
            }

            catch (Exception ex)
            {
                mensaje =   ex.Message;
                respuesta = false;

            }

           return respuesta;

        }

        public byte[] Logo(out bool obtenido)
        {
            obtenido = true;
            byte[] byteLogo = new byte[0];

            
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    con.Open();

                    string query = "Select Logo FROM Negocio WHERE Id_Negocio = 1";

                    SqlCommand cmd = new SqlCommand(query, con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            byteLogo = (byte[])reader["Logo"];


                            
                        }
                    }


                }
            }

            catch (Exception )
            {
               obtenido = false;
               byteLogo = new byte[0];

            }

            return byteLogo;


        }



        public bool actualizarLogo(byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;


            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    con.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Negocio SET Logo = @imagen");                   
                    query.AppendLine("WHERE Id_Negocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);

                    cmd.Parameters.AddWithValue("@imagen",imagen);
                   
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo Actualizar la imagen";
                        respuesta = false;
                    }
                }
            }

            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;

            }

            return respuesta;


        }

    }
}
