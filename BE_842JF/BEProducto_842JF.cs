using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEProducto_842JF
    {
        public int codProducto_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public string descripcion_842JF { get; set; }
        public decimal precioCompra_842JF { get; set; }
        public string medida_842JF { get; set; }
        public int cantidad_842JF { get; set; }
        public bool disponible_842JF { get; set; }
        public BEProducto_842JF(int codProd)
        {
            codProducto_842JF = codProd;
        }
        public BEProducto_842JF(int codProd,string nom, string desc, decimal compra, int cant, string med, bool dispo) : this(codProd)
        {
            nombre_842JF = nom;
            descripcion_842JF = desc;
            precioCompra_842JF = compra;
            cantidad_842JF = cant;
            medida_842JF = med;
            disponible_842JF = dispo;
        }
        public override string ToString()
        {
            return $"{nombre_842JF}";
        }
    }
}
