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
    public class ColoresDT
    {

        public List<Colores> Listar()
        {

            List<Colores> colores = new List<Colores>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {

                try
                {
                    con.Open();
                    string query = "SELECT Id_Color, Nombre FROM Color";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Colores color = new Colores()
                        {
                            Id_Color = Convert.ToInt32(reader["Id_Color"]),
                            Nombre = reader["Nombre"].ToString(),
                        };

                        colores.Add(color);
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocurrido un error al cargar los Colores " + ex);
                }


            }

            return colores;

        }


        public int Registrar(Colores colores, out string Mensaje)
        {
            int Id_ColorGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_REGISTRARCOLOR", con);
                    cmd.Parameters.AddWithValue("@Nombre", colores.Nombre);
                    cmd.Parameters.Add("Id_ColorResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_ColorGenerado = Convert.ToInt32(cmd.Parameters["Id_ColorResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Id_ColorGenerado = 0;
                Mensaje = ex.Message;

            }


            return Id_ColorGenerado;
        }



        public bool Editar(Colores colores , out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARCOLOR", con);
                    cmd.Parameters.AddWithValue("@Id_Color", colores.Id_Color);
                    cmd.Parameters.AddWithValue("@Nombre", colores.Nombre);
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



        public bool Eliminar(Colores colores, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_ELIMINARCOLOR", con);
                    cmd.Parameters.AddWithValue("@Id_Color", colores.Id_Color);
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
