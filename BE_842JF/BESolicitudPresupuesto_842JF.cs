using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BESolicitudPresupuesto_842JF
    {
        public int codSolicitudPresupuesto_842JF { get; set; }
        public BEProducto_842JF producto_842JF { get; set; }
        public BEProveedor_842JF proveedor_842JF { get; set; }
        public DateTime fecha_842JF { get; set; }
        public BESolicitudPresupuesto_842JF(int cod)
        {
            codSolicitudPresupuesto_842JF = cod;
        }
        public BESolicitudPresupuesto_842JF(int cod, BEProducto_842JF prod, BEProveedor_842JF prov, DateTime fecha) : this(cod)
        {
            producto_842JF = prod;
            proveedor_842JF = prov;
            fecha_842JF = fecha;
        }
    }
}
