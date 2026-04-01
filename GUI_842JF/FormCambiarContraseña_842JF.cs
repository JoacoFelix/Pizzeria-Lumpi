using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_842JF;
using BLL_842JF;
using DAL_842JF;
using Servicios_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class FormCambiarContraseña_842JF : Form, IIdiomaObserver_842JF
    {
        BLLUsuario_842JF bllUsuario842JF;
        IdiomaManager_842JF IM_842JF;

        public FormCambiarContraseña_842JF()
        {
            InitializeComponent();
            bllUsuario842JF = new BLLUsuario_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formCambiarContraseña_842JF");
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formCambiarContraseña_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblContrasenaActual");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNuevaContrasena");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblConfirmarContrasena");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnCambiar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("checkbox.chkMostrarContrasena");
            checkBox2.Text = IM_842JF.ObtenerString_842JF("checkbox.chkMostrarContrasena");
        }

        private void botonCambiarContraseña(object sender, EventArgs e)
        {
            try
            {
                string contraVieja = textBox1.Text;
                string contraNueva1 = textBox2.Text;
                string contraNueva2 = textBox3.Text;
                Usuario_842JF user = SessionManager_842JF.Instancia.Usuario_842JF;
                if (Encriptador_842JF.Encriptar_842JF(contraVieja) != user.contraseña_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.contraActualIncorrecta"));
                }
                if (contraNueva1 != contraNueva2)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.contrasenasDistintas"));
                }
                if (Encriptador_842JF.Encriptar_842JF(contraNueva2) == user.contraseña_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mismaContra"));
                }
                else
                {
                    if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguro"), IM_842JF.ObtenerString_842JF("mensaje.alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllUsuario842JF.CambiarContraseña_842JF(user, contraNueva1);
                        FormPrincipal_842JF frm = (FormPrincipal_842JF)this.MdiParent;
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.exito"), IM_842JF.ObtenerString_842JF("mensaje.alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        bllUsuario842JF.LogOut_842JF();
                        frm.ValidarForm_842JF();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.UseSystemPasswordChar = !this.checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = !this.checkBox2.Checked;
            this.textBox3.UseSystemPasswordChar = !this.checkBox2.Checked;
        }

        private void FormCambiarContraseña_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void FormCambiarContraseña_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formCambiarContraseña_842JF");
        }

        private void FormCambiarContraseña_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }
    }
}
