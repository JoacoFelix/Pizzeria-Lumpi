using BE_842JF;
using DAL_842JF;
using Servicios_842JF.Composite;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    public class BLLPerfil_842JF
    {
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
        DAL_Usuario_842JF dalusuario_842JF = new DAL_Usuario_842JF();
        DALPerfil_842JF dalPerfil_842JF = new DALPerfil_842JF();
        DALPermisoPerfil_842JF dalpermisoPerfil_842JF = new DALPermisoPerfil_842JF();
        DALFamiliaPerfil_842JF dalfamiliaPerfil_842JF = new DALFamiliaPerfil_842JF();
        BLLFamilia_842JF bllfamilia_842JF = new BLLFamilia_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        public void AgregarPermiso_842JF(Perfil_842JF perfil, Perfil_842JF permiso)
        {
            if (perfil.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == permiso.nombre_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContienePermiso"));
            }
            
            perfil.AgregarHijo_842JF(permiso);
            perfil.AgregarPermisoSimple_842JF(permiso);
            dalpermisoPerfil_842JF.GuardarPermisoPerfil_842JF(perfil, permiso);
        }
        public void GuardarPerfil_842JF(Perfil_842JF perfil)
        {
            if (dalPerfil_842JF.ObtenerTodos_842JF().Any(x => x.nombre_842JF == perfil.nombre_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaExiste"));
            }
            dalPerfil_842JF.GuardarPerfil_842JF(perfil);
        }
        public void AgregarFamilia_842JF(Perfil_842JF perfil, Perfil_842JF familia)
        {
            if (dalfamiliaPerfil_842JF.ObtenerTodosFamiliaPerfil_842JF(perfil).Any(x => x.codPerfil_842JF == familia.codPerfil_842JF && x.nombre_842JF == familia.nombre_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContieneLaFamilia"));
            }
            foreach (var item in familia.ObtenerPermisosSimples_842JF())
            {
                if (perfil.ObtenerPermisosSimples_842JF().Any(x => x.codPerfil_842JF == item.codPerfil_842JF))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaContienePermisosDeFamilia"));
                }
            }
            foreach (var item in familia.ObtenerPermisosSimples_842JF())
            {
                perfil.AgregarPermisoSimple_842JF(item);
            }
            perfil.AgregarHijo_842JF(familia);

            dalfamiliaPerfil_842JF.GuardarFamiliaPerfil_842JF(perfil, familia);
        }
        public List<Perfil_842JF> ObtenerTodos_842JF()
        {
            List<Perfil_842JF> lista = new List<Perfil_842JF>();
            foreach (Familia_842JF item in dalPerfil_842JF.ObtenerTodos_842JF())
            {
                lista.Add(CargarPerfil_842JF(item));
            }
            return lista;
        }
        public Familia_842JF CargarPerfil_842JF(Familia_842JF fam)
        {
            foreach (var item in dalpermisoPerfil_842JF.ObtenerTodos_842JF(fam))
            {
                fam.AgregarHijo_842JF(item);
                fam.AgregarPermisoSimple_842JF(item);
            }
            foreach (Familia_842JF item2 in dalfamiliaPerfil_842JF.ObtenerTodosFamiliaPerfil_842JF(fam))
            {
                Familia_842JF aux = bllfamilia_842JF.CargarFamilia_842JF(item2);
                foreach (var item3 in aux.ObtenerPermisosSimples_842JF())
                {
                    fam.AgregarPermisoSimple_842JF(item3);
                }
                fam.AgregarHijo_842JF(aux);
            }
            return fam;
        }
        public void EliminarPerfil_842JF(Perfil_842JF perf)
        {
            if(dalusuario_842JF.ObtenerTodos_842JF().Any(x=>x.rol_842JF.codPerfil_842JF == perf.codPerfil_842JF))
            {
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.perfilCargado"));
            }
            dalfamiliaPerfil_842JF.EliminarTodosPerfil_842JF(perf);
            dalpermisoPerfil_842JF.EliminarTodosPermisoPerfil_842JF(perf);
            dalPerfil_842JF.EliminarPerfil_842JF(perf);
            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Eliminar Perfil", 2));
        }
        public void EliminarHijo_842JF(Perfil_842JF perf, Perfil_842JF hijo)
        {
            if(hijo is Familia_842JF)
            {
                dalfamiliaPerfil_842JF.EliminarFamiliaPerfil_842JF(perf,hijo);
            }
            else
            {
                dalpermisoPerfil_842JF.EliminarPermisoPerfil_842JF(perf,hijo);
            }
        }
    }
}
