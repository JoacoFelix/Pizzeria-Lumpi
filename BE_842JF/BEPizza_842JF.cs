using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public abstract class BEPizza_842JF
    {
        public BEPizza_842JF(int codPizza,string descripcion,string nombre_842JF, decimal precio_842JF)
        {
            this.codPizza_842JF = codPizza;
            this.descripcion_842JF = descripcion;
            this.nombre_842JF = nombre_842JF;
            this.precio_842JF = precio_842JF;
            productos = new Dictionary<BEProducto_842JF, int>();
        }
        public int codPizza_842JF { get; set; }
        public string descripcion_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public decimal precio_842JF { get; set; }
        public Dictionary<BEProducto_842JF,int> productos;
    }
}
