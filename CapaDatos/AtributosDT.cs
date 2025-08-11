using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CapaDatos
{
    public class AtributosDT
    {
        public List<Atributo> Listar()
        {

            List<Atributo> atributos = new List<Atributo>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {

                try
                {
                    con.Open();
                    string query = "SELECT Id_Atributo, Nombre FROM Atributo";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Atributo atributo = new Atributo()
                        {
                            Id_Atributo = Convert.ToInt32(reader["Id_Atributo"]),
                            Nombre = reader["Nombre"].ToString(),
                        };

                        atributos.Add(atributo);
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocurrido un error al cargar los atributos " + ex);
                }


            }

            return atributos;

        }


        public int Registrar(Atributo atributos, out string Mensaje)
        {
            int Id_AtributoGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_REGISTRARATRIBUTO", con);
                    cmd.Parameters.AddWithValue("@Nombre", atributos.Nombre);
                    cmd.Parameters.Add("Id_AtributoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_AtributoGenerado = Convert.ToInt32(cmd.Parameters["Id_AtributoResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Id_AtributoGenerado = 0;
                Mensaje = ex.Message;

            }


            return Id_AtributoGenerado;
        }



        public bool Editar(Atributo atributos, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARATRIBUTO", con);
                    cmd.Parameters.AddWithValue("@Id_Atributo", atributos.Id_Atributo);
                    cmd.Parameters.AddWithValue("@Nombre", atributos.Nombre);
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



        public bool Eliminar(Atributo atributos, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_ELIMINARATRIBUTO", con);
                    cmd.Parameters.AddWithValue("@Id_Atributo", atributos.Id_Atributo);
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
