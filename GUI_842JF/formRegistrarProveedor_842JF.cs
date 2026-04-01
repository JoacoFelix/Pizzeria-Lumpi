using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_842JF
{
    public partial class formRegistrarProveedor_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        string modo = "Modo Consulta.";
        BEProveedor_842JF provACompletar;
        BLLProveedor_842JF bllproveedor_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLProducto_842JF bllproducto;
        BLLOrdenDeCompra_842JF bllorden;
        BLLSolicitudPresupuesto_842JF bllsolicitud;

        public formRegistrarProveedor_842JF()
        {
            InitializeComponent();
            bllproveedor_842JF = new BLLProveedor_842JF();
            bllproducto = new BLLProducto_842JF();
            provACompletar = null;
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllorden = new BLLOrdenDeCompra_842JF();
            bllsolicitud = new BLLSolicitudPresupuesto_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblCUIT");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblTelefono");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblMail");
            label7.Text = IM_842JF.ObtenerString_842JF("label.lblDireccion");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblProductos");
            label6.Text = IM_842JF.ObtenerString_842JF("label.lblMensaje");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnAgregarProd");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCrear");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnModificar");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnEliminar");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnAplicar");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button7.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            button8.Text = IM_842JF.ObtenerString_842JF("button.btnEliminarProd");
            if (modo == "Modo Consulta.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            if (modo == "Modo Crear.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            if (modo == "Modo Modificar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            if (modo == "Modo Eliminar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.eliminar");
            if (modo == "Modo Completar Datos.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.CompletarDatos");
            ActualizarGrilla_842JF();
        }
        public void Modo_842JF(string modoafuera, BEProveedor_842JF prov)
        {
            modo = modoafuera;
            provACompletar = prov;
            textBox6.Text = modo;
            ActualizarGrilla_842JF();
        }
        private void ActualizarGrilla_842JF()
        {
            dataGridView1.DataSource = null;
            var linq = from x in bllproveedor_842JF.ObtenerTodos_842JF() select new { CUIT = x.CUIT_842JF, Nombre = x.nombre_842JF, Telefono = x.telefono_842JF, Estado = x.estado_842JF, Mail = x.mail_842JF, Direccion = x.direccion_842JF };
            dataGridView1.DataSource = linq.ToList();
            button1.Enabled = false;
            button8.Enabled = false;
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.consulta"))
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                textBox1.Visible = false;
                textBox1.Text = string.Empty;
                textBox2.Visible = false;
                textBox2.Text = string.Empty;
                textBox3.Visible = false;
                textBox3.Text = string.Empty;
                textBox4.Visible = false;
                textBox4.Text = string.Empty;
                textBox5.Visible = false;
                textBox5.Text = string.Empty;
                label1.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                label3.Visible = false;
                listBox1.Visible = false;
                button1.Visible = true;
                button8.Visible = true;
            }
            dataGridView1.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.CUIT");
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.estado");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.direccion");
            listBox1.Items.Clear();
            foreach (var item in bllproducto.ObtenerTodos_842JF())
            {
                listBox1.Items.Add(item.nombre_842JF);
            }
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.CompletarDatos"))
            {
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label3.Visible = false;
                listBox1.Visible = false;
                button5.Enabled = true;
                button6.Enabled = false;
                textBox1.Visible = false;
                textBox1.Text = string.Empty;
                textBox2.Visible = false;
                textBox2.Text = string.Empty;
                textBox3.Visible = true;
                textBox3.Text = string.Empty;
                textBox4.Visible = true;
                textBox4.Text = string.Empty;
                textBox5.Visible = true;
                textBox5.Text = string.Empty;
                label1.Visible = false;
                label2.Visible = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button8.Enabled = false;
                dataGridView1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            modo = "Modo Crear.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            label3.Visible = true;
            listBox1.Visible = true;
        }

        private void formRegistrarProveedor_842JF_Load(object sender, EventArgs e)
        {
            if (this.MdiParent is FormPrincipal_842JF)
            {
                this.Dock = DockStyle.Fill;
                this.Size = new Size(this.Parent.Width, this.Parent.Height);
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void formRegistrarProveedor_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            ActualizarGrilla_842JF();
        }

        private void formRegistrarProveedor_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            modo = "Modo Modificar.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                BEProveedor_842JF p = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.CUIT_842JF == d);
                textBox2.Text = p.nombre_842JF;
                textBox3.Text = p.telefono_842JF.ToString();
                textBox4.Text = p.mail_842JF;
                textBox5.Text = p.direccion_842JF;
            }
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            label3.Visible = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            listBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            modo = "Modo Eliminar";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.eliminar");
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            try
            {
                if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.crear"))
                {
                    string cuit = textBox1.Text;
                    if (!Regex.IsMatch(cuit, @"^[0-9]{2}-[0-9]{8}-[0-9]{1}$"))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cuitNoValido"));
                    }
                    if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.CUIT_842JF == cuit))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.cuitRepetido"));
                    }
                    else
                    {
                        if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (textBox2.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.nombre_842JF == textBox2.Text))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreRepetido"));
                        string nombre = textBox2.Text;
                        if (!textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.letrasTelefono"));
                        int telefono = int.Parse(textBox3.Text);
                        string mail = textBox4.Text;
                        if (!Regex.IsMatch(mail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                        if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.mail_842JF == mail))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                        string direccion = textBox5.Text;
                        if (!Regex.IsMatch(textBox5.Text, @"^[A-Za-z ]{1,20} [0-9]{1,4}$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.direccionInvalida"));
                        if (listBox1.SelectedItems.Count == 0)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productosVacios"));
                        }
                        var aux = new List<BEProducto_842JF>();
                        foreach (var item in listBox1.SelectedItems)
                        {
                            aux.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == item.ToString()));
                        }
                        bllproveedor_842JF.Guardar_842JF(new BEProveedor_842JF(cuit, nombre, telefono, true, mail, direccion), aux);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Proveedor", 5));
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.creado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        BEProveedor_842JF c = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.CUIT_842JF == d);
                        if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.nombre_842JF == textBox2.Text && textBox2.Text != c.nombre_842JF))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreRepetido"));
                        if (textBox2.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                        if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.mail_842JF == textBox5.Text) && textBox5.Text != c.mail_842JF)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                        if (!Regex.IsMatch(textBox5.Text, @"^[A-Za-z ]{1,20} [0-9]{1,4}$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.direccionInvalida"));
                        c.nombre_842JF = textBox2.Text;
                        bllproveedor_842JF.Modificar_842JF(c, int.Parse(textBox3.Text), true, textBox4.Text, textBox5.Text);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Modificar Proveedor", 3));
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.modificado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.eliminar"))
                {
                    if (bllsolicitud.ObtenerTodos_842JF().Any(x => x.proveedor_842JF.CUIT_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.solicitudGenerada"));
                    }
                    if (bllorden.ObtenerTodos_842JF().Any(x => x.proveedor_842JF.CUIT_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.ordenGenerada"));
                    }
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        BEProveedor_842JF c = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.CUIT_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bllproveedor_842JF.EliminarPrroveedor_842JF(c);
                            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Eliminar Proveedor", 3));
                            msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.eliminado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.CompletarDatos"))
                {
                    if (textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                    if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                    if (bllproveedor_842JF.ObtenerTodos_842JF().Any(x => x.mail_842JF == textBox4.Text))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                    if (!Regex.IsMatch(textBox5.Text, @"^[A-Za-z ]{1,20} [0-9]{1,4}$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.direccionInvalida"));
                    bllproveedor_842JF.Modificar_842JF(provACompletar, int.Parse(textBox3.Text), true, textBox4.Text, textBox5.Text);
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Proveedor", 5));
                    this.DialogResult = DialogResult.OK;
                }
                modo = "Modo Consulta.";
                listBox1.SelectionMode = SelectionMode.One;
                textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
                ActualizarGrilla_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
            {
                label3.Visible = true;
                listBox1.Visible = true;
                button1.Enabled = true;
                button8.Enabled = true;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    BEProveedor_842JF c = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.CUIT_842JF == d);
                    textBox2.Text = c.nombre_842JF;
                    textBox3.Text = c.telefono_842JF.ToString();
                    textBox4.Text = c.mail_842JF;
                    textBox5.Text = c.direccion_842JF;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var c = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    BEProveedor_842JF p = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.CUIT_842JF == c);
                    if (listBox1.SelectedItems.Count == 0)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productosVacios"));
                    }
                    BEProducto_842JF aux = bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == listBox1.SelectedItem.ToString());
                    if (p.productos_842JF.Any(x => x.codProducto_842JF == aux.codProducto_842JF))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productoRepetido"));
                    }
                    bllproveedor_842JF.AgregarProducto_842JF(p, aux);
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Agregar Producto a Proveedor", 5));
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.productoAgregado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var c = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    BEProveedor_842JF p = bllproveedor_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.CUIT_842JF == c);
                    if (listBox1.SelectedItems.Count == 0)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productosVacios"));
                    }
                    BEProducto_842JF aux = bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == listBox1.SelectedItem.ToString());
                    if (!p.productos_842JF.Any(x => x.codProducto_842JF == aux.codProducto_842JF))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productoNoEncontrado"));
                    }
                    if (bllorden.ObtenerTodos_842JF().Any(x => x.proveedor_842JF.CUIT_842JF == p.CUIT_842JF && x.producto_842JF.codProducto_842JF == aux.codProducto_842JF && x.recibida_842JF == false))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.ordenEnCurso"));
                    }
                    if (bllsolicitud.ObtenerTodos_842JF().Any(x => x.proveedor_842JF.CUIT_842JF == p.CUIT_842JF && x.producto_842JF.codProducto_842JF == aux.codProducto_842JF))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.solicitudRealizada"));
                    }
                    bllproveedor_842JF.EliminarProducto_842JF(p, aux);
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Eliminar producto a Proveedor", 5));
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.productoEliminado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formRegistrarProveedor_842JF");
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            listBox1.Visible = false;
            listBox1.SelectionMode = SelectionMode.One;
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            modo = "Modo Consulta.";
            ActualizarGrilla_842JF();
        }
    }
}
