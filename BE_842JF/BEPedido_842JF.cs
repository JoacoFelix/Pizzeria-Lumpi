using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEPedido_842JF
    {
       

        public BEPedido_842JF() { }
        public BEPedido_842JF(int nroPedido)
        {
            nroPedido_842JF = nroPedido;
        }

        public BEPedido_842JF(int nroPedido, BECliente_842JF cliente, string estado, bool pago) : this(nroPedido)
        {
            cliente_842JF = cliente;
            estado_842JF = estado;
            pago_842JF = pago;
        }

        public BEPedido_842JF(int nroPedido, BECliente_842JF cliente, string estado, List <BEPizza_842JF> pizzas, bool pago) : this(nroPedido,cliente,estado,pago) 
        {
            pizzas_842JF = pizzas;
            foreach (var p in pizzas)
            {
                total_842JF += p.precio_842JF;
            }
        }

        public int nroPedido_842JF { get; set; }
        public BECliente_842JF cliente_842JF { get; set; }
        public string estado_842JF { get; set; }
        public List<BEPizza_842JF> pizzas_842JF { get; set; }
        public decimal total_842JF { get; set; }
        public bool pago_842JF { get; set; }
    }
}
