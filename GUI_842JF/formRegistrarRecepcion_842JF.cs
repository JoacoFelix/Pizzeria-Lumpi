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
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formRegistrarRecepcion_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLOrdenDeCompra_842JF bllorden_842JF;
        BLLProducto_842JF bllproducto;
        BLLRecepcion_842JF bllrecepcion_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        public formRegistrarRecepcion_842JF()
        {
            InitializeComponent();
            bllorden_842JF = new BLLOrdenDeCompra_842JF();
            bllrecepcion_842JF = new BLLRecepcion_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllproducto = new BLLProducto_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formRegistrarRecepcion_842JF");
            Actualizar_842JF();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox1.Visible = true;
                textBox1.Text = string.Empty;
                label1.Visible = true;
                textBox2.Visible = true;
                textBox2.Text = string.Empty;
                label2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                label1.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
            }
        }

        private void formRegistrarRecepcion_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                }
                var o = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEOrdenCompra_842JF orden = bllorden_842JF.ObtenerTodos_842JF().Find(x => x.codOrdenCompra_842JF == o);
                if (checkBox1.Checked)
                {
                    bllrecepcion_842JF.Guardar_842JF(new BERecepcion_842JF(0, orden.producto_842JF, orden.proveedor_842JF, orden.cantidad_842JF, DateTime.Now, "-"));
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Registrar Recepcion de Mercaderia", 5));
                    var pro = bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == orden.producto_842JF.codProducto_842JF);
                    pro.cantidad_842JF += orden.cantidad_842JF;
                    pro.precioCompra_842JF = orden.precioUnitario_842JF;
                    bllproducto.Modificar_842JF(pro);
                }
                else
                {
                    if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                    }
                    bllrecepcion_842JF.Guardar_842JF(new BERecepcion_842JF(0, orden.producto_842JF, orden.proveedor_842JF, int.Parse(textBox2.Text), DateTime.Now, textBox1.Text));
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Registrar Recepcion de Mercaderia", 5));
                    var pro = bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == orden.producto_842JF.codProducto_842JF);
                    pro.cantidad_842JF += int.Parse(textBox2.Text);
                    pro.precioCompra_842JF = orden.precioUnitario_842JF;
                    bllproducto.Modificar_842JF(pro);
                }
                bllorden_842JF.Recibir_842JF(orden);
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.recibido"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                ActualizarGrilla_842JF();
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarRecepcion_842JF");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnRegistrar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("button.btnTodoOk");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblDescripcion");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblCantidad");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblOrdenes");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblRecepciones");
            ActualizarGrilla_842JF();
        }
        private void ActualizarGrilla_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarRecepcion_842JF");
            dataGridView1.DataSource = null;
            var linq = from x in bllorden_842JF.ObtenerTodos_842JF() where x.recibida_842JF == false && x.pago_842JF == true select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, pago = x.pago_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["codOrden"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoOrd");
            dataGridView1.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView1.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView1.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView1.Columns["precioUnitario"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioUnitario");
            dataGridView1.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView1.Columns["pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
            dataGridView1.Columns["total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView2.DataSource = null;
            var linq2 = from x in bllrecepcion_842JF.ObtenerTodos_842JF() select new { codRecepcion = x.codRecepcion_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, cantidad = x.cantidad_842JF, fecha = x.fecha_842JF, descripcion = x.descripcion_842JF };
            dataGridView2.DataSource = linq2.ToList();
            dataGridView2.Columns["codRecepcion"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoRecep");
            dataGridView2.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView2.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView2.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView2.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView2.Columns["descripcion"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.descripcion");
        }

        private void formRegistrarRecepcion_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formRegistrarRecepcion_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarRecepcion_842JF");
            ActualizarGrilla_842JF();
        }
    }
}
