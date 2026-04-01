using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;
using DAL_842JF;
using Servicios_842JF.Observer;
using XAct;

namespace BLL_842JF
{
    public class BLLProducto_842JF
    {
        DALProducto_842JF dalProducto_842JF = new DALProducto_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public void Guardar_842JF(BEProducto_842JF producto)
        {
            dalProducto_842JF.Guardar_842JF(producto);
            bllDv.Recalcular_842JF(new BEDV_842JF("Producto_842JF"));
        }
        public List<BEProducto_842JF> ObtenerTodos_842JF()
        {
            return dalProducto_842JF.ObtenerTodos_842JF();
        }
        public void Modificar_842JF(BEProducto_842JF prod)
        {
            dalProducto_842JF.Modificar_842JF(prod);
            bllDv.Recalcular_842JF(new BEDV_842JF("Producto_842JF"));
        }
    }
}
