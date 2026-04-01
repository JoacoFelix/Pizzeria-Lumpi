using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_842JF.Composite
{
    public class Permiso_842JF : Perfil_842JF
    {
        public Permiso_842JF(int codPerfil) : base(codPerfil)
        {
        }
        public Permiso_842JF(int codPerfil_842JF, string descripcion_842JF, string nombre_842JF) : base(codPerfil_842JF, descripcion_842JF, nombre_842JF)
        {
        }

        public override int codPerfil_842JF { get; set; }
        public override string descripcion_842JF { get; set; }
        public override string nombre_842JF { get; set; }

        public override void AgregarHijo_842JF(Perfil_842JF componente)
        {
            throw new NotImplementedException();
        }

        public override void AgregarPermisoSimple_842JF(Perfil_842JF componente)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo_842JF(Perfil_842JF componente)
        {
            throw new NotImplementedException();
        }

        public override List<Perfil_842JF> ObtenerHijos_842JF()
        {
            throw new NotImplementedException();
        }

        public override Perfil_842JF ObtenerSiEsHijoFamilia_842JF(Perfil_842JF componente)
        {
            throw new NotImplementedException();
        }

        public override List<Perfil_842JF> ObtenerPermisosSimples_842JF()
        {
            throw new NotImplementedException();
        }

        public override Perfil_842JF ObtenerHijo_842JF(Perfil_842JF componente)
        {
            throw new NotImplementedException();
        }
    }
}
