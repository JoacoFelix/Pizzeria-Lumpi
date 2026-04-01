using System.Data;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Threading;
using DAL_842JF;
using Servicios_842JF.Singleton;


namespace GUI_842JF
{
    public partial class formGenerarFactura_842JF : Form, IIdiomaObserver_842JF
    {
        BLLPedido_842JF bllpedido;
        BEPedido_842JF pedidoAFacturar;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLProducto_842JF bllproducto;
        string medio;
        BLLFactura_842JF bllfactura_842JF;
        IdiomaManager_842JF IM_842JF;
        public formGenerarFactura_842JF()
        {
            InitializeComponent();
            bllpedido = new BLLPedido_842JF();
            bllfactura_842JF = new BLLFactura_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllproducto = new BLLProducto_842JF();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pedidoAFacturar = new BEPedido_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");
            Actualizar_842JF();
        }
        private void ActualizarGrilla_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");
            dataGridView1.DataSource = null;
            var linq = from x in bllpedido.ObtenerTodos_842JF() where x.pago_842JF == false select new { nroPedido = x.nroPedido_842JF, Cliente = x.cliente_842JF, Estado = x.estado_842JF, Total = x.total_842JF, Pago = x.pago_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["nroPedido"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.numero");
            dataGridView1.Columns["Cliente"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cliente");
            dataGridView1.Columns["Estado"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.estado");
            dataGridView1.Columns["Total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView1.Columns["Pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
        }
        private void formGenerarFactura_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formGenerarFactura_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");
            Actualizar_842JF();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            var linq = from x in bllpedido.ObtenerNoCobrados_842JF() where x.cliente_842JF.DNI_842JF.StartsWith(s) select new { nroPedido = x.nroPedido_842JF, Cliente = x.cliente_842JF, Estado = x.estado_842JF, Total = x.total_842JF, Pago = x.pago_842JF };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["nroPedido"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.numero");
            dataGridView1.Columns["Cliente"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cliente");
            dataGridView1.Columns["Estado"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.estado");
            dataGridView1.Columns["Total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView1.Columns["Pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    var p = bllpedido.ObtenerNoCobrados_842JF().FirstOrDefault(x => x.nroPedido_842JF == n);
                    bllpedido.CancelarPedido_842JF(p);
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.cancelado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    ActualizarGrilla_842JF();
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
        public void PedidoAFacturar_842JF(BEPedido_842JF pedido, string medio)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");
            pedidoAFacturar = pedido;
            BEFactura_842JF factura = new BEFactura_842JF(bllfactura_842JF.ObtenerTodos_842JF().Count + 1, DateTime.Now, medio, pedidoAFacturar);
            factura.total_842JF = pedidoAFacturar.total_842JF;
            bllfactura_842JF.CrearFactura_842JF(factura);
            ////
            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Ventas", "Generar Factura", 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int num = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    var p = bllpedido.ObtenerNoCobrados_842JF().FirstOrDefault(x => x.nroPedido_842JF == num);
                    using (formCobrar_842JF forcobrar_842JF = new formCobrar_842JF())
                    {
                        forcobrar_842JF.Pedido_842JF(p);
                        if (forcobrar_842JF.ShowDialog() == DialogResult.OK)
                        {
                            pedidoAFacturar = forcobrar_842JF.pedido;
                            medio = forcobrar_842JF.medio;
                        }
                    }
                    PedidoAFacturar_842JF(pedidoAFacturar, medio);
                    ActualizarGrilla_842JF();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblBuscar");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnCobrar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            ActualizarGrilla_842JF();
        }

        private void formGenerarFactura_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

    }
}
