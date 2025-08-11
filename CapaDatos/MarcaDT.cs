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
    public class MarcaDT
    {
        public List<Marca> Listar()
        {

            List<Marca> marcas = new List<Marca>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {

                try
                {
                    con.Open();
                    string query = "SELECT Id_Marca, Nombre FROM Marca";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                       Marca marca = new Marca()
                        {
                            Id_Marca = Convert.ToInt32(reader["Id_Marca"]),
                            Nombre = reader["Nombre"].ToString(),
                        };

                        marcas.Add(marca);
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocurrido un error al cargar las marcas " + ex);
                }


            }

            return marcas;

        }


        public int Registrar(Marca marcas, out string Mensaje)
        {
            int Id_MarcaGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_REGISTRARMARCA", con);
                    cmd.Parameters.AddWithValue("@Nombre", marcas.Nombre);
                    cmd.Parameters.Add("Id_MarcaResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_MarcaGenerado = Convert.ToInt32(cmd.Parameters["Id_MarcaResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Id_MarcaGenerado = 0;
                Mensaje = ex.Message;

            }


            return Id_MarcaGenerado;
        }



        public bool Editar(Marca marcas, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARMARCA", con);
                    cmd.Parameters.AddWithValue("@Id_Marca", marcas.Id_Marca);
                    cmd.Parameters.AddWithValue("@Nombre", marcas.Nombre);
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



        public bool Eliminar(Marca marcas, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_ELIMINARMARCA", con);
                    cmd.Parameters.AddWithValue("@Id_Marca", marcas.Id_Marca);
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

