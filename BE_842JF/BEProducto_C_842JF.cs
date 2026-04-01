using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEProducto_C_842JF
    {
        public int idCambio_842JF { get; set; }
        public int codProducto_842JF { get; set; }
        public DateTime fecha_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public int cantidad_842JF { get; set; }
        public string descripcion_842JF { get; set; }
        public decimal precioCompra_842JF { get; set; }
        public string medida_842JF { get; set; }
        public bool disponible_842JF { get; set; }
        public bool activo_842JF { get; set; }
        public BEProducto_C_842JF(int id)
        {
            idCambio_842JF = id;
        }
        public BEProducto_C_842JF(int id, int codP,DateTime fecha, string nombre, int cant, string desc,decimal preCom,string med,bool dispo, bool act):this(id)
        {
            codProducto_842JF = codP;
            fecha_842JF = fecha;
            nombre_842JF = nombre;
            cantidad_842JF = cant;
            descripcion_842JF = desc;
            precioCompra_842JF = preCom;
            medida_842JF = med;
            disponible_842JF = dispo;
            activo_842JF = act;
        }
    }
}
