using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_842JF;
using BE_842JF;
using Servicios_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using Microsoft.VisualBasic.Devices;

namespace GUI_842JF
{
    public partial class FormLogin_842JF : Form, IIdiomaObserver_842JF
    {
        BLLUsuario_842JF bllUsuario_842JF;
        IdiomaManager_842JF IM_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLDV_842JF bllDV;
        public FormLogin_842JF()
        {
            InitializeComponent();
            bllUsuario_842JF = new BLLUsuario_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllDV = new BLLDV_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formLogin_842JF");
            Actualizar_842JF();
        }

        private void botonIngresar(object sender, EventArgs e)
        {
            try
            {
                bllUsuario_842JF.Login_842JF(this.textBox1.Text, this.textBox2.Text);
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("messagebox.mensaje.iniciandoSesion"), "", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Usuarios", "Iniciar Sesión", 1));
                if (bllDV.Comparar_842JF().Count > 0)
                {
                    if(SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF == "Administrador" || SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF == "SuperAdmin")
                    {
                        using (formRepararInconsistencia_842JF formReparar_842JF = new formRepararInconsistencia_842JF())
                        {
                            formReparar_842JF.llenarLista(bllDV.Comparar_842JF());
                            while (formReparar_842JF.ShowDialog() != DialogResult.OK)
                            {

                            }
                            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Usuarios", "Cerrar Sesión", 1));
                            bllUsuario_842JF.LogOut_842JF();
                        }
                    }
                    else
                    {
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("messagebox.mensaje.inconsistenciaBD"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Usuarios", "Cerrar Sesión", 1));
                        bllUsuario_842JF.LogOut_842JF();
                    }
                }
                FormPrincipal_842JF frm = (FormPrincipal_842JF)this.MdiParent;
                frm.ValidarForm_842JF();
                frm.CargarIdioma_842JF();
                frm.Actualizar_842JF();
                this.Close();
            }
            catch (LoginException_842JF ex)
            {
                switch (ex.Result)
                {
                    case LoginResult_842JF.InvalidUsername:
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("messagebox.mensaje.invalid_username"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    case LoginResult_842JF.InvalidPassword:
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("messagebox.mensaje.invalid_password"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void botonCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = !this.checkBox1.Checked;
        }

        private void FormLogin_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void FormLogin_842JF_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
       (this.ClientSize.Width - panel1.Width) / 2,
       (this.ClientSize.Height - panel1.Height) / 2);
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formLogin_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblUsuario");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblContrasena");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnIngresar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("checkbox.chkVerContrasena");
        }

        private void FormLogin_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formLogin_842JF");
        }

        private void FormLogin_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }
    }
}
