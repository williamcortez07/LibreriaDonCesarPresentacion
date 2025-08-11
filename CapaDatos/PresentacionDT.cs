using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class PresentacionDT
    {



        public List<Presentacion> listar()
        {
            List<Presentacion> lista = new List<Presentacion>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine(" select Id_Presentacion, p.Nombre, p.Cantidad, u.Id_Unidad,u.Nombre[NombreU], FactorUnidad from Presentacion p");
                    query.AppendLine("Inner join UnidadMedida u on u.Id_Unidad = p.Id_Unidad");
                   
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Presentacion
                            {
                                Id_Presentacion = Convert.ToInt32(reader["Id_Presentacion"]),
                                Nombre = reader["Nombre"].ToString(),
                                Cantidad =  Convert.ToDecimal(reader["Cantidad"]),
                                oUnidadMedida = new UnidadMedida() { Id_Unidad = Convert.ToInt32(reader["Id_Unidad"]), Nombre = reader["NombreU"].ToString() },
                                FactorUnidad = reader["FactorUnidad"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las Presentaciones: {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<Presentacion>();
                }
            }
            return lista;
        }




        public int Registrar(Presentacion Presentaciones, out string Mensaje)
        {
            int Id_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARPRESENTACION", con);
                    cmd.Parameters.AddWithValue("Nombre", Presentaciones.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", Presentaciones.Cantidad);
                    cmd.Parameters.AddWithValue("Id_Unidad", Presentaciones.oUnidadMedida.Id_Unidad);
                    cmd.Parameters.AddWithValue("FactorUnidad", Presentaciones.FactorUnidad);

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







        public bool Editar(Presentacion Presentaciones, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARPRESENTACION", con);
                    cmd.Parameters.AddWithValue("Id_Presentacion", Presentaciones.Id_Presentacion);
                    cmd.Parameters.AddWithValue("Nombre", Presentaciones.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", Presentaciones.Cantidad);
                    cmd.Parameters.AddWithValue("Id_Unidad", Presentaciones.oUnidadMedida.Id_Unidad);
                    cmd.Parameters.AddWithValue("FactorUnidad", Presentaciones.FactorUnidad);
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


        public bool Eliminar(Presentacion Presentaciones, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARPRESENTACION", con);
                    cmd.Parameters.AddWithValue("Id_Presentacion", Presentaciones.Id_Presentacion);
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
