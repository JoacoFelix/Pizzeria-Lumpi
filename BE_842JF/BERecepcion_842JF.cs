using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BERecepcion_842JF
    {
        public int codRecepcion_842JF { get; set; }
        public BEProducto_842JF producto_842JF { get; set; }
        public BEProveedor_842JF proveedor_842JF { get; set; }
        public int cantidad_842JF { get; set; }
        public DateTime fecha_842JF { get; set; }
        public string descripcion_842JF { get; set; }
        public BERecepcion_842JF(int cod)
        {
            codRecepcion_842JF = cod;
        }
        public BERecepcion_842JF(int cod, BEProducto_842JF prod, BEProveedor_842JF prov, int cant, DateTime fech, string desc):this(cod)
        {
            producto_842JF = prod;
            proveedor_842JF = prov;
            cantidad_842JF = cant;
            fecha_842JF = fech;
            descripcion_842JF = desc;
        }
    }
}
