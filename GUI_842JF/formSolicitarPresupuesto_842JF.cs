using System.Data;
using BE_842JF;
using BLL_842JF;
using DAL_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formSolicitarPresupuesto_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLProveedor_842JF bllproveedor_842JF;
        BLLProducto_842JF bllproducto_842JF;
        BLLSolicitudPresupuesto_842JF bllsolicitud_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        public formSolicitarPresupuesto_842JF()
        {
            InitializeComponent();
            bllproducto_842JF = new BLLProducto_842JF();
            bllproveedor_842JF = new BLLProveedor_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllsolicitud_842JF = new BLLSolicitudPresupuesto_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formSolicitarPresupuesto_842JF");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnPreRegistrar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnAgregar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnSolicitado");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnEliminar");
            ActualizarGrillas();
        }
        private void ActualizarGrillas()
        {
            IM_842JF.CargarFormulario_842JF("formSolicitarPresupuesto_842JF");
            dataGridView1.DataSource = null;
            var linq = from x in bllproducto_842JF.ObtenerTodos_842JF() select new { codProducto = x.codProducto_842JF, nombre = x.nombre_842JF, descripcion = x.descripcion_842JF, precioCompra = x.precioCompra_842JF, cantidad = x.cantidad_842JF, medida = x.medida_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["codProducto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigo");
            dataGridView1.Columns["nombre"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns["descripcion"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.descripcion");
            dataGridView1.Columns["precioCompra"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioCompra");
            dataGridView1.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView1.Columns["medida"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.medida");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formSolicitarPresupuesto_842JF");
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                }
                var c = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEProducto_842JF prod = bllproducto_842JF.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == c);
                if (listBox1.Items.Contains(prod.nombre_842JF.ToString()))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaSeAgrego"));
                }
                listBox1.Items.Add(prod.nombre_842JF.ToString());
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formSolicitarPresupuesto_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formSolicitarPresupuesto_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count > 0)
                {
                    IM_842JF.CargarFormulario_842JF("formSolicitarPresupuesto_842JF");
                    var linq = from x in bllproveedor_842JF.ObtenerTodos_842JF() where x.productos_842JF.Any(x => x.nombre_842JF == listBox1.SelectedItems[0].ToString()) select new { CUIT = x.CUIT_842JF, nombre = x.nombre_842JF, telefono = x.telefono_842JF, estado = x.estado_842JF, mail = x.mail_842JF, direccion = x.direccion_842JF };
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = linq.ToList();
                    dataGridView2.Columns["CUIT"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cuit");
                    dataGridView2.Columns["nombre"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
                    dataGridView2.Columns["telefono"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
                    dataGridView2.Columns["estado"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.estado");
                    dataGridView2.Columns["mail"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
                    dataGridView2.Columns["direccion"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.direccion");
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0 && dataGridView2.SelectedRows.Count > 0)
                {
                    BEProducto_842JF prod = bllproducto_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == listBox1.SelectedItems[0].ToString());
                    var c = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    BEProveedor_842JF prov = bllproveedor_842JF.ObtenerTodos_842JF().Find(x => x.CUIT_842JF == c);
                    if (bllsolicitud_842JF.ObtenerTodos_842JF().Any(x => x.proveedor_842JF.CUIT_842JF == prov.CUIT_842JF && x.producto_842JF.codProducto_842JF == prod.codProducto_842JF))
                    {
                        throw new Exception();
                    }
                    bllsolicitud_842JF.Guardar_842JF(new BESolicitudPresupuesto_842JF(0, prod, prov, DateTime.Now));
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Generar Solicitud de Presupuesto", 5));
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    dataGridView2.DataSource = null;
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.solicitado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (formPreRegistrarProveedor_842JF formpreregistrarprov_842JF = new formPreRegistrarProveedor_842JF())
            {
                if (formpreregistrarprov_842JF.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void formSolicitarPresupuesto_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formSolicitarPresupuesto_842JF");
        }
    }
}
