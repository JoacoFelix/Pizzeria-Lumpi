using BE_842JF;
using DAL_842JF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    
    public class BLLCliente_842JF
    {
        DALCliente_842JF dalcliente_842JF = new DALCliente_842JF();
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public BLLCliente_842JF() 
        {
            
        }
        public BECliente_842JF BuscarCliente_842JF(BECliente_842JF cliente)
        {
            return dalcliente_842JF.BuscarCliente_842JF(cliente);
        }
        public List <BECliente_842JF> ObtenerTodos_842JF()
        {
            return dalcliente_842JF.ObtenerTodos_842JF();
        }
        public void RegistrarCliente_842JF(BECliente_842JF cliente)
        {
            dalcliente_842JF.RegistrarCliente_842JF(cliente);
            bllDv.Recalcular_842JF(new BEDV_842JF("Cliente_842JF"));
        }
        public void Modificar_842JF(BECliente_842JF cliente)
        {
            dalcliente_842JF.Modificar_842JF(cliente);
            bllDv.Recalcular_842JF(new BEDV_842JF("Cliente_842JF"));
        }
    }
}
