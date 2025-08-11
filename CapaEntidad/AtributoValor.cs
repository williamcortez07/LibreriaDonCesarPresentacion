using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class AtributoValor
    {
        public int Id_Valor {  get; set; }
        public Atributo oAtributo { get; set; }
        public string ValorTexto { get; set; }
    }
}
