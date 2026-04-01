namespace Servicios_842JF.Composite
{
    public class Familia_842JF : Perfil_842JF
    {
        public override int codPerfil_842JF { get; set; }
        public override string descripcion_842JF { get; set; }
        public override string nombre_842JF { get; set; }

        List<Perfil_842JF> hijos_842JF = new List<Perfil_842JF>();
        List<Perfil_842JF> permisosSimples_842JF = new List<Perfil_842JF>();


        public Familia_842JF(int codPerfil) : base(codPerfil)
        {
        }
        public Familia_842JF(int codPerfil, string descripcion_842JF, string nombre_842JF) : base(codPerfil, descripcion_842JF, nombre_842JF)
        {
        }

        public override void AgregarHijo_842JF(Perfil_842JF componente)
        {
            hijos_842JF.Add(componente);
        }
        public override void AgregarPermisoSimple_842JF(Perfil_842JF componente)
        {
            permisosSimples_842JF.Add(componente);
        }

        public override void EliminarHijo_842JF(Perfil_842JF componente)
        {
            hijos_842JF.Remove(componente);
        }

        public override Perfil_842JF ObtenerSiEsHijoFamilia_842JF(Perfil_842JF componente)
        {
            if (hijos_842JF.Any(x=>x.codPerfil_842JF == componente.codPerfil_842JF && x is Familia_842JF))
            {
                return hijos_842JF.FirstOrDefault(x => x.codPerfil_842JF == componente.codPerfil_842JF);
            }
            else
            {
                return null;
            }
        }

        public override List<Perfil_842JF> ObtenerHijos_842JF()
        {
            return hijos_842JF;
        }

        public override List<Perfil_842JF> ObtenerPermisosSimples_842JF()
        {
            return permisosSimples_842JF;
        }

        public override Perfil_842JF ObtenerHijo_842JF(Perfil_842JF componente)
        {
            return hijos_842JF.Find(x => x.nombre_842JF == componente.nombre_842JF && x.codPerfil_842JF == componente.codPerfil_842JF);
        }
    }
}
