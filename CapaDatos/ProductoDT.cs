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
    public class ProductoDT
    {




        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {      
                    StringBuilder query = new StringBuilder();
                    query.AppendLine(" SELECT P.Id_Producto, P.Id_Articulo, P.Id_Marca, P.Id_Color, P.Id_SubCat, P.Id_Presentacion,p.Descripcion,s.CantidadBase,");
                    query.AppendLine("A.Nombre AS NombreArticulo,"); 
                    query.AppendLine("ISNULL(M.Nombre, '') AS NombreMarca, ");
                    query.AppendLine("ISNULL(C.Nombre, '') AS NombreColor, ");
                    query.AppendLine("ISNULL(SC.Nombre, '') AS NombreSubCategoria, ");
                    query.AppendLine("ISNULL(PR.Nombre, '') AS NombrePresentacion ");
                    query.AppendLine("FROM Producto P ");
                    query.AppendLine("INNER JOIN Articulo A ON P.Id_Articulo = A.Id_Articulo");
                    query.AppendLine("LEFT JOIN Marca M ON P.Id_Marca = M.Id_Marca ");
                    query.AppendLine("LEFT JOIN Color C ON P.Id_Color = C.Id_Color ");
                    query.AppendLine("LEFT JOIN SubCategoria SC ON P.Id_SubCat = SC.Id_SubCat");
                    query.AppendLine("LEFT JOIN Presentacion PR ON P.Id_Presentacion = PR.Id_Presentacion");
                    query.AppendLine("LEFT JOIN Stock s ON P.Id_Producto = s.Id_Producto");
                    // agregar la cantidad base para que no hayan problemas
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto()
                            {
                                Id_Producto = Convert.ToInt32(reader["Id_Producto"]),
                                oArticulo = new Articulo() { Id_Articulo = Convert.ToInt32(reader["Id_Articulo"]), Nombre = reader["NombreArticulo"].ToString() },
                                oMarca = new Marca() { Id_Marca = Convert.ToInt32(reader["Id_Marca"]), Nombre = reader["NombreMarca"].ToString() },
                                oColor = new Colores() { Id_Color = Convert.ToInt32(reader["Id_Color"]), Nombre = reader["NombreColor"].ToString() },
                                osubCategoria = new SubCategoria() { Id_SubCat = Convert.ToInt32(reader["Id_SubCat"]), Nombre = reader["NombreSubCategoria"].ToString() },
                                oPresentacion = new Presentacion() { Id_Presentacion = Convert.ToInt32(reader["Id_Presentacion"]), Nombre = reader["NombrePresentacion"].ToString() },
                                stock = new Stock() { CatidadBase = Convert.ToInt32(reader["CantidadBase"])},
                                Descripcion = reader["Descripcion"].ToString(),                            
                            
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los Productos: {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<Producto>();
                }
            }
            return lista;
        }




        public int Registrar(Producto Productos, out string Mensaje)
        {
            int Id_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARPRODUCTO", con);
                    cmd.Parameters.AddWithValue("Id_Articulo", Productos.oArticulo.Id_Articulo);
                    cmd.Parameters.AddWithValue("Id_Marca", Productos.oMarca.Id_Marca);
                    cmd.Parameters.AddWithValue("Id_Color", Productos.oColor.Id_Color);
                    cmd.Parameters.AddWithValue("Id_SubCat", Productos.osubCategoria.Id_SubCat);
                    cmd.Parameters.AddWithValue("Id_Presentacion", Productos.oPresentacion.Id_Presentacion);
                    // incluir el stock para registrar 0 por defecto
                    cmd.Parameters.AddWithValue("Descripcion", Productos.Descripcion);

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







        public bool Editar(Producto Productos, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARPRODUCTO", con);
                    cmd.Parameters.AddWithValue("Id_Producto", Productos.Id_Producto);
                    cmd.Parameters.AddWithValue("Id_Articulo", Productos.oArticulo.Id_Articulo);
                    cmd.Parameters.AddWithValue("Id_Marca", Productos.oMarca.Id_Marca);
                    cmd.Parameters.AddWithValue("Id_Color", Productos.oColor.Id_Color);
                    cmd.Parameters.AddWithValue("Id_SubCat", Productos.osubCategoria.Id_SubCat);
                    cmd.Parameters.AddWithValue("Id_Presentacion", Productos.oPresentacion.Id_Presentacion);
                    cmd.Parameters.AddWithValue("Descripcion", Productos.Descripcion);

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


        public bool Eliminar(Producto Productos, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARPRODUCTO", con);
                    cmd.Parameters.AddWithValue("Id_Producto", Productos.Id_Producto);
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
