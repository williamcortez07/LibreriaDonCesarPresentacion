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
    public class ArticuloDT
    {
        public List<Articulo> Listar()
        {
            List<Articulo> articulos = new List<Articulo>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    con.Open();
                    string query = "Select Id_Articulo,Nombre from Articulo";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Articulo articulo = new Articulo
                        {
                            Id_Articulo = Convert.ToInt32(reader["Id_Articulo"]),
                            Nombre = reader["Nombre"].ToString()
                        };
                        articulos.Add(articulo);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocuurido un error al obtener los artículos " + ex);
                }
                return articulos;
            }
        }

        public int Registrar(Articulo articulos, out string Mensaje)
        {
            int  Id_ArticuloGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {                  
                    SqlCommand cmd = new SqlCommand("PS_REGISTRARARTICULO", con);
                    cmd.Parameters.AddWithValue("@Nombre", articulos.Nombre);
                    cmd.Parameters.Add("Id_ArticuloResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_ArticuloGenerado = Convert.ToInt32(cmd.Parameters["Id_ArticuloResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Id_ArticuloGenerado = 0;
                Mensaje = ex.Message;
            }

            return Id_ArticuloGenerado;
        }


        public bool Editar(Articulo articulos, out string Mensaje)
        { 
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {                    
                    SqlCommand cmd = new SqlCommand("PS_EDITARARTICULO", con);
                    cmd.Parameters.AddWithValue("@Id_Articulo", articulos.Id_Articulo);
                    cmd.Parameters.AddWithValue("@Nombre", articulos.Nombre);
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



        public bool Eliminar(Articulo articulos, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                  
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARARTICULO", con);
                    cmd.Parameters.AddWithValue("@Id_Articulo",articulos.Id_Articulo);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex )
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }

}

