using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_842JF.Observer
{
    public interface IIdioma_842JF
    {
        void Agregar_842JF(IIdiomaObserver_842JF observer);
        void Eliminar_842JF(IIdiomaObserver_842JF observer);
        void Notificar_842JF();
    }
}
