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
    public class PermisosDT
    {
        public List<Permiso> listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.Id_Usuario, p.NombrePantalla from Permiso p");
                    query.AppendLine("inner join Usuario u on u.Id_Usuario = p.Id_Usuario");
                    query.AppendLine("Where u.Id_Usuario = @Id_Usuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.Parameters.AddWithValue("@Id_Usuario",idUsuario);
                    cmd.CommandType = CommandType.Text;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            lista.Add(new Permiso ()
                            {
                               oUsuario = new Usuario() { Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]) },
                                NombrePantalla = reader["NombrePantalla"].ToString(),
                                

                            });



                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los Permisos, 'Motivo': {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<Permiso>();
                }


            }

            return lista;


        }
    }
}
