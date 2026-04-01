using BE_842JF;
using DAL_842JF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    public class BLLPedidoPizza_842JF
    {
        DALPedidoPizza_842JF dalpedidopizza = new DALPedidoPizza_842JF();
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public void ConfirmarPedido_842JF(BEPedidoPizza_842JF pedidoPizza)
        {
            dalpedidopizza.ConfirmarPedido_842JF(pedidoPizza);
            bllDv.Recalcular_842JF(new BEDV_842JF("PedidoPizza_842JF"));
        }
        public List <BEPedidoPizza_842JF> ObtenerTodos_842JF()
        {
            return dalpedidopizza.ObtenerTodos_842JF();
        }
    }
}
