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
    public class BajaInventarioDT
    {

        

        public List<BajaInventario> listar()
        {
            List<BajaInventario> lista = new List<BajaInventario>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {                   
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Id_Baja, Cantidad, Motivo, Convert (Char(10), bi.Fecha,103)[fecha], p.Id_Producto, a.Nombre from BajaInventario bi");
                    query.AppendLine("inner join Producto p on p.Id_Producto = bi.Id_Producto");
                    query.AppendLine("left join  Articulo a on a.Id_Articulo = p.Id_Articulo");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BajaInventario
                            {
                                Id_Baja = Convert.ToInt32(reader["Id_Baja"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Motivo = reader["Motivo"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                oProducto = new Producto() { Id_Producto = Convert.ToInt32( reader["Id_Producto"].ToString()), oArticulo = new Articulo { Nombre = reader["Nombre"].ToString() }  }
                               
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las BajaInventarioes: {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<BajaInventario>();
                }
            }
            return lista;
        }




        public int Registrar(BajaInventario BajaInventarioes, out string Mensaje)
        {
            int Id_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARBAJA", con);
                    cmd.Parameters.AddWithValue("Cantidad", BajaInventarioes.Cantidad);
                    cmd.Parameters.AddWithValue("Motivo", BajaInventarioes.Motivo);
                    cmd.Parameters.AddWithValue("Id_Producto", BajaInventarioes.oProducto.Id_Producto);

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







        public bool Editar(BajaInventario BajaInventarioes, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARBAJA", con);
                    cmd.Parameters.AddWithValue("Id_Baja", BajaInventarioes.Id_Baja);
                    cmd.Parameters.AddWithValue("Cantidad", BajaInventarioes.Cantidad);
                    cmd.Parameters.AddWithValue("Motivo", BajaInventarioes.Motivo);
                    cmd.Parameters.AddWithValue("Id_Producto", BajaInventarioes.oProducto.Id_Producto);

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


        public bool Eliminar(BajaInventario BajaInventarioes, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARBAJA", con);
                    cmd.Parameters.AddWithValue("Id_Baja", BajaInventarioes.Id_Baja);
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
