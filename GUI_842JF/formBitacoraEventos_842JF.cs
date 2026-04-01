using System.Data;
using System.Windows.Forms;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;

namespace GUI_842JF
{
    public partial class formBitacoraEventos_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLUsuario_842JF bllusuario_842JF;
        BLLBitacoraEvento_842JF bllBitacoraEvento_842JF;
        IEnumerable<BEEvento_842JF> linq;
        public formBitacoraEventos_842JF()
        {
            InitializeComponent();
            bllBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllusuario_842JF = new BLLUsuario_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            linq = null;
            Actualizar_842JF();
        }
        private void CargarGrilla_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            dataGridView1.DataSource = null;
            linq = from x in bllBitacoraEvento_842JF.ObtenerTodos_842JF() where (DateTime.Now.DayOfYear - x.fechaHora_842JF.DayOfYear) <= 3 select x;
            dataGridView1.DataSource = linq.ToList();
            ActualizarGrillas_842JF();
        }
        private void ActualizarGrillas_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.login");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fechaHora");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.modulo");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.evento");
            dataGridView1.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.criticidad");
        }
        private void formBitacoraEventos_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            foreach (var item in bllusuario_842JF.ObtenerTodos_842JF())
            {
                comboBox1.Items.Add(item.login_842JF);
            }
        }

        public void Actualizar_842JF()
        {
            LimpiarFiltros_842JF();
            VerificarFiltros_842JF();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.nombre");
            label2.Text = IM_842JF.ObtenerString_842JF("label.apellido");
            label3.Text = IM_842JF.ObtenerString_842JF("label.login");
            label4.Text = IM_842JF.ObtenerString_842JF("label.fechaInicio");
            label5.Text = IM_842JF.ObtenerString_842JF("label.fechaFin");
            label6.Text = IM_842JF.ObtenerString_842JF("label.modulo");
            label7.Text = IM_842JF.ObtenerString_842JF("label.evento");
            label8.Text = IM_842JF.ObtenerString_842JF("label.criticidad");
            button1.Text = IM_842JF.ObtenerString_842JF("button.limpiar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.aplicar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.salir");
            button4.Text = IM_842JF.ObtenerString_842JF("button.imprimir");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("button.fecha");
            comboBox2.Items.Add(IM_842JF.ObtenerString_842JF("modulos.usuarios"));
            comboBox2.Items.Add(IM_842JF.ObtenerString_842JF("modulos.maestros"));
            comboBox2.Items.Add(IM_842JF.ObtenerString_842JF("modulos.admin"));
            comboBox2.Items.Add(IM_842JF.ObtenerString_842JF("modulos.ventas"));
            comboBox2.Items.Add(IM_842JF.ObtenerString_842JF("modulos.compras"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.login"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.logout"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarCliente"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarCliente"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarCliente"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarProveedor"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProveedor"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarProveedor"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarUsuario"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarUsuario"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearPerfil"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearFamilia"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarFamilia"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarPerfil"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarFactura"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarOrdenCompra"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.backUp"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.restore"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarSolicitud"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.pagarOrden"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarOrden"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.preRegistrarProveedor"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.agregrarProductoAProv"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProductoAProv"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarRecepcion"));
            comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarSolicitudPresupuesto"));
            CargarGrilla_842JF();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var log = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                var u = bllusuario_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.login_842JF == log);
                textBox1.Text = u.nombre_842JF;
                textBox2.Text = u.apellido_842JF;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
            comboBox3.Items.Clear();
            if (comboBox2.Text == string.Empty)
            {
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.login"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.logout"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarCliente"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarCliente"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarCliente"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarProveedor"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProveedor"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarProveedor"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarUsuario"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarUsuario"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearPerfil"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearFamilia"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarFamilia"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarPerfil"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarFactura"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarOrdenCompra"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.backUp"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.restore"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarSolicitud"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.pagarOrden"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarOrden"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.preRegistrarProveedor"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.agregrarProductoAProv"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProductoAProv"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarRecepcion"));
                comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarSolicitudPresupuesto"));
            }
            else
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.login"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.logout"));
                        break;
                    case 1:
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.preRegistrarProveedor"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarCliente"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarCliente"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarCliente"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarProveedor"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProveedor"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarProveedor"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.agregrarProductoAProv"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarProductoAProv"));
                        break;
                    case 2:
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarUsuario"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.modificarUsuario"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearPerfil"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.crearFamilia"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarFamilia"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarPerfil"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.backUp"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.restore"));
                        break;
                    case 3:
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarFactura"));
                        break;
                    case 4:
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarOrdenCompra"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.registrarRecepcion"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.generarSolicitudPresupuesto"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarSolicitud"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.pagarOrden"));
                        comboBox3.Items.Add(IM_842JF.ObtenerString_842JF("eventos.eliminarOrden"));
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarFiltros_842JF();
        }
        private void LimpiarFiltros_842JF()
        {
            CargarGrilla_842JF();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox4.Visible = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            checkBox1.Checked = false;
            VerificarFiltros_842JF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
                string c2 = string.Empty;
                string c3 = string.Empty;
                if (checkBox1.Checked)
                {
                    if(dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.fechamal"));
                    }
                }
                if (comboBox2.Text == IM_842JF.ObtenerString_842JF("modulos.usuarios") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.login") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.logout"))
                {
                    c2 = "Usuarios";
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.login"))
                    {
                        c3 = "Iniciar Sesión";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.logout"))
                    {
                        c3 = "Cerrar Sesión";
                    }

                }
                if (comboBox2.Text == IM_842JF.ObtenerString_842JF("modulos.maestros") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarCliente") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarCliente") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarProveedor") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarProveedor") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarProveedor") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarProducto") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarProducto") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarProducto"))
                {
                    c2 = "Maestros";
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarCliente"))
                    {
                        c3 = "Registrar Cliente";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarCliente"))
                    {
                        c3 = "Modificar Cliente";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarProveedor"))
                    {
                        c3 = "Registrar Proveedor";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarProveedor"))
                    {
                        c3 = "Eliminar Proveedor";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarProveedor"))
                    {
                        c3 = "Modificar Proveedor";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.preRegistrarProveedor"))
                    {
                        c3 = "PreRegistrar Proveedor";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.agregrarProductoAProv"))
                    {
                        c3 = "Agregar Producto a Proveedor";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarProductoAProv"))
                    {
                        c3 = "Eliminar producto a Proveedor";
                    }
                }
                if (comboBox2.Text == IM_842JF.ObtenerString_842JF("modulos.admin") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarUsuario") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarUsuario") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.crearPerfil") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.crearFamilia") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarFamilia") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarPerfil") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.backUp") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.restore"))
                {
                    c2 = "Admin";
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarUsuario"))
                    {
                        c3 = "Registrar Usuario";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.modificarUsuario"))
                    {
                        c3 = "Modificar Usuario";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.crearPerfil"))
                    {
                        c3 = "Generar Perfil";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.crearFamilia"))
                    {
                        c3 = "Generar Familia";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarFamilia"))
                    {
                        c3 = "Eliminar Familia";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarPerfil"))
                    {
                        c3 = "Eliminar Perfil";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.backUp"))
                    {
                        c3 = "BackUp";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.restore"))
                    {
                        c3 = "Restore";
                    }
                }
                if (comboBox2.Text == IM_842JF.ObtenerString_842JF("modulos.ventas") || comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.generarFactura"))
                {
                    c2 = "Ventas";
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.generarFactura"))
                    {
                        c3 = "Generar Factura";
                    }

                }
                if (comboBox2.Text == IM_842JF.ObtenerString_842JF("modulos.compras"))
                {
                    c2 = "Compras";
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.generarOrdenCompra"))
                    {
                        c3 = "Generar Orden de Compra";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarSolicitud"))
                    {
                        c3 = "Eliminar Solicitud de Presupuesto";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.pagarOrden"))
                    {
                        c3 = "Pagar Orden de Compra";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.eliminarOrden"))
                    {
                        c3 = "Eliminar Orden de Compra";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.registrarRecepcion"))
                    {
                        c3 = "Registrar Recepcion de Mercaderia";
                    }
                    if (comboBox3.Text == IM_842JF.ObtenerString_842JF("eventos.generarSolicitudPresupuesto"))
                    {
                        c3 = "Generar Solicitud de Presupuesto";
                    }
                }
                if (checkBox1.Checked && comboBox4.Text.Length > 0)
                {
                    linq = from x in bllBitacoraEvento_842JF.ObtenerTodos_842JF() where x.login_842JF.StartsWith(comboBox1.Text) && x.modulo_842JF.StartsWith(c2) && x.evento_842JF.StartsWith(c3) && x.criticidad_842JF == Convert.ToInt32(comboBox4.Text) && x.fechaHora_842JF.Date >= dateTimePicker1.Value.Date && x.fechaHora_842JF.Date <= dateTimePicker2.Value.Date select x;

                }
                else if (checkBox1.Checked && comboBox4.Text.Length == 0)
                {
                    linq = from x in bllBitacoraEvento_842JF.ObtenerTodos_842JF() where x.login_842JF.StartsWith(comboBox1.Text) && x.modulo_842JF.StartsWith(c2) && x.evento_842JF.StartsWith(c3) && x.fechaHora_842JF.Date >= dateTimePicker1.Value.Date && x.fechaHora_842JF.Date <= dateTimePicker2.Value.Date select x;

                }
                else if (!checkBox1.Checked && comboBox4.Text.Length == 0)
                {
                    linq = from x in bllBitacoraEvento_842JF.ObtenerTodos_842JF() where x.login_842JF.StartsWith(comboBox1.Text) && x.modulo_842JF.StartsWith(c2) && x.evento_842JF.StartsWith(c3) select x;
                }
                else
                {
                    linq = from x in bllBitacoraEvento_842JF.ObtenerTodos_842JF() where x.login_842JF.StartsWith(comboBox1.Text) && x.modulo_842JF.StartsWith(c2) && x.evento_842JF.StartsWith(c3) && x.criticidad_842JF == Convert.ToInt32(comboBox4.Text) select x;
                }
                if(linq.ToList().Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayEvento"));
                }
                ActualizarGrillas_842JF();
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

        private void formBitacoraEventos_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
            if(comboBox3.Text.Length > 0)
            {
                label8.Visible = false;
                comboBox4.SelectedIndex = -1;
                comboBox4.Visible = false;
            }
            else
            {
                label8.Visible = true;
                comboBox4.SelectedIndex = -1;
                comboBox4.Visible = true;
                
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
        }
        private void VerificarFiltros_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            if (!checkBox1.Checked && comboBox1.Text == string.Empty && comboBox2.Text == string.Empty && comboBox3.Text == string.Empty && comboBox4.Text == string.Empty)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.grillaVacia"));
                }
                bllBitacoraEvento_842JF.GenerarReporte_842JF(linq.ToList());
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formBitacoraEventos_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            LimpiarFiltros_842JF();
        }
    }
}
