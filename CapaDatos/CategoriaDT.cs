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
   public  class CategoriaDT
    {
       
           public List<Categoria> listar()
            {
                List<Categoria> lista = new List<Categoria>();

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    try
                    {
                        string query = "Select Id_Categoria,Nombre,Descripcion from Categoria";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Categoria
                                {
                                    Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString()

                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar las categorias, 'Motivo': {ex.Message}, por favor inténtelo de nuevo.");
                        lista = new List<Categoria>();
                    }
                }
                return lista;
            }




            public int Registrar(Categoria categorias, out string Mensaje)
            {
                int Id_CategoriaGenerado = 0;
                Mensaje = string.Empty;

                try
                {
                    using (SqlConnection con = new SqlConnection(Conexion.con))
                    {

                        SqlCommand cmd = new SqlCommand("PS_REGISTRARCATEGORIA", con);
                        cmd.Parameters.AddWithValue("Nombre", categorias.Nombre);
                        cmd.Parameters.AddWithValue("Descripcion", categorias.Descripcion);
                       
                        cmd.Parameters.Add("Id_CategoriaResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        Id_CategoriaGenerado = Convert.ToInt32(cmd.Parameters["Id_CategoriaResultado"].Value);
                        Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    }


                }
                catch (Exception ex)
                {
                    Id_CategoriaGenerado = 0;
                    Mensaje = ex.Message;


                }

                return Id_CategoriaGenerado;



            }


        public Categoria ObtenerPorId(int idCategoria)
        {
            Categoria categoria = null;

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    string query = "SELECT Id_Categoria, Nombre, Descripcion FROM Categoria WHERE Id_Categoria = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCategoria);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria()
                            {
                                Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la categoría por ID. Motivo: {ex.Message}");
                    categoria = null;
                }
            }

            return categoria;
        }





        public bool Editar(Categoria categorias, out string Mensaje)
            {
                bool respuesta = false;
                Mensaje = string.Empty;

                try
                {
                    using (SqlConnection con = new SqlConnection(Conexion.con))
                    {
                        SqlCommand cmd = new SqlCommand("PS_EDITARCATEGORIA", con);
                        cmd.Parameters.AddWithValue("Id_Categoria", categorias.Id_Categoria);
                        cmd.Parameters.AddWithValue("Nombre", categorias.Nombre);
                        cmd.Parameters.AddWithValue("Descripcion", categorias.Descripcion);
                        
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


            public bool Eliminar(Categoria categorias, out string Mensaje)
            {
                bool respuesta = false;
                Mensaje = string.Empty;

                try
                {
                    using (SqlConnection con = new SqlConnection(Conexion.con))
                    {
                        SqlCommand cmd = new SqlCommand("PS_ELIMINARCATEGORIA", con);
                        cmd.Parameters.AddWithValue("Id_Categoria", categorias.Id_Categoria);
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
