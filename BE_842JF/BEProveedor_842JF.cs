using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEProveedor_842JF
    {
        public string CUIT_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public List<BEProducto_842JF> productos_842JF;
        public int telefono_842JF { get; set; }
        public bool estado_842JF { get; set; }
        public string mail_842JF { get; set; }
        public string direccion_842JF { get; set; }
        public BEProveedor_842JF(string cuit)
        {
            CUIT_842JF = cuit;
        }
        public BEProveedor_842JF(string cuit, string nombre, int tel, bool est, string mail, string dire) : this(cuit)
        {
            productos_842JF = new List<BEProducto_842JF>();
            nombre_842JF = nombre;
            telefono_842JF = tel;
            estado_842JF = est;
            mail_842JF = mail;
            direccion_842JF = dire;
        }
    }
}
