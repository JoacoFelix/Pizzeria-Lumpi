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
using BE_842JF;
using Microsoft.VisualBasic.Devices;
using Servicios_842JF.Observer;

namespace GUI_842JF
{
    public partial class formRealizarPago_842JF : Form, IIdiomaObserver_842JF
    {
        public BEOrdenCompra_842JF orden;
        IdiomaManager_842JF IM_842JF;

        public formRealizarPago_842JF()
        {
            InitializeComponent();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formPagar_842JF");
            Actualizar_842JF();
        }
        public void OrdenCompra_8423JF(BEOrdenCompra_842JF o)
        {
            orden = o;
        }
        private void formRealizarPago_842JF_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBox1.Text, @"^[0-9]{16}$"))
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.tarjetaInvalida"));
                if (textBox2.Text.Any(char.IsDigit))
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                if (!Regex.IsMatch(textBox3.Text, @"^[0-9]{3}$"))
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cvvInvalido"));
                if (DateTime.Now > dateTimePicker1.Value)
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.vencida"));
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.pagado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formPagar_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblNumero");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblCvv");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblVencimiento");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnConfirmar");
        }

        private void formRealizarPago_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formRealizarPago_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formPagar_842JF");
        }
    }
}
