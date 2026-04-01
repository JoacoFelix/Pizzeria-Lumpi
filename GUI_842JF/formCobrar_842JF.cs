using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
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
using XAct;

namespace GUI_842JF
{
    public partial class formCobrar_842JF : Form, IIdiomaObserver_842JF
    {
        BLLPedido_842JF bllpedido;
        public BEPedido_842JF pedido;
        public string medio;
        IdiomaManager_842JF IM_842JF;
        public formCobrar_842JF()
        {
            InitializeComponent();
            bllpedido = new BLLPedido_842JF();
            pedido = new BEPedido_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formCobrar_842JF");
            Actualizar_842JF();
        }

        private void formCobrar_842JF_Load(object sender, EventArgs e)
        {

        }
        public void Pedido_842JF(BEPedido_842JF p)
        {
            pedido = p;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pedido.cliente_842JF.DNI_842JF != string.Empty)
                {
                    decimal vuelto = 0;
                    if (!Regex.IsMatch(textBox4.Text, @"^[0-9]"))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.montoInvalido"));
                    }
                    decimal pagocon = Convert.ToDecimal(textBox4.Text);
                    if (pagocon < pedido.total_842JF)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.montoBajo"));
                    }
                    vuelto = pagocon - pedido.total_842JF;
                    msgBox_842JF.Show_842JF($"{IM_842JF.ObtenerString_842JF("mensaje.vuelto")}: {vuelto}.", IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"),MessageBoxIcon.Information);
                    bllpedido.Pagar_842JF(pedido);
                    medio = "Efectivo";
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.pagado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHay"));
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pedido.cliente_842JF.DNI_842JF != string.Empty)
                {
                    if (!Regex.IsMatch(textBox1.Text, @"^[0-9]{16}$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.tarjetaInvalida"));
                    if (textBox2.Text.Any(char.IsDigit))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                    if (!Regex.IsMatch(textBox3.Text, @"^[0-9]{3}$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cvvInvalido"));
                    if(DateTime.Now > dateTimePicker1.Value)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.vencida"));
                    bllpedido.Pagar_842JF(pedido);
                    medio = "Tarjeta";
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.pagado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHay"));
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formCobrar_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formCobrar_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblNumero");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblCvv");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblVencimiento");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblPagaCon");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnConfirmar");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnEfectivo");
        }

        private void formCobrar_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formCobrar_842JF");
        }
    }
}
