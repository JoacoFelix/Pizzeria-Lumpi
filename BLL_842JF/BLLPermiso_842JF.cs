using DAL_842JF;
using Servicios_842JF.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    public class BLLPermiso_842JF
    {
        DALPermiso_842JF dalpermiso_842JF = new DALPermiso_842JF();
        public List<Permiso_842JF> ObtenerTodos_842JF()
        {
            return dalpermiso_842JF.ObtenerTodos_842JF();
        }
    }
}
