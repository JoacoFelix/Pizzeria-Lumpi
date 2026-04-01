namespace BE_842JF
{
    [Serializable]
    public class BECliente_842JF
    {
        public BECliente_842JF() { }
        public BECliente_842JF(string dni) { DNI_842JF = dni; }
        public BECliente_842JF(string dni, string nombre, string apellido, string mail, int telefono, bool activo_842JF) : this(dni)
        {
            this.nombre_842JF = nombre;
            this.apellido_842JF = apellido;
            this.mail_842JF = mail;
            this.telefono_842JF = telefono;
            this.activo_842JF = activo_842JF;
        }

        public string DNI_842JF { get; set; }
        public string nombre_842JF { get; set; }
        public string apellido_842JF { get; set; }
        public string mail_842JF { get; set; }
        public int telefono_842JF { get; set; }
        public bool activo_842JF { get; set; }
        public override string ToString()
        {
            return $"{DNI_842JF}";
        }
    }
}
