using BE_842JF;
using BLL_842JF;
using DAL_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System.Data;

namespace GUI_842JF
{
    public partial class formGenerarOrdenDeCompra_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLProducto_842JF BLLProducto_842JF;
        BLLProveedor_842JF BLLProveedor_842JF;
        BLLSolicitudPresupuesto_842JF bllsolicitud;
        BLLOrdenDeCompra_842JF bllorden_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        public formGenerarOrdenDeCompra_842JF()
        {
            InitializeComponent();
            BLLProducto_842JF = new BLLProducto_842JF();
            bllorden_842JF = new BLLOrdenDeCompra_842JF();
            BLLProveedor_842JF = new BLLProveedor_842JF();
            bllsolicitud = new BLLSolicitudPresupuesto_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            ActualizarGrilla_842JF();
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblcantidad");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblprecioMedida");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblsolicitudes");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblordenes");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnGenerar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnEliminarSoli");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnPagar");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnEliminarOrden");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("button.btnSoloImpagas");

        }

        private void ActualizarGrilla_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            dataGridView1.DataSource = null;
            var linq = from x in bllsolicitud.ObtenerTodos_842JF() select new { codSolicitud = x.codSolicitudPresupuesto_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, fecha = x.fecha_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["codSolicitud"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoSol");
            dataGridView1.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView1.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView1.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView2.DataSource = null;
            if (checkBox1.Checked)
            {
                var linq2 = from x in bllorden_842JF.ObtenerTodos_842JF() where x.pago_842JF == false select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF, recibida = x.recibida_842JF, pago = x.pago_842JF };
                dataGridView2.DataSource = linq2.ToList();
            }
            else
            {
                var linq2 = from x in bllorden_842JF.ObtenerTodos_842JF() select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF, recibida = x.recibida_842JF, pago = x.pago_842JF };
                dataGridView2.DataSource = linq2.ToList();
            }
            dataGridView2.Columns["codOrden"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoOrd");
            dataGridView2.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView2.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView2.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView2.Columns["precioUnitario"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioUnitario");
            dataGridView2.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView2.Columns["total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView2.Columns["recibida"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.recibida");
            dataGridView2.Columns["pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHaySolicitud"));
                }
                BEProducto_842JF prod = BLLProducto_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                BEProveedor_842JF prov = BLLProveedor_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                if (bllorden_842JF.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == prod.codProducto_842JF && x.proveedor_842JF.CUIT_842JF == prov.CUIT_842JF && x.recibida_842JF == false))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaHayOrden"));
                }
                int cant = int.Parse(textBox1.Text);
                decimal precio = decimal.Parse(textBox2.Text);
                if (prov.estado_842JF == false)
                {
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.completeDatos"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    FormPrincipal_842JF padre = (FormPrincipal_842JF)this.MdiParent;
                    foreach (Form frm in padre.MdiChildren)
                    {
                        if (frm is formRegistrarProveedor_842JF)
                        {
                            frm.Close();
                            break;
                        }
                    }
                    using (formRegistrarProveedor_842JF formregistrar_842JF = new formRegistrarProveedor_842JF())
                    {
                        formregistrar_842JF.Modo_842JF("Modo Completar Datos.", prov);
                        while (formregistrar_842JF.ShowDialog() != DialogResult.OK)
                        {
                            msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.completeDatos"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        }
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seCompletaronDatos"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        ActualizarGrilla_842JF();
                    }
                }
                bllorden_842JF.Guardar_842JF(new BEOrdenCompra_842JF(0, DateTime.Now, prod, prov, precio, cant, false, false));
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seGuardoLaOrden"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Generar Orden de Compra", 2));
                ActualizarGrilla_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formGenerarOrdenDeCompra_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formGenerarOrdenDeCompra_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccioneOrden"));
                }
                BEOrdenCompra_842JF orden = bllorden_842JF.ObtenerTodos_842JF().Find(x => x.codOrdenCompra_842JF == int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                if (orden.pago_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaPaga"));
                }
                using (formRealizarPago_842JF formpago_842JF = new formRealizarPago_842JF())
                {
                    formpago_842JF.OrdenCompra_8423JF(orden);
                    if (formpago_842JF.ShowDialog() == DialogResult.OK)
                    {
                        bllorden_842JF.Pagar_842JF(orden);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Pagar Orden de Compra", 5));
                    }
                    ActualizarGrilla_842JF();
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                label6.Text = BLLProducto_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).medida_842JF;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            if (checkBox1.Checked)
            {
                var linq2 = from x in bllorden_842JF.ObtenerTodos_842JF() where x.pago_842JF == false select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF, recibida = x.recibida_842JF, pago = x.pago_842JF };
                dataGridView2.DataSource = linq2.ToList();
            }
            else
            {
                var linq2 = from x in bllorden_842JF.ObtenerTodos_842JF() select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF, recibida = x.recibida_842JF, pago = x.pago_842JF };
                dataGridView2.DataSource = linq2.ToList();
            }
            dataGridView2.Columns["codOrden"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoOrd");
            dataGridView2.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView2.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView2.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView2.Columns["precioUnitario"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioUnitario");
            dataGridView2.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView2.Columns["total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView2.Columns["recibida"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.recibida");
            dataGridView2.Columns["pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
        }

        private void formGenerarOrdenDeCompra_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            ActualizarGrilla_842JF();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    BEOrdenCompra_842JF o = bllorden_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.codOrdenCompra_842JF == int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                    if (o.pago_842JF)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaPagaNoEliminar"));
                    }
                    if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminarOrden"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllorden_842JF.EliminarOrden_842JF(o);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Eliminar Orden de Compra", 2));
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.eliminadoOrden"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        ActualizarGrilla_842JF();
                    }
                }
                catch (Exception ex)
                {

                    msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    BESolicitudPresupuesto_842JF s = bllsolicitud.ObtenerTodos_842JF().FirstOrDefault(x => x.codSolicitudPresupuesto_842JF == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                    if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminarSolicitud"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllsolicitud.Eliminar_842JF(s);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Compras", "Eliminar Solicitud de Presupuesto", 5));
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.eliminadoSolicitud"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        ActualizarGrilla_842JF();
                    }
                }
                catch (Exception ex)
                {

                    msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");
            if (dataGridView1.Rows.Count > 0)
            {
                var nro = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                BEOrdenCompra_842JF orden = bllorden_842JF.ObtenerTodos_842JF().Find(x => x.codOrdenCompra_842JF == nro);
                bllorden_842JF.ImprimirOrden_842JF(orden);
            }
        }
    }
}
