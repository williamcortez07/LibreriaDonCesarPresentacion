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
    public class ReportesDT
    {

        public List<ReportesCompra> Compras( string fechainicio, string fechafin, int id_proveedor)
        {
          //  string formatoFecha = "dd/MM/yyyy";

            List<ReportesCompra> lista = new List<ReportesCompra>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_ReporteCompras", con);
                    cmd.Parameters.AddWithValue("Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("Fechafin", fechafin);
                    cmd.Parameters.AddWithValue("Id_Proveedor",id_proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReportesCompra
                            {

                                fecha = reader["fecharegistro"].ToString(),
                                NumCompra = reader["NumCompra"].ToString(),
                                Total = reader["Total"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                NomProveedor = reader["NomProveedor"].ToString(),
                                ApeProveedor= reader["ApeProveedor"].ToString(),
                                NomProducto = reader["NomProducto"].ToString(),
                                PrecioC = reader["PrecioC"].ToString(),
                                PrecioV = reader["PrecioV"].ToString(),
                                Cantidad = reader["Catidad"].ToString(),
                                SubTotal = reader["SubTotal"].ToString(),
                                nomSubCategoria = reader["nomSubCategoria"].ToString(),
                                nomColor = reader["NomColor"].ToString(),
                                nomMarca = reader["NomMarca"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los reportes de Compras, 'Motivo': {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<ReportesCompra>();
                }
            }
            return lista;
        }



        public List<ReportesVenta> Ventas(string fechainicio, string fechafin)
        {
            List<ReportesVenta> lista = new List<ReportesVenta>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                  

                    SqlCommand cmd = new SqlCommand("SP_ReporteVentas", con);
                    cmd.Parameters.AddWithValue("Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("Fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReportesVenta
                            {

                                fecha = reader["fecharegistro"].ToString(),
                                NumVenta = reader["NumVenta"].ToString(),
                                Total = reader["Total"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                NomProducto = reader["NomProducto"].ToString(),
                                PrecioC = reader["PrecioC"].ToString(),
                                PrecioV = reader["PrecioV"].ToString(),
                                Cantidad = reader["Catidad"].ToString(),
                                SubTotal = reader["SubTotal"].ToString(),
                                nomSubCategoria = reader["nomSubCategoria"].ToString(),
                                nomColor = reader["nomColor"].ToString(),
                                nomMarca = reader["nomMarca"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los Reportes de Ventas, 'Motivo': {ex.Message}, por favor inténtelo de nuevo.");
                    lista = new List<ReportesVenta>();
                }
            }
            return lista;
        }



    }
}
