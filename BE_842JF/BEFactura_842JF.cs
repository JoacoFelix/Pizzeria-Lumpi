using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEFactura_842JF
    {
        public BEFactura_842JF() { }
        public BEFactura_842JF(int nroFactura_842JF, DateTime fecha_842JF, string medioDePago_842JF, BEPedido_842JF pedido_842JF)
        {
            this.nroFactura_842JF = nroFactura_842JF;
            this.fecha_842JF = fecha_842JF;
            this.medioDePago_842JF = medioDePago_842JF;
            this.pedido_842JF = pedido_842JF;
        }


        public int nroFactura_842JF { get; set; }
        public DateTime fecha_842JF { get; set; }
        public string  medioDePago_842JF { get; set; }
        public BEPedido_842JF pedido_842JF { get; set; }
        public decimal total_842JF { get; set; }
    }

}
