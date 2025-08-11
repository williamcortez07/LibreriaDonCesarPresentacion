 using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CompraDT
    {
        public int ObtenerCorrelativo()
        {
            int Idcorrelativo = 0;



            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    string query = "Select Count(*)+1 from Compra";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    Idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception )
                {

                    Idcorrelativo = 0;
                }
            }
            return Idcorrelativo;


        }


        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;



            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCOMPRA", con);
                    cmd.Parameters.AddWithValue("Id_Usuario",obj.oUsuario.Id_Usuario);
                    cmd.Parameters.AddWithValue("Id_Proveedor",obj.oproveedor.Id_Proveedor);
                    cmd.Parameters.AddWithValue("Total",obj.Total);
                    cmd.Parameters.AddWithValue("Numcompra", obj.NumCompra);
                    cmd.Parameters.AddWithValue("DetalleCompra",DetalleCompra);
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


        public Compra ObtenerCompra( string numero)
        {
            Compra obj = new Compra();
            
            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    con.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.Id_Compra,");
                    query.AppendLine("u.Nombre,");
                    query.AppendLine("p.Nombre , p.Apellido,");
                    query.AppendLine("c.Numcompra, c.Total, convert(char(10), c.Fecha, 103)[Fecha]");
                    query.AppendLine(" from Compra c");
                    query.AppendLine("inner join Usuario u on u.Id_Usuario = c.Id_Usuario");
                    query.AppendLine("inner join Proveedor p on p.Id_Proveedor = c.Id_Proveedor");
                    query.AppendLine("where c.Numcompra = @numero");
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@numero",numero);
                    SqlDataReader reader = cmd.ExecuteReader();
               

                    while (reader.Read())
                    {
                        obj = new Compra()
                        {
                            Id_Compra = Convert.ToInt32(reader["Id_Compra"]),
                            oUsuario = new Usuario() { Nombre = reader["Nombre"].ToString() },
                            oproveedor = new Proveedor() { Nombre = reader["Nombre"].ToString(),Apellido = reader["Apellido"].ToString()},
                            NumCompra = reader["Numcompra"].ToString(),
                            Total = Convert.ToDecimal(reader["Total"].ToString()),
                            Fecha = reader["Fecha"].ToString()

                        };
                    }
                }
                catch (Exception )
                {
                    obj = new Compra();

                }
            }
            return obj;
        }

        public List<DetalleCompra> ObtenerDetalleCompra(int Id_Compra)
        {
            List<DetalleCompra> oLista = new List<DetalleCompra>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select");
                    query.AppendLine("a.Nombre, dc.PrecioUnitario,dc.Catidad,dc.SubTotal");
                    query.AppendLine("from DetalleCompra dc");
                    query.AppendLine("inner join Producto p on p.Id_Producto = dc.Id_Producto");
                    query.AppendLine("inner join Articulo a on a.Id_Articulo = p.Id_Articulo");
                    query.AppendLine("inner join Compra c on c.Id_Compra = dc.Id_Compra");
                    query.AppendLine("where dc.Id_Compra = @Id_Compra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@Id_Compra", Id_Compra);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        oLista.Add(new DetalleCompra()
                        {
                            oProducto = new Producto()
                            {
                                oArticulo = new Articulo()
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                }
                            },

                          PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"].ToString()),
                          Cantidad = Convert.ToDecimal(reader["Catidad"].ToString()),
                          SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),

                        });
                    }
                }

            }
            catch (Exception)
            {

                oLista = new List<DetalleCompra>();
            }





            return oLista;


        }

    }


}
