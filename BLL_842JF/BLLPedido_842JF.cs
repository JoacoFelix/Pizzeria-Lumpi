using BE_842JF;
using DAL_842JF;

namespace BLL_842JF
{
    public class BLLPedido_842JF
    {

        DALPedido_842JF dalpedido_842JF = new DALPedido_842JF();
        BLLCliente_842JF bllcliente = new BLLCliente_842JF();
        BLLPizza_842JF bllpizza = new BLLPizza_842JF();
        BLLProducto_842JF bllproducto = new BLLProducto_842JF();
        BLLPedidoPizza_842JF bllpedidoPizza = new BLLPedidoPizza_842JF();
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public BEPedido_842JF AsignarCliente_842JF(BECliente_842JF cliente, BEPedido_842JF pedido)
        {
            pedido.cliente_842JF = cliente;
            return pedido;
        }
        public BEPedido_842JF CargarPedido_842JF(List<BEPizza_842JF> bEPizzas, BEPedido_842JF pedido)
        {
            pedido.pizzas_842JF = bEPizzas;
            return pedido;
        }
        public void ConfirmarPedido_842JF(BEPedido_842JF pedido)
        {
            dalpedido_842JF.ConfirmarPedido_842JF(pedido);
            bllDv.Recalcular_842JF(new BEDV_842JF("Pedido_842JF"));
        }
        public BEPedido_842JF CrearPedido_842JF()
        {
            return new BEPedido_842JF();
        }
        public void Pagar_842JF(BEPedido_842JF pedido)
        {
            pedido.pago_842JF = true;
            pedido.estado_842JF = "Pagado";
            dalpedido_842JF.ActualizarPedido_842JF(pedido);
            bllDv.Recalcular_842JF(new BEDV_842JF("Pedido_842JF"));
        }
        public List<BEPedido_842JF> ObtenerNoCobrados_842JF()
        {
            var linq = from x in ObtenerTodos_842JF() where x.pago_842JF == false select x;
            return linq.ToList();
        }
        public List<BEPedido_842JF> ObtenerTodos_842JF()
        {
            List<BEPedido_842JF> lista = new List<BEPedido_842JF>();
            foreach (var pedido in dalpedido_842JF.ObtenerTodos_842JF())
            {
                List<BEPizza_842JF> p = new List<BEPizza_842JF>();
                foreach (var pedidopizza in bllpedidoPizza.ObtenerTodos_842JF())
                {
                    if (pedido.nroPedido_842JF == pedidopizza.nroPedido_842JF)
                    {
                        var pizza = bllpizza.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == pedidopizza.codPizza_842JF);

                        for (int i = 0; i < pedidopizza.cantidad_842JF; i++)
                        {
                            p.Add(pizza);
                        }
                    }
                }
                lista.Add(new BEPedido_842JF(pedido.nroPedido_842JF, bllcliente.ObtenerTodos_842JF().Find(x => x.DNI_842JF == pedido.cliente_842JF.DNI_842JF), pedido.estado_842JF, p, pedido.pago_842JF));
            }
            return lista;
        }
        public void CancelarPedido_842JF(BEPedido_842JF ped)
        {
            int harina = 0;
            int jamon = 0;
            int queso = 0;
            int salsa = 0;
            int oregano = 0;
            int cebolla = 0;
            int rucula = 0;
            int aceituna = 0;
            int jamonCrudo = 0;
            int morron = 0;
            foreach (var item in ped.pizzas_842JF)
            {
                foreach (var item2 in item.productos)
                {
                    if (item2.Key.codProducto_842JF == 1)
                    {
                        jamon += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 2)
                    {
                        queso += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 3)
                    {
                        aceituna += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 4)
                    {
                        salsa += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 5)
                    {
                        cebolla += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 6)
                    {
                        oregano += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 7)
                    {
                        morron += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 8)
                    {
                        jamonCrudo += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 9)
                    {
                        rucula += item2.Value;
                    }
                    else if (item2.Key.codProducto_842JF == 10)
                    {
                        harina += item2.Value;
                    }
                }
            }
            foreach (var item in bllproducto.ObtenerTodos_842JF())
            {
                if (item.codProducto_842JF == 1)
                {
                    item.cantidad_842JF += jamon;
                }
                else if (item.codProducto_842JF == 2)
                {
                    item.cantidad_842JF += queso;
                }
                else if (item.codProducto_842JF == 3)
                {
                    item.cantidad_842JF += aceituna;
                }
                else if (item.codProducto_842JF == 4)
                {
                    item.cantidad_842JF += salsa;
                }
                else if (item.codProducto_842JF == 5)
                {
                    item.cantidad_842JF += cebolla;
                }
                else if (item.codProducto_842JF == 6)
                {
                    item.cantidad_842JF += oregano;
                }
                else if (item.codProducto_842JF == 7)
                {
                    item.cantidad_842JF += morron;
                }
                else if (item.codProducto_842JF == 8)
                {
                    item.cantidad_842JF += jamonCrudo;
                }
                else if (item.codProducto_842JF == 9)
                {
                    item.cantidad_842JF += rucula;
                }
                else if (item.codProducto_842JF == 10)
                {
                    item.cantidad_842JF += harina;
                }
                bllproducto.Modificar_842JF(item);
            }
            ped.pago_842JF = true;
            ped.estado_842JF = "Cancelado";
            dalpedido_842JF.ActualizarPedido_842JF(ped);
            bllDv.Recalcular_842JF(new BEDV_842JF("Pedido_842JF"));
        }
    }
}
