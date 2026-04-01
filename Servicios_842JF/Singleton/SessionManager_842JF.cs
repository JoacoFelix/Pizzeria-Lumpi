using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_842JF.Singleton
{
    public class SessionManager_842JF
    {
        private static object _lock_842JF = new Object();
        private static SessionManager_842JF _session_842JF;
        public Usuario_842JF Usuario_842JF { get; set; }
        public static SessionManager_842JF Instancia
        {
            get
            {
                lock (_lock_842JF)
                {
                    return _session_842JF;
                }
            }
        }
        public static void Login_842JF(Usuario_842JF u)
        {
            lock (_lock_842JF)
            {
                if (_session_842JF == null)
                {
                    _session_842JF = new SessionManager_842JF();
                    _session_842JF.Usuario_842JF = u;
                }
            }
        }
        public static void LogOut_842JF()
        {
            lock (_lock_842JF)
            {
                if (_session_842JF != null)
                {
                    _session_842JF = null;
                }
            }
        }
        public static bool IsLogged_842JF()
        {
            return _session_842JF != null;
        }
    }
}
