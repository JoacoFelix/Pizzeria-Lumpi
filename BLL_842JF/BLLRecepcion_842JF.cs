using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;
using DAL_842JF;
using Servicios_842JF.Observer;

namespace BLL_842JF
{
    public class BLLRecepcion_842JF
    {
        DALRecepcion_842JF dalRecepcion_842JF = new DALRecepcion_842JF();
        BLLProducto_842JF bllproducto = new BLLProducto_842JF();
        BLLProveedor_842JF bllproveedor = new BLLProveedor_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public void Guardar_842JF(BERecepcion_842JF recepcion)
        {
            dalRecepcion_842JF.Guardar_842JF(recepcion);
            bllDv.Recalcular_842JF(new BEDV_842JF("Recepcion_842JF"));
        }
        public List<BERecepcion_842JF> ObtenerTodos_842JF()
        {
            List < BERecepcion_842JF > aux = new List<BERecepcion_842JF> ();
            foreach (var item in dalRecepcion_842JF.ObtenerTodos_842JF())
            {
                item.producto_842JF = bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == item.producto_842JF.codProducto_842JF);
                item.proveedor_842JF = bllproveedor.ObtenerTodos_842JF().Find(x => x.CUIT_842JF == item.proveedor_842JF.CUIT_842JF);
                aux.Add(item);
            }
            return aux;
        }
    }
}
