using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class StockDT
    {



        public List<Stock> Listar()
        {
            List<Stock> stock = new List<Stock>();

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                try
                {
                    con.Open();
                   StringBuilder query = new StringBuilder();
                    query.AppendLine(" select s.Id_Stock, a.Nombre, s.CantidadBase,");
                    query.AppendLine("s.PrecioC, s.PrecioV");
                    query.AppendLine("from stock s ");
                    query.AppendLine("inner join Producto p on p.Id_Producto = s.Id_Producto");
                    query.AppendLine("inner join Articulo a on a.Id_Articulo = p.Id_Articulo");
                  
                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    ;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Stock Stock = new Stock
                        {
                            Id_Stock = Convert.ToInt32(reader["Id_Stock"]),
                            oProducto = new Producto() { oArticulo = new Articulo{Nombre = reader["Nombre"].ToString()} },
                            CatidadBase =Convert.ToInt32 (reader["CantidadBase"].ToString()),
                            PrecioC = Convert.ToDecimal(reader["PrecioC"].ToString()),
                            PrecioV = Convert.ToDecimal(reader["PrecioV"].ToString()),
                        };
                        stock.Add(Stock);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lo sentimos, ha ocuurido un error al obtener el stock " + ex);
                }
                return stock;
            }
        }

    }
}
