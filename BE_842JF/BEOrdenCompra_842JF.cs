using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEOrdenCompra_842JF
    {
        public int codOrdenCompra_842JF { get; set; }
        public DateTime fecha_842JF { get; set; }
        public BEProducto_842JF producto_842JF { get; set; }
        public BEProveedor_842JF proveedor_842JF { get; set; }
        public decimal precioUnitario_842JF { get; set; }
        public int cantidad_842JF { get; set; }
        public bool recibida_842JF { get; set; }
        public bool pago_842JF { get; set; }
        public BEOrdenCompra_842JF(int codOrden)
        {
            codOrdenCompra_842JF = codOrden;
        }
        public BEOrdenCompra_842JF(int codOrden, DateTime fecha, BEProducto_842JF prod, BEProveedor_842JF prov,decimal pu, int cant, bool rec, bool pag) : this(codOrden)
        {
            fecha_842JF = fecha;
            producto_842JF = prod;
            proveedor_842JF = prov;
            precioUnitario_842JF = pu;
            cantidad_842JF = cant;
            recibida_842JF = rec;
            pago_842JF = pag;
        }
    }
}
