using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_842JF
{
    public class BEDV_842JF
    {
        public string nombreTabla_842JF { get; set; }
        public string vertical_842JF { get; set; }
        public string horizontal_842JF { get; set; }
        public BEDV_842JF(string nom)
        {
            nombreTabla_842JF = nom;
        }
        public BEDV_842JF(string nom, string vert, string hor):this(nom)
        {
            vertical_842JF = vert;
            horizontal_842JF = hor;
        }
    }
}
