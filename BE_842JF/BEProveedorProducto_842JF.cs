using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEProveedorProducto_842JF
    {
        public int codProducto_842JF { get; set; }
        public string CUIT_842JF { get; set; }
        public BEProveedorProducto_842JF(int cod, string cuit)
        {
            codProducto_842JF = cod;
            CUIT_842JF = cuit;
        }
    }
}
