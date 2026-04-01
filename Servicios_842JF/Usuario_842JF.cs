using Servicios_842JF.Composite;

namespace Servicios_842JF
{
    public class Usuario_842JF
    {
        public Usuario_842JF(string dNI_842JF, string nombre_842JF, string apellido_842JF, string login_842JF, string contraseña_842JF, Perfil_842JF rol_842JF, string mail_842JF, bool bloqueo_842JF, bool activo_842JF, int contador_842JF, DateTime ultimoIntento,string idioma)
        {
            DNI_842JF = dNI_842JF;
            this.nombre_842JF = nombre_842JF;
            this.apellido_842JF = apellido_842JF;
            this.login_842JF = login_842JF;
            this.contraseña_842JF = contraseña_842JF;
            this.rol_842JF = rol_842JF;
            this.mail_842JF = mail_842JF;
            this.bloqueo_842JF = bloqueo_842JF;
            this.activo_842JF = activo_842JF;
            this.contador_842JF = contador_842JF;
            this.ultimoIntento_842JF = ultimoIntento;
            this.idioma_842JF = idioma;
        }

        public string DNI_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public string apellido_842JF { get; set; }
        public string login_842JF { get; set; }
        public string contraseña_842JF { get; set; }
        public Perfil_842JF rol_842JF { get; set; }
        public string mail_842JF { get; set; }
        public bool bloqueo_842JF { get; set; }
        public bool activo_842JF { get; set; }
        public int contador_842JF { get; set; }
        public DateTime ultimoIntento_842JF { get; set; }
        public string idioma_842JF { get; set; }
    }
}
