using DAL_842JF;
using Servicios_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace BLL_842JF
{
    public class BLLUsuario_842JF
    {
        DAL_Usuario_842JF dalUsuario_842JF = new DAL_Usuario_842JF();
        BLLPerfil_842JF bllperfil_842JF = new BLLPerfil_842JF();
        IdiomaManager_842JF IM_842JF;
        public BLLUsuario_842JF()
        {
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        }
        public void Guardar_842JF(Usuario_842JF usuario)
        {
            usuario.contraseña_842JF = Encriptador_842JF.Encriptar_842JF(usuario.contraseña_842JF);
            dalUsuario_842JF.Guardar_842JF(usuario);
        }
        public void Login_842JF(string username, string contraseña)
        {
            if (SessionManager_842JF.IsLogged_842JF())
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.logueado"));
            var usuario = ObtenerTodos_842JF().Where(u => u.login_842JF.Equals(username)).FirstOrDefault();
            if (usuario == null) throw new LoginException_842JF(LoginResult_842JF.InvalidUsername);
            if (!Encriptador_842JF.Encriptar_842JF(contraseña).Equals(usuario.contraseña_842JF))
            {
                if (!usuario.bloqueo_842JF)
                {
                    usuario.contador_842JF++;
                    usuario.ultimoIntento_842JF = DateTime.Now;
                    dalUsuario_842JF.Modificar_842JF(usuario);
                    if (usuario.contador_842JF > 2)
                    {
                        Bloquear_842JF(usuario);
                        throw new Exception($"{IM_842JF.ObtenerString_842JF("mensaje.bloquear")} {usuario.login_842JF}");
                    }
                }
                throw new LoginException_842JF(LoginResult_842JF.InvalidPassword);
            }
            if (usuario.bloqueo_842JF)
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.bloqueado"));
            if (!usuario.activo_842JF)
                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.desactivado"));
            else
            {
                usuario.contador_842JF = 0;
                dalUsuario_842JF.Modificar_842JF(usuario);
                SessionManager_842JF.Login_842JF(usuario);

            }
        }
        public void LogOut_842JF()
        {
            SessionManager_842JF.LogOut_842JF();
        }
        public void Modificar_842JF(Usuario_842JF usuario)
        {
            dalUsuario_842JF.Modificar_842JF(usuario);
        }
        public void Desactivar_842JF(Usuario_842JF usuario)
        {
            dalUsuario_842JF.Desactivar_842JF(usuario);
        }
        public void Activar_842JF(Usuario_842JF usuario)
        {
            dalUsuario_842JF.Activar_842JF(usuario);
        }
        public void Desbloquear_842JF(Usuario_842JF usuario)
        {
            usuario.bloqueo_842JF = false;
            string s = usuario.DNI_842JF + usuario.apellido_842JF;
            usuario.contraseña_842JF = Encriptador_842JF.Encriptar_842JF(s);
            usuario.contador_842JF = 0;
            dalUsuario_842JF.Desbloquear_842JF(usuario);

        }
        public void Bloquear_842JF(Usuario_842JF usuario)
        {
            dalUsuario_842JF.Bloquear_842JF(usuario);
        }
        public IList<Usuario_842JF> ObtenerTodos_842JF()
        {
            List<Usuario_842JF> usuarios = new List<Usuario_842JF>();
            foreach (var item in dalUsuario_842JF.ObtenerTodos_842JF())
            {
                foreach (var item2 in bllperfil_842JF.ObtenerTodos_842JF())
                {
                    if (item2.codPerfil_842JF == item.rol_842JF.codPerfil_842JF)
                    {
                        item.rol_842JF = item2;
                        usuarios.Add(item);
                    }
                }
            }
            return usuarios;
        }
        public void CambiarContraseña_842JF(Usuario_842JF usuario, string contranueva)
        {
            usuario.contraseña_842JF = Encriptador_842JF.Encriptar_842JF(contranueva);
            dalUsuario_842JF.Modificar_842JF(usuario);
        }
    }
}
