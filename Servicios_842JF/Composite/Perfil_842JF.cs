using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_842JF.Composite
{
    public abstract class Perfil_842JF
    {
        public Perfil_842JF(int codPerfil) 
        {
            this.codPerfil_842JF = codPerfil;
        }
        public Perfil_842JF(int codPerfil, string descripcion_842JF, string nombre_842JF) : this(codPerfil)
        {
            this.descripcion_842JF = descripcion_842JF;
            this.nombre_842JF = nombre_842JF;
        }

        public abstract int codPerfil_842JF { get; set; }
        public abstract string descripcion_842JF { get; set; }
        public abstract string nombre_842JF { get; set; }
        public abstract void AgregarHijo_842JF(Perfil_842JF componente);
        public abstract Perfil_842JF ObtenerSiEsHijoFamilia_842JF(Perfil_842JF componente);
        public abstract Perfil_842JF ObtenerHijo_842JF(Perfil_842JF componente);
        public abstract void AgregarPermisoSimple_842JF(Perfil_842JF componente);
        public abstract List<Perfil_842JF> ObtenerHijos_842JF();
        public abstract List<Perfil_842JF> ObtenerPermisosSimples_842JF();
        public abstract void EliminarHijo_842JF(Perfil_842JF componente);
        public override string ToString()
        {
            return nombre_842JF;
        }
    }
}
