using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class VentaDT
    {


        public int ObtenerCorrelativo()
        {
            int Idcorrelativo = 0;



            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    string query = "Select Count(*)+1 from Venta";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    Idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception)
                {

                    Idcorrelativo = 0;
                }
            }
            return Idcorrelativo;


        }



        public Stock ObtenerStockCompleto(int Id_Producto)
        {
            Stock stock = null;
            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT s.Id_Stock, s.Id_Producto, s.CantidadBase");
                    query.AppendLine("FROM Stock s");
                    query.AppendLine("WHERE s.Id_Producto = @Id_Producto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@Id_Producto", Id_Producto);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stock = new Stock()
                            {
                                Id_Stock = Convert.ToInt32(reader["Id_Stock"]),
                                oProducto = new Producto() { Id_Producto  =  Convert.ToInt32(reader["Id_Producto"])},
                                CatidadBase = Convert.ToInt32(reader["CantidadBase"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener el stock: {ex.Message}");
                }
            }
            return stock;
        }

        /*
        public bool obtenerStock(int Id_Producto, out int CantidadBase)
        {
            CantidadBase = 0; // Inicializar CantidadBase a un valor predeterminado
            bool exito = false; // Usar una variable para indicar el éxito

            using (SqlConnection con = new SqlConnection(Conexion.con)) // Asegúrate de que Conexion.con esté configurada correctamente
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT s.CantidadBase FROM Stock s");
                    query.AppendLine("WHERE s.Id_Producto = @Id_Producto"); // Corregido el JOIN innecesario

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@Id_Producto", Id_Producto);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Usar ExecuteReader para obtener resultados
                    {
                        if (reader.Read()) // Verificar si hay resultados
                        {
                            CantidadBase = Convert.ToInt32(reader["CantidadBase"]); // Obtener el valor de CantidadBase
                            exito = true; // Indicar que la operación fue exitosa
                        }
                        else
                        {
                            exito = false; // Indicar que no se encontró el producto en Stock
                                           // El producto no se encontró en Stock.  Podrías querer registrar este evento.
                        }
                    }
                }
                catch (Exception ex) // Capturar la excepción y registrarla
                {
                    Console.WriteLine($"Error al obtener el stock: {ex.Message}"); // Log the error
                    exito = false;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close(); // Asegurarse de que la conexión se cierre incluso si hay una excepción
                    }
                }
            }

            return exito; // Devolver el indicador de éxito
        }


        */

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;



            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("REGISTRARVENTA", con);
                    cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.Id_Usuario);                   
                    cmd.Parameters.AddWithValue("Total", obj.Total);
                    cmd.Parameters.AddWithValue("Detalleventa", DetalleVenta);
                    cmd.Parameters.AddWithValue("NumVenta", obj.NumVenta);  
                    cmd.Parameters.AddWithValue("Descuento",obj.Descuento);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();



                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
                catch (Exception ex)
                {

                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;


        }



        public Venta obtnerventa(string numero)
        {

            Venta obj = new Venta();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {

                    con.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select v.Id_Venta,");
                    query.AppendLine("u.Nombre,");
                    query.AppendLine("v.Descuento,");
                    query.AppendLine("v.Total,v.NumVenta,CONVERT(Char(10),Fecha,103)[FechaRegistro]");
                    query.AppendLine("from Venta v ");
                    query.AppendLine("inner join Usuario u on u.Id_Usuario= v.Id_Usuario");
                    query.AppendLine("where v.Id_Venta = @numero");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new Venta()
                        {
                            Id_Venta = Convert.ToInt32(reader["Id_Venta"]),
                            oUsuario = new Usuario() { Nombre = reader["Nombre"].ToString() },
                            Descuento = Convert.ToDecimal(reader["Descuento"].ToString()),
                            Total = Convert.ToDecimal(reader["Total"].ToString()),
                            Fecha = reader["FechaRegistro"].ToString()

                        };
                    }
                }
                catch (Exception )
                {
                    obj = new Venta();
                }
            }
                        
            return obj;
        }



        public List<DetalleVenta> ObtenerDetalleVenta(int Id_Venta)
        {
            List<DetalleVenta> oLista = new List<DetalleVenta>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select a.Nombre, dv.PrecioUnitario,dv.Catidad,dv.SubTotal");
                    query.AppendLine("from DetalleVenta dv");
                    query.AppendLine("inner join Producto p on p.Id_Producto = dv.Id_Producto");
                    query.AppendLine("inner join Articulo a on a.Id_Articulo = p.Id_Articulo");
                    query.AppendLine("inner join Venta v on v.Id_Venta = dv.Id_Venta");
                    query.AppendLine("where dv.Id_Venta= @Id_Venta ");
                  

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@Id_Venta", Id_Venta);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        oLista.Add(new DetalleVenta()
                        {
                            oProducto = new Producto()
                            {
                                oArticulo = new Articulo()
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                }
                            },
                            Cantidad = Convert.ToInt32(reader["Catidad"].ToString()),

                            PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"].ToString()),
                          
                            SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),

                        });
                    }
                }

            }
            catch (Exception)
            {

                oLista = new List<DetalleVenta>();
            }





            return oLista;


        }

    }


}

