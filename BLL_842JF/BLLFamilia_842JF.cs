using DAL_842JF;
using BE_842JF;
using Servicios_842JF.Composite;
using Servicios_842JF.Observer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Servicios_842JF.Singleton;

namespace BLL_842JF
{
    public class BLLFamilia_842JF
    {
        DALFamilia_842JF dalfamilia_842JF = new DALFamilia_842JF();
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
        DALPermisoFamilia_842JF dalpermisoFamilia_842JF = new DALPermisoFamilia_842JF();
        DALFamiliaFamilia_842JF dalfamiliaFamilia_842JF = new DALFamiliaFamilia_842JF();
        DALPermisoPerfil_842JF dalpermisoperfil_842JF = new DALPermisoPerfil_842JF();
        DALFamiliaPerfil_842JF dalfamiliaPerfil_842JF = new DALFamiliaPerfil_842JF();
        DALPerfil_842JF dalperfil_842JF= new DALPerfil_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        public void AgregarPermiso_842JF(Familia_842JF familia, Permiso_842JF permiso)
        {
            if (familia.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == permiso.nombre_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContienePermiso"));
            }
            foreach(var item in ObtenerPerfiles_842JF())
            {
                if(FamiliaContieneFamilia_842JF(item,familia))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaAsignadaAPerfil"));
                }
            }
            if (PermisoRepetidoPermisoFamilia(familia, permiso))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.permisoJerarquia"));
            }
            foreach (var item in ObtenerTodas_842JF())
            {
                if(item.ObtenerSiEsHijoFamilia_842JF(familia) != null && item.ObtenerHijos_842JF().Any(x=>x.codPerfil_842JF == permiso.codPerfil_842JF && x is Permiso_842JF))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContienePermiso"));
                }
            }
            familia.AgregarHijo_842JF(permiso);
            familia.AgregarPermisoSimple_842JF(permiso);
            dalpermisoFamilia_842JF.GuardarPermisoFamilia_842JF(familia, permiso);
        }
        public void GuardarFamilia_842JF(Perfil_842JF familia)
        {
            if (dalfamilia_842JF.ObtenerTodas_842JF().Any(x => x.nombre_842JF == familia.nombre_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaExiste"));
            }
            dalfamilia_842JF.GuardarFamilia_842JF(familia);
        }
        public void AgregarFamilia_842JF(Familia_842JF familia, Familia_842JF familiaRelacionado)
        {
            if(familia.codPerfil_842JF == familiaRelacionado.codPerfil_842JF)
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mismaFamilia"));
            }
            if (dalfamiliaFamilia_842JF.ObtenerTodosFamiliaFamilia_842JF(familia).Any(x => x.codPerfil_842JF == familiaRelacionado.codPerfil_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContieneLaFamilia"));
            }
            foreach (var item in ObtenerPerfiles_842JF())
            {
                if (FamiliaContieneFamilia_842JF(item, familia))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaAsignadaAPerfil"));
                }
            }
            if(familiaRelacionado.ObtenerHijos_842JF().Count() <=0)
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.familiaVacia"));
            }
            if (PermisoRepetidoEntreFamilias(familia,familiaRelacionado))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.familiaJerarquia"));
            }
            if(ComponentesRepetidos_842JF(familia,familiaRelacionado).Count > 0)
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.familiasRepetidas"));
            }
            if(FamiliaContieneFamilia_842JF(familiaRelacionado, familia))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.circular"));

            }
            foreach (var item in familiaRelacionado.ObtenerPermisosSimples_842JF())
            {
                if (familia.ObtenerPermisosSimples_842JF().Any(x => x.codPerfil_842JF == item.codPerfil_842JF))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContienePermisosDeFamilia"));
                }
            }
            foreach (var item in familiaRelacionado.ObtenerPermisosSimples_842JF())
            {
                familia.AgregarPermisoSimple_842JF(item);
            }
            familia.AgregarHijo_842JF(familiaRelacionado);

            dalfamiliaFamilia_842JF.GuardarFamiliaFamilia_842JF(familia, familiaRelacionado);
        }
        public List<Familia_842JF> ObtenerTodas_842JF()
        {
            List<Familia_842JF> lista = new List<Familia_842JF>();
            foreach(Familia_842JF item in dalfamilia_842JF.ObtenerTodas_842JF())
            {
                lista.Add(CargarFamilia_842JF(item));
            }
            return lista;
        }
        private bool PermisoRepetidoEntreFamilias(Familia_842JF familia, Familia_842JF familiaRelacionado)
        {
          
            foreach (Familia_842JF item in ObtenerTodas_842JF())
            {
                if (FamiliaContieneFamilia_842JF(item, familia))
                {
                    if (familiaRelacionado.ObtenerPermisosSimples_842JF().Any(p => item.ObtenerPermisosSimples_842JF().Any(a => a.codPerfil_842JF == p.codPerfil_842JF)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private List<Familia_842JF> ComponentesRepetidos_842JF(Familia_842JF familia, Familia_842JF familiaRelacionado)
        {
            List<Perfil_842JF> familiasDeFamilia = ObtenerTodasLasFamiliasRelacionadas_842JF(familia);
            List<Perfil_842JF> familiasDeRelacionado = ObtenerTodasLasFamiliasRelacionadas_842JF(familiaRelacionado);

            List<Familia_842JF> aux = new List<Familia_842JF>();

            foreach (Perfil_842JF item in familiasDeRelacionado)
            {
                if (familiasDeFamilia.Any(x => x.codPerfil_842JF == item.codPerfil_842JF))
                {
                    if (item is Familia_842JF famRepetida && !aux.Any(f => f.codPerfil_842JF == famRepetida.codPerfil_842JF))
                    {
                        aux.Add(famRepetida);
                    }
                }
            }
            foreach (Familia_842JF item2 in ObtenerTodas_842JF())
            {
                if (FamiliaContieneFamilia_842JF(item2, familia))
                {
                    List<Perfil_842JF> auxFamiliasDeFamilias = ObtenerTodasLasFamiliasRelacionadas_842JF(item2);
                    if (familiasDeRelacionado.Any(x => auxFamiliasDeFamilias.Any(f => f.codPerfil_842JF == x.codPerfil_842JF)))
                    {
                        aux.Add(item2);
                    }
                }
            }
            return aux;
        }
        private List<Perfil_842JF> ObtenerTodasLasFamiliasRelacionadas_842JF(Familia_842JF familia)
        {
            List<Perfil_842JF> listaComponentes = new List<Perfil_842JF>();
            foreach (Perfil_842JF comp in familia.ObtenerHijos_842JF())
            {
                listaComponentes.Add(comp);
                if (comp is Familia_842JF f)
                {
                    listaComponentes.AddRange(ObtenerTodasLasFamiliasRelacionadas_842JF(f));
                }
            }
            return listaComponentes;
        }
        private bool PermisoRepetidoPermisoFamilia(Familia_842JF familia, Permiso_842JF permiso)
        {

            foreach (Familia_842JF item in ObtenerTodas_842JF())
            {
                if (FamiliaContieneFamilia_842JF(item, familia))
                {
                    if (item.ObtenerPermisosSimples_842JF().Any(a => a.codPerfil_842JF == permiso.codPerfil_842JF))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool FamiliaContieneFamilia_842JF(Familia_842JF familia, Familia_842JF familiaRelacionado)
        {
            foreach (Perfil_842JF comp in familia.ObtenerHijos_842JF())
            {
                if (comp is Familia_842JF f)
                {
                    if (f.codPerfil_842JF == familiaRelacionado.codPerfil_842JF) return true;
                    if (FamiliaContieneFamilia_842JF(f, familiaRelacionado)) return true;
                }
            }
            return false;
        }

        public Familia_842JF CargarFamilia_842JF(Familia_842JF fam)
        {
            foreach (var item in dalpermisoFamilia_842JF.ObtenerTodos_842JF(fam))
            {
                fam.AgregarHijo_842JF(item);
                fam.AgregarPermisoSimple_842JF(item);
            }
            foreach (Familia_842JF item2 in dalfamiliaFamilia_842JF.ObtenerTodosFamiliaFamilia_842JF(fam))
            {
                Familia_842JF aux = CargarFamilia_842JF(item2);
                foreach (var item3 in aux.ObtenerPermisosSimples_842JF())
                {
                    fam.AgregarPermisoSimple_842JF(item3);
                }
                fam.AgregarHijo_842JF(aux);
            }
            return fam;
        }
        public void EliminarFamilia_842JF(Perfil_842JF fam)
        {
            dalfamiliaFamilia_842JF.EliminarTodosFamiliaFamilia_842JF(fam);
            dalpermisoFamilia_842JF.EliminarTodosPermisoFamilia_842JF(fam);
            dalfamiliaPerfil_842JF.EliminarTodosFamilia_842JF(fam);
            dalfamilia_842JF.EliminarFamilia_842JF(fam);
            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Eliminar Familia", 2));
        }
        private List<Familia_842JF> ObtenerPerfiles_842JF()
        {
            List<Familia_842JF> lista = new List<Familia_842JF>();
            foreach (Familia_842JF item in dalperfil_842JF.ObtenerTodos_842JF())
            {
                lista.Add(CargarPerfiles_842JF(item));
            }
            return lista;
        }
        private Familia_842JF CargarPerfiles_842JF(Familia_842JF fam)
        {
            foreach (var item in dalpermisoperfil_842JF.ObtenerTodos_842JF(fam))
            {
                fam.AgregarHijo_842JF(item);
                fam.AgregarPermisoSimple_842JF(item);
            }
            foreach (Familia_842JF item2 in dalfamiliaPerfil_842JF.ObtenerTodosFamiliaPerfil_842JF(fam))
            {
                Familia_842JF aux = CargarFamilia_842JF(item2);
                foreach (var item3 in aux.ObtenerPermisosSimples_842JF())
                {
                    fam.AgregarPermisoSimple_842JF(item3);
                }
                fam.AgregarHijo_842JF(aux);
            }
            return fam;
        }
        public void EliminarHijo_842JF(Perfil_842JF fam, Perfil_842JF hijo)
        {
            if (hijo is Familia_842JF)
            {
                dalfamiliaFamilia_842JF.EliminarFamiliaFamilia_842JF(fam, hijo);
            }
            else
            {
                dalpermisoFamilia_842JF.EliminarPermisoFamilia_842JF(fam, hijo);
            }
        }
    }
}
