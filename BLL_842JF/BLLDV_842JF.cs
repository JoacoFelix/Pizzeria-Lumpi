using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;
using DAL_842JF;

namespace BLL_842JF
{
    public class BLLDV_842JF
    {
        DALDV_842JF dalDV_842JF = new DALDV_842JF();
        public string CalcularDigitoVerificadorHorizontal_842JF(BEDV_842JF dv)
        {
            return dalDV_842JF.CalcularDigitoVerificadorHorizontal_842JF(dv);
        }
        public string CalcularDigitoVerificadorVertical_842JF(BEDV_842JF dv)
        {
            return dalDV_842JF.CalcularDigitoVerificadorVertical_842JF(dv);
        }
        public void Recalcular_842JF(BEDV_842JF dv)
        {
            dv.horizontal_842JF = CalcularDigitoVerificadorHorizontal_842JF(dv);
            dv.vertical_842JF = CalcularDigitoVerificadorVertical_842JF(dv);
            GuardarDigitoVerificador_842JF(dv);
        }
        public void GuardarDigitoVerificador_842JF(BEDV_842JF dv)
        {
            dalDV_842JF.GuardarDigitoVerificador_842JF(dv);
        }
        public List<string> Comparar_842JF()
        {
            List<string> lista = new List<string>();
            foreach(var item in dalDV_842JF.ObtenerTodos_842JF())
            {
                if(CalcularDigitoVerificadorHorizontal_842JF(item) != item.horizontal_842JF || CalcularDigitoVerificadorVertical_842JF(item) != item.vertical_842JF)
                {
                    lista.Add(item.nombreTabla_842JF);
                }
            }
            return lista;
        }
    }
}
