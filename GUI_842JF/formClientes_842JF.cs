using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formClientes_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        string modo = "Modo Consulta.";
        BLLCliente_842JF bllcliente_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLPedido_842JF bllpedido_842JF;
        public formClientes_842JF()
        {
            InitializeComponent();
            bllcliente_842JF = new BLLCliente_842JF();
            bllpedido_842JF = new BLLPedido_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }
        private void ActualizarGrilla_842JF()
        {
            dataGridView1.DataSource = null;
            if (radioButton1.Checked)
            {
                var linq = from x in bllcliente_842JF.ObtenerTodos_842JF() where x.activo_842JF == true select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Mail = x.mail_842JF, Telefono = x.telefono_842JF };
                dataGridView1.DataSource = linq.ToList();

            }
            else
            {
                var linq = from x in bllcliente_842JF.ObtenerTodos_842JF() where x.activo_842JF == true select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Mail = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF), Telefono = x.telefono_842JF };
                dataGridView1.DataSource = linq.ToList();
            }

            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.consulta"))
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
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
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

            }
            dataGridView1.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.DNI");
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.apellido");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
        }
        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblDNI");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblApellido");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblTelefono");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblMail");
            label6.Text = IM_842JF.ObtenerString_842JF("label.lblMensaje");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnCrear");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnModificar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnEliminar");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnAplicar");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            button7.Text = IM_842JF.ObtenerString_842JF("button.btnSerializar");
            button8.Text = IM_842JF.ObtenerString_842JF("button.btnDeserializar");
            button9.Text = IM_842JF.ObtenerString_842JF("button.btnRefrescar");
            radioButton1.Text = IM_842JF.ObtenerString_842JF("button.btnEncriptado");
            radioButton2.Text = IM_842JF.ObtenerString_842JF("button.btnDesencriptado");
            if (modo == "Modo Consulta.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            if (modo == "Modo Crear.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            if (modo == "Modo Modificar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            if (modo == "Modo Eliminar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.eliminar");
            ActualizarGrilla_842JF();
        }

        private void formClientes_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formClientes_842JF_Shown(object sender, EventArgs e)
        {
            ActualizarGrilla_842JF();
        }

        private void formClientes_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formClientes_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            modo = "Modo Crear.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            modo = "Modo Modificar.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.DNI_842JF == d);
                textBox2.Text = c.nombre_842JF;
                textBox3.Text = c.apellido_842JF;
                textBox4.Text = c.telefono_842JF.ToString();
                textBox5.Text = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(c.mail_842JF);
            }
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            modo = "Modo Act./Des.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.eliminar");
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            try
            {
                if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.crear"))
                {
                    string dni = textBox1.Text;
                    if (!Regex.IsMatch(dni, @"^[0-9]{8}$"))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniNoValido"));
                    }
                    if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => x.DNI_842JF == dni) && bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni).activo_842JF)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniRepetido"));
                    }
                    else if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => x.DNI_842JF == dni) && !bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni).activo_842JF)
                    {
                        BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dni);
                        c.activo_842JF = true;
                        bllcliente_842JF.Modificar_842JF(c);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Cliente", 5));
                    }
                    else
                    {
                        if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        string nombre = textBox2.Text;
                        string apellido = textBox3.Text;
                        if (!textBox4.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.letrasTelefono"));
                        string telefono = textBox4.Text;
                        string mail = textBox5.Text;
                        if (!Regex.IsMatch(mail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                        if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF) == mail))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                        bllcliente_842JF.RegistrarCliente_842JF(new BECliente_842JF(dni, nombre, apellido, Servicios_842JF.Encriptador_842JF.EncriptarReversible_842JF(mail), Convert.ToInt32(telefono), true));
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Cliente", 5));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.DNI_842JF == d);
                        if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        if (!Regex.IsMatch(textBox5.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                        if (bllcliente_842JF.ObtenerTodos_842JF().Any(x => Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF) == textBox5.Text) && textBox5.Text != Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(c.mail_842JF))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                        if (!textBox4.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.letrasTelefono"));
                        c.nombre_842JF = textBox2.Text;
                        c.apellido_842JF = textBox3.Text;
                        c.telefono_842JF = Convert.ToInt32(textBox4.Text);
                        c.mail_842JF = Servicios_842JF.Encriptador_842JF.EncriptarReversible_842JF(textBox5.Text);
                        bllcliente_842JF.Modificar_842JF(c);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Modificar Cliente", 3));

                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.eliminar"))
                {
                    if (bllpedido_842JF.ObtenerNoCobrados_842JF().Any(x => x.cliente_842JF.DNI_842JF == bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString()).DNI_842JF))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.pedidoActivo"));
                    }
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            c.activo_842JF = false;
                            bllcliente_842JF.Modificar_842JF(c);
                            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Eliminar Cliente", 3));
                            msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.eliminado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                modo = "Modo Consulta.";
                textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
                ActualizarGrilla_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
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
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            modo = "Modo Consulta.";
            ActualizarGrilla_842JF();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_842JF();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                List<BECliente_842JF> clientes = (from x in bllcliente_842JF.ObtenerTodos_842JF() where x.activo_842JF == true select x).ToList();
                if (radioButton2.Checked)
                {
                    clientes = DesencriptarMails_842JF(clientes);
                }
                if (clientes == null) msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.listaVacia"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title = "ArchivoClientes";
                    sfd.Filter = "Archivo XML|*.xml";
                    sfd.FileName = $"XMLClientes_{DateTime.Now:yyyyMMdd_HHmm}.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var serializer = new XmlSerializer(typeof(List<BECliente_842JF>));
                        using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            serializer.Serialize(fs, clientes);
                        }
                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.exitoXML"), "", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    }
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
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Abrir archivo de clientes";
                    ofd.Filter = "Archivo XML|*.xml";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        List<BECliente_842JF> clientes = null;

                        var serializer = new XmlSerializer(typeof(List<BECliente_842JF>));
                        using (var fs = new FileStream(ofd.FileName, FileMode.Open))
                        {
                            clientes = (List<BECliente_842JF>)serializer.Deserialize(fs);
                        }

                        if (clientes == null || clientes.Count == 0)
                        {
                            msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.listaVacia"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
                            return;
                        }
                        string[] lineas = File.ReadAllLines(ofd.FileName);

                        foreach (string linea in lineas)
                        {
                            listBox1.Items.Add(linea);
                        }
                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                        {
                            List<BECliente_842JF> clientesDeserializados = (List<BECliente_842JF>)serializer.Deserialize(fs);
                            foreach (var item in clientesDeserializados)
                            {
                                listBox2.Items.Add($"{IM_842JF.ObtenerString_842JF("datagridview.columna.DNI")}: {item.DNI_842JF}");
                                listBox2.Items.Add($"{IM_842JF.ObtenerString_842JF("datagridview.columna.nombre")}: {item.nombre_842JF}");
                                listBox2.Items.Add($"{IM_842JF.ObtenerString_842JF("datagridview.columna.apellido")}: {item.apellido_842JF}");
                                listBox2.Items.Add($"{IM_842JF.ObtenerString_842JF("datagridview.columna.mail")}: {item.mail_842JF}");
                                listBox2.Items.Add($"{IM_842JF.ObtenerString_842JF("datagridview.columna.telefono")}: {item.telefono_842JF}");
                                listBox2.Items.Add($"-------------------------------");
                            }
                        }
                        ActualizarGrillaDesdeXml_842JF(clientes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<BECliente_842JF> DesencriptarMails_842JF(List<BECliente_842JF> clientes)
        {
            foreach (var item in clientes)
            {
                item.mail_842JF = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(item.mail_842JF);
            }
            return clientes;
        }
        private void ActualizarGrillaDesdeXml_842JF(List<BECliente_842JF> clientes)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            dataGridView1.DataSource = null;
            var linq = from x in clientes where x.activo_842JF == true select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Mail = x.mail_842JF, Telefono = x.telefono_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.DNI");
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.apellido");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button7.Visible = true;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            ActualizarGrilla_842JF();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formClientes_842JF");
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    BECliente_842JF c = bllcliente_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.DNI_842JF == d);
                    textBox2.Text = c.nombre_842JF;
                    textBox3.Text = c.apellido_842JF;
                    textBox4.Text = c.telefono_842JF.ToString();
                    textBox5.Text = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(c.mail_842JF);
                }
            }
            
        }
    }
}
