using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEEvento_842JF
    {
        public BEEvento_842JF(int idEvento_842JF, string login_842JF, DateTime fechaHora_842JF, string modulo_842JF, string evento_842JF, int criticidad_842JF)
        {
            this.idEvento_842JF = idEvento_842JF;
            this.login_842JF = login_842JF;
            this.fechaHora_842JF = fechaHora_842JF;
            this.modulo_842JF = modulo_842JF;
            this.evento_842JF = evento_842JF;
            this.criticidad_842JF = criticidad_842JF;
        }

        public int idEvento_842JF { get; set; }
        public string login_842JF { get; set; }
        public DateTime fechaHora_842JF { get; set; }
        public string modulo_842JF { get; set; }
        public string evento_842JF { get; set; }
        public int criticidad_842JF { get; set; }

    }
}
