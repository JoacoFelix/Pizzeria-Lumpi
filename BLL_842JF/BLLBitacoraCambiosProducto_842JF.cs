using BE_842JF;
using DAL_842JF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    public class BLLBitacoraCambiosProducto_842JF
    {
        DALBitacoraCambiosProducto_842JF dalbitacoracambios = new DALBitacoraCambiosProducto_842JF();
        BLLDV_842JF bLLDV = new BLLDV_842JF();
        public List<BEProducto_C_842JF> ObtenerTodos_842JF()
        {
            return dalbitacoracambios.ObtenerTodos_842JF();
        }
        public void Activar_842JF(BEProducto_C_842JF prodC)
        {
            dalbitacoracambios.Activar_842JF(prodC);
            bLLDV.Recalcular_842JF(new BEDV_842JF("Producto_842JF"));
        }
    }
}
