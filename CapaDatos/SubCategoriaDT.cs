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
    public class SubCategoriaDT
    {



        public List<SubCategoria> listar()
        {
            List<SubCategoria> lista = new List<SubCategoria>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine(" select Id_SubCat, s.Nombre, c.Id_Categoria,c.Nombre[NombreCategoria], c.Descripcion from SubCategoria s");
                    query.AppendLine("inner join Categoria c on c.Id_Categoria = s.Id_Categoria ");
              
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SubCategoria()
                            {
                                Id_SubCat = Convert.ToInt32(reader["Id_SubCat"]),
                                Nombre = reader["Nombre"].ToString(),
                                oId_Categoria = new Categoria() { Id_Categoria = Convert.ToInt32(reader["Id_Categoria"]), Descripcion = reader["Descripcion"].ToString(), Nombre = reader["NombreCategoria"].ToString() },
                            });                                                  
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las Subcategorias: {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<SubCategoria>();
                }
            }
            return lista;
        }




        public int Registrar(SubCategoria subcategorias, out string Mensaje)
        {
            int Id_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {

                    SqlCommand cmd = new SqlCommand("PS_REGISTRARSUBCATEGORIA", con);
                    cmd.Parameters.AddWithValue("Nombre", subcategorias.Nombre);
                    cmd.Parameters.AddWithValue("Id_Categoria",subcategorias.oId_Categoria.Id_Categoria);

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







        public bool Editar(SubCategoria subcategorias, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_EDITARSUBCATEGORIA", con);
                    cmd.Parameters.AddWithValue("Id_SubCat", subcategorias.Id_SubCat);
                    cmd.Parameters.AddWithValue("Nombre", subcategorias.Nombre);
                    cmd.Parameters.AddWithValue("Id_Categoria", subcategorias.oId_Categoria.Id_Categoria);

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


        public bool Eliminar(SubCategoria subcategorias, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    SqlCommand cmd = new SqlCommand("PS_ELIMINARSUBCATEGORIA", con);
                    cmd.Parameters.AddWithValue("Id_SubCat", subcategorias.Id_SubCat);
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
