using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Stock_N
    {
        private StockDT stock = new StockDT();

        public List<Stock> listar()
        {
            return stock.Listar();
        }


    }
}
