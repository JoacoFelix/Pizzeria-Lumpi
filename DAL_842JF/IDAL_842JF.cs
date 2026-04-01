using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios_842JF.Observer;

namespace DAL_842JF
{
    public abstract class IDAL_842JF
    {
        protected string conexion;
        public IdiomaManager_842JF IM_842JF = new IdiomaManager_842JF();
        public IDAL_842JF()
        {
            //IM_842JF.CargarInstancia_842JF("instanciaBD_842JF");
            conexion = $"Data Source=.;Initial Catalog=SistemaPizzeriaFelixJoaquin;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=True";

        }
    }
}
