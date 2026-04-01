using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEPedidoPizza_842JF
    {
        public BEPedidoPizza_842JF(int codPizza_842JF, int nroPedido_842JF, int cantidad_842JF)
        {
            this.codPizza_842JF = codPizza_842JF;
            this.nroPedido_842JF = nroPedido_842JF;
            this.cantidad_842JF = cantidad_842JF;
        }

        public int codPizza_842JF { get; set; }
        public int nroPedido_842JF { get; set; }
        public int cantidad_842JF { get; set; }
    }
}
