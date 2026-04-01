using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_842JF.Singleton
{
    public class LoginException_842JF : Exception
    {
        public LoginResult_842JF Result;
        public LoginException_842JF(LoginResult_842JF result)
        {
            Result = result;
        }
    }
}
