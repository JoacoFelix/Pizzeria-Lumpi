using BE_842JF;
using BLL_842JF;
using Servicios_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace GUI_842JF
{
    public partial class formRegistrarCliente_842JF : Form, IIdiomaObserver_842JF
    {
        BLLCliente_842JF bllcliente_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BECliente_842JF cliente_842JF;
        IdiomaManager_842JF IM_842JF;
        public formRegistrarCliente_842JF()
        {
            InitializeComponent();
            bllcliente_842JF = new BLLCliente_842JF();
            cliente_842JF = new BECliente_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formRegistrarCliente_842JF");
            Actualizar_842JF();
        }

        private void formRegistrarCliente_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = textBox1.Text;
                if (!Regex.IsMatch(dni, @"^[0-9]{8}$"))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniInvalido"));
                }
                if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => x.DNI_842JF == dni) && bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni).activo_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniRepetido"));
                }
                else if(bllcliente_842JF.ObtenerTodos_842JF().Any(x => x.DNI_842JF == dni) && !bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni).activo_842JF)
                {
                    BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni);
                    c.activo_842JF = true;
                    bllcliente_842JF.Modificar_842JF(c);
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Cliente", 5));
                }
                else
                {
                    if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                    if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                    string nombre = textBox2.Text;
                    string apellido = textBox3.Text;
                    string mail = textBox5.Text;
                    int telefono = Convert.ToInt32(textBox4.Text);
                    if (!Regex.IsMatch(mail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                    if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF) == mail))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                    bllcliente_842JF.RegistrarCliente_842JF(new BECliente_842JF(dni, nombre, apellido, Servicios_842JF.Encriptador_842JF.EncriptarReversible_842JF(mail), telefono, true));
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Cliente", 5));
                }
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.registrado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarCliente_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblDNI");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblApellido");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblMail");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblTelefono");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnGuardar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
        }

        private void formRegistrarCliente_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarCliente_842JF");
        }

        private void formRegistrarCliente_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
