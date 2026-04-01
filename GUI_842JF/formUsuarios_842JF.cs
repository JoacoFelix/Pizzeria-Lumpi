using BE_842JF;
using BLL_842JF;
using Servicios_842JF;
using Servicios_842JF.Composite;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_842JF
{
    public partial class formUsuarios_842JF : Form, IIdiomaObserver_842JF
    {
        BLLUsuario_842JF bllUsuario_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        Usuario_842JF u;
        IdiomaManager_842JF IM_842JF;
        BLLPerfil_842JF bllperfi_842JF;
        string modo = "Modo Consulta.";
        public formUsuarios_842JF()
        {
            InitializeComponent();
            bllUsuario_842JF = new BLLUsuario_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllperfi_842JF = new BLLPerfil_842JF();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            u = SessionManager_842JF.Instancia.Usuario_842JF;
            Actualizar_842JF();

        }
        private void botonCrear(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            modo = "Modo Crear.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            comboBox1.Visible = true;
            textBox5.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
        }
        private void ActualizarGrilla_842JF()
        {
            dataGridView1.DataSource = null;
            if (radioButton1.Checked)
            {
                var linq = from x in bllUsuario_842JF.ObtenerTodos_842JF() where x.activo_842JF == true select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Usuario = x.login_842JF, Rol = x.rol_842JF.nombre_842JF, Mail = x.mail_842JF, Activo = x.activo_842JF };
                dataGridView1.DataSource = linq.ToList();
            }
            else if (radioButton2.Checked)
            {
                var linq = from x in bllUsuario_842JF.ObtenerTodos_842JF() select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Usuario = x.login_842JF, Rol = x.rol_842JF.nombre_842JF, Mail = x.mail_842JF, Activo = x.activo_842JF };
                dataGridView1.DataSource = linq.ToList();
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                var d = item.Cells[0].Value.ToString();
                var u = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == d);
                if (u.bloqueo_842JF)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                    item.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.consulta"))
            {
                button1.Enabled = true;
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
                comboBox1.Visible = false;
                textBox5.Visible = false;
                textBox5.Text = string.Empty;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            dataGridView1.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.DNI");
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.apellido");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.usuario");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.rol");
            dataGridView1.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns[6].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.activo");
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
            comboBox1.Items.Clear();
            foreach (var item in bllperfi_842JF.ObtenerTodos_842JF())
            {
                if (item.nombre_842JF != "SuperAdmin")
                {
                    comboBox1.Items.Add(item.nombre_842JF);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_842JF();
        }

        private void botonDesbloquear(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            modo = "Modo Desbloquear.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.desbloquear");
            button5.Enabled = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void botonAplicar(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            try
            {
                if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.crear"))
                {
                    string dni = textBox1.Text;
                    if (!Regex.IsMatch(dni, @"^[0-9]{8}$"))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniNoValido"));
                    }
                    if (bllUsuario_842JF.ObtenerTodos_842JF().Any(x => x.DNI_842JF == dni))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.dniRepetido"));
                    }
                    if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || comboBox1.Text == string.Empty || textBox5.Text == string.Empty)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                    if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                    string nombre = textBox2.Text;
                    string apellido = textBox3.Text;
                    Perfil_842JF rol = bllperfi_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.nombre_842JF == comboBox1.Text);
                    string mail = textBox5.Text;
                    if (!Regex.IsMatch(mail, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                    if (bllUsuario_842JF.ObtenerTodos_842JF().Any(x => x.mail_842JF == mail))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                    bllUsuario_842JF.Guardar_842JF(new Usuario_842JF(dni, nombre, apellido, $"{dni}{nombre}", $"{dni}{apellido}", rol, mail, false, true, 0, DateTime.Now, "spanish"));
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Registrar Usuario", 4));

                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.desbloquear"))
                {
                    if (dataGridView1.SelectedRows.Count == 0)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    Usuario_842JF user = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    if (!user.bloqueo_842JF)
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.usuarioNoBloqueado"));
                    if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroDesbloquear"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllUsuario_842JF.Desbloquear_842JF(user);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Modificar Usuario", 3));

                        msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.desbloqueo"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
                        ActualizarGrilla_842JF();
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        Usuario_842JF user = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.DNI_842JF == d);
                        if (user.DNI_842JF == u.DNI_842JF)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noASiMismo"));
                        }
                        if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || comboBox1.Text == string.Empty || textBox5.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        if (!Regex.IsMatch(textBox5.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailInvalido"));
                        if (bllUsuario_842JF.ObtenerTodos_842JF().Any(x => x.mail_842JF == textBox5.Text) && textBox5.Text != user.mail_842JF)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.mailRepetido"));
                        if(user.rol_842JF.nombre_842JF == "SuperAdmin")
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.superAdmin"));
                        }
                        user.nombre_842JF = textBox2.Text;
                        user.apellido_842JF = textBox3.Text;
                        user.rol_842JF = bllperfi_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.nombre_842JF == comboBox1.Text);
                        user.mail_842JF = textBox5.Text;
                        user.login_842JF = $"{user.DNI_842JF}{user.nombre_842JF}";
                        bllUsuario_842JF.Modificar_842JF(user);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Modificar Usuario", 3));
                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.activarDesactivar"))
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        Usuario_842JF user = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.DNI_842JF == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        if (user.activo_842JF)
                        {
                            if (user.DNI_842JF == u.DNI_842JF)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.desactivarSiMismo"));
                            }
                            if (user.rol_842JF.nombre_842JF == "SuperAdmin")
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.superAdmin"));
                            }
                            if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroDesactivar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                bllUsuario_842JF.Desactivar_842JF(user);
                                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Modificar Usuario", 3));
                                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.desactivado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroActivar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                bllUsuario_842JF.Activar_842JF(user);
                                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Modificar Usuario", 3));
                                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.activado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            }
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

        private void botonModificar(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            modo = "Modo Modificar.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            textBox2.Visible = true;
            textBox3.Visible = true;
            comboBox1.Visible = true;
            textBox5.Visible = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Usuario_842JF u = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.DNI_842JF == d);
                textBox2.Text = u.nombre_842JF;
                textBox3.Text = u.apellido_842JF;
                if (u.rol_842JF.nombre_842JF != "SuperAdmin")
                {
                    comboBox1.Text = u.rol_842JF.nombre_842JF;
                }
                textBox5.Text = u.mail_842JF;
            }
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;

        }

        private void botonActivar_Desact(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            modo = "Modo Act./Des.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.activarDesactivar");
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void botonCancelar(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;
            textBox5.Visible = false;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
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

        private void botonSalir(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
            {
                var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Usuario_842JF u = bllUsuario_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.DNI_842JF == d);
                textBox2.Text = u.nombre_842JF;
                textBox3.Text = u.apellido_842JF;
                if (u.rol_842JF.nombre_842JF != "SuperAdmin")
                {
                    comboBox1.Text = u.rol_842JF.nombre_842JF;
                }
                textBox5.Text = u.mail_842JF;
            }
        }

        private void FormUsuarios_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void FormUsuarios_842JF_Shown(object sender, EventArgs e)
        {
            ActualizarGrilla_842JF();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblDNI");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblApellido");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblRol");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblMail");
            label6.Text = IM_842JF.ObtenerString_842JF("label.lblMensaje");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnCrear");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnDesbloquear");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnModificar");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnActivarDesactivar");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnAplicar");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button7.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            if (modo == "Modo Consulta.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            if (modo == "Modo Crear.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            if (modo == "Modo Desbloquear.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.desbloquear");
            if (modo == "Modo Modificar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            if (modo == "Modo Act./Des.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.activarDesactivar");
            radioButton1.Text = IM_842JF.ObtenerString_842JF("radio.rdoActivos");
            radioButton2.Text = IM_842JF.ObtenerString_842JF("radio.rdoTodos");
            ActualizarGrilla_842JF();
        }

        private void formUsuarios_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formUsuarios_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formUsuarios_842JF");
            ActualizarGrilla_842JF();
        }
    }
}
