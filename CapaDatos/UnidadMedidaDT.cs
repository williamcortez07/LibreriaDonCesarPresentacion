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
    public class UnidadMedidaDT
    {


        public List<UnidadMedida> Listar()
        {
            List<UnidadMedida> UnidadMedidas = new List<UnidadMedida>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    con.Open();
                    string query = "Select Id_Unidad,Nombre from UnidadMedida";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UnidadMedida UnidadMedida = new UnidadMedida
                        {
                            Id_Unidad = Convert.ToInt32(reader["Id_Unidad"]),
                            Nombre = reader["Nombre"].ToString()
                        };
                        UnidadMedidas.Add(UnidadMedida);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocuurido un error al obtener las Unidades de Medición " + ex);
                }
                return UnidadMedidas;
            }
        }

        public int Registrar(UnidadMedida UnidadMedidas, out string Mensaje)
        {
            int Id_Generado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_REGISTRARUNIDAD", con);
                    cmd.Parameters.AddWithValue("@Nombre", UnidadMedidas.Nombre);
                    cmd.Parameters.Add("Id_Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Id_Generado = Convert.ToInt32(cmd.Parameters["Id_Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Id_Generado = 0;
                Mensaje = ex.Message;
            }

            return Id_Generado;
        }


        public bool Editar(UnidadMedida UnidadMedidas, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARUNIDAD", con);
                    cmd.Parameters.AddWithValue("@Id_Unidad", UnidadMedidas.Id_Unidad);
                    cmd.Parameters.AddWithValue("@Nombre", UnidadMedidas.Nombre);
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



        public bool Eliminar(UnidadMedida UnidadMedidas, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_ELIMINARUNIDAD", con);
                    cmd.Parameters.AddWithValue("@Id_Unidad", UnidadMedidas.Id_Unidad);
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

