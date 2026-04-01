using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_842JF;
using BLL_842JF;
using DAL_842JF;
using Org.BouncyCastle.Asn1.X500;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formPreRegistrarProveedor_842JF : Form, IIdiomaObserver_842JF
    {
        BLLProducto_842JF bllproducto;
        IdiomaManager_842JF IM_842JF;
        BLLProveedor_842JF bllproveedor;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        public formPreRegistrarProveedor_842JF()
        {
            InitializeComponent();
            bllproducto = new BLLProducto_842JF();
            bllproveedor = new BLLProveedor_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formPreRegistrarProveedor_842JF");
            Actualizar_842JF();
        }
        private void CargarListBox()
        {
            listBox1.Items.Clear();
            foreach (var item in bllproducto.ObtenerTodos_842JF())
            {
                listBox1.Items.Add(item.nombre_842JF);
            }
        }
        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formPreRegistrarProveedor_842JF");
            CargarListBox();
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblCUIT");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblProductos");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnGuardar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formPreRegistrarProveedor_842JF");
                string cuit = textBox1.Text;
                if (!Regex.IsMatch(cuit, @"^[0-9]{2}-[0-9]{8}-[0-9]{1}$"))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cuitNoValido"));
                }
                if (bllproveedor.ObtenerTodos_842JF().Any(x => x.CUIT_842JF == cuit))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cuitRepetido"));
                }
                string nombre = textBox2.Text;
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreInvalido"));
                }
                if (bllproveedor.ObtenerTodos_842JF().Any(x => x.nombre_842JF == nombre))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreRepetido"));
                }
                if (listBox1.SelectedItems.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productosVacios"));
                }
                var aux = new List<BEProducto_842JF>();
                foreach (var item in listBox1.SelectedItems)
                {
                    aux.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == item.ToString()));
                }
                bllproveedor.Guardar_842JF(new BEProveedor_842JF(cuit, nombre, 0, false, null, null), aux);
                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "PreRegistrar Proveedor", 5));
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.preRegistrado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formPreRegistrarProveedor_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formPreRegistrarProveedor_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formPreRegistrarProveedor_842JF");
        }
    }
}
