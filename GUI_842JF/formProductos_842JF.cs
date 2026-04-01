using System.Data;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formProductos_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        string modo = "Modo Consulta.";
        BLLProducto_842JF bllproducto_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLOrdenDeCompra_842JF bllorden;
        BLLSolicitudPresupuesto_842JF bllsolicitud;
        BLLPizza_842JF bllpizza;
        public formProductos_842JF()
        {
            InitializeComponent();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            bllproducto_842JF = new BLLProducto_842JF();
            bllorden = new BLLOrdenDeCompra_842JF();
            bllsolicitud = new BLLSolicitudPresupuesto_842JF();
            bllpizza = new BLLPizza_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }
        private void ActualizarGrilla_842JF()
        {
            dataGridView1.DataSource = null;
            var linq = from x in bllproducto_842JF.ObtenerTodos_842JF() where x.disponible_842JF select new { codProducto = x.codProducto_842JF, nombre = x.nombre_842JF, descripcion = x.descripcion_842JF, precioCompra = x.precioCompra_842JF, medida = x.medida_842JF, cantidad = x.cantidad_842JF };
            dataGridView1.DataSource = linq.ToList();
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
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            dataGridView1.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codProducto");
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.descripcion");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioCompra");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.medida");
            dataGridView1.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
        }
        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblNombre");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblDescripcion");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblMedida");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblCantidad");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblPrecioCompra");
            label6.Text = IM_842JF.ObtenerString_842JF("label.lblMensaje");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnCrear");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnModificar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnEliminar");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnAplicar");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            if (modo == "Modo Consulta.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.consulta");
            if (modo == "Modo Crear.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            if (modo == "Modo Modificar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            if (modo == "Modo Eliminar.") textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.eliminar");
            ActualizarGrilla_842JF();
        }

        private void formProductos_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formProductos_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formProductos_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            ActualizarGrilla_842JF();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            modo = "Modo Crear.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.crear");
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            modo = "Modo Modificar.";
            textBox6.Text = IM_842JF.ObtenerString_842JF("textbox.modo.modificar");
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEProducto_842JF c = bllproducto_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.codProducto_842JF == d);
                textBox1.Text = c.nombre_842JF;
                textBox2.Text = c.descripcion_842JF;
                textBox3.Text = c.medida_842JF;
                textBox4.Text = c.cantidad_842JF.ToString();
                textBox5.Text = c.precioCompra_842JF.ToString();
            }
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEProducto_842JF c = bllproducto_842JF.ObtenerTodos_842JF().FirstOrDefault(c => c.codProducto_842JF == d);
                if (bllpizza.ObtenerTodas_842JF().Any(x => x.productos.Any(y => y.Key.codProducto_842JF == c.codProducto_842JF)))
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox3.Visible = false;
                    label3.Visible = false;
                }
                if (bllorden.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == c.codProducto_842JF))
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox3.Visible = false;
                    label3.Visible = false;
                }
                if (bllsolicitud.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == c.codProducto_842JF))
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox3.Visible = false;
                    label3.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            modo = "Modo Eliminar.";
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
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            try
            {
                if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.crear"))
                {
                    string nombre = textBox1.Text;
                    if (bllproducto_842JF.ObtenerTodos_842JF().Any(x => x.nombre_842JF == nombre))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreRepetido"));
                    }
                    else
                    {
                        if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        string descripcion = textBox2.Text;
                        string medida = textBox3.Text;
                        bllproducto_842JF.Guardar_842JF(new BEProducto_842JF(0, nombre, descripcion, 0, 0, medida, true));
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Registrar Producto", 5));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        var d = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        BEProducto_842JF c = bllproducto_842JF.ObtenerTodos_842JF().FirstOrDefault(u => u.codProducto_842JF == d);
                        if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.camposVacios"));
                        if (bllproducto_842JF.ObtenerTodos_842JF().Any(x => x.nombre_842JF == textBox1.Text) && textBox1.Text != c.nombre_842JF)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreRepetido"));
                        }
                        if (textBox2.Text.Any(char.IsDigit) || textBox3.Text.Any(char.IsDigit))
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.digitos"));
                        if (!textBox4.Text.All(char.IsDigit) || textBox5.Text.Any(char.IsLetter))
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.soloNumeros"));
                        }
                        if (int.Parse(textBox4.Text) > 0 && Convert.ToDecimal(textBox5.Text) == 0)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.agreguePrecio"));
                        }
                        if (int.Parse(textBox4.Text) == 0 && Convert.ToDecimal(textBox5.Text) > 0)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayCantidad"));
                        }
                        if(c.nombre_842JF == textBox1.Text && c.descripcion_842JF == textBox2.Text && c.medida_842JF == textBox3.Text && c.cantidad_842JF.ToString() == textBox4.Text && c.precioCompra_842JF.ToString() == textBox5.Text)
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noModificaNada"));
                        }
                        c.nombre_842JF = textBox1.Text;
                        c.descripcion_842JF = textBox2.Text;
                        c.medida_842JF = textBox3.Text;
                        c.cantidad_842JF = int.Parse(textBox4.Text);
                        c.precioCompra_842JF = Convert.ToDecimal(textBox5.Text);
                        bllproducto_842JF.Modificar_842JF(c);
                        bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Modificar Producto", 3));
                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                    }
                }
                else if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.eliminar"))
                {
                    if (bllpizza.ObtenerTodas_842JF().Any(x => x.productos.Any(y => y.Key.codProducto_842JF == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))))
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.asignadoAPizza"));
                    if (bllorden.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productoEnOrden"));
                    }
                    if (bllsolicitud.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.productoEnSolicitud"));
                    }
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        BEProducto_842JF p = bllproducto_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.codProducto_842JF == int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                        if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            p.disponible_842JF = false;
                            bllproducto_842JF.Modificar_842JF(p);
                            bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Maestros", "Eliminar Producto", 3));
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
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formProductos_842JF");
            if (textBox6.Text == IM_842JF.ObtenerString_842JF("textbox.modo.modificar"))
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var c = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    BEProducto_842JF p = bllproducto_842JF.ObtenerTodos_842JF().FirstOrDefault(x => x.codProducto_842JF == c);
                    textBox1.Text = p.nombre_842JF;
                    textBox2.Text = p.descripcion_842JF;
                    textBox3.Text = p.medida_842JF;
                    textBox4.Text = p.cantidad_842JF.ToString();
                    textBox5.Text = p.precioCompra_842JF.ToString();
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    if (bllpizza.ObtenerTodas_842JF().Any(x => x.productos.Any(y => y.Key.codProducto_842JF == p.codProducto_842JF)))
                    {
                        textBox3.Visible = false;
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                    }
                    if (bllorden.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == p.codProducto_842JF))
                    {
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        textBox3.Visible = false;
                        label3.Visible = false;
                    }
                    if (bllsolicitud.ObtenerTodos_842JF().Any(x => x.producto_842JF.codProducto_842JF == p.codProducto_842JF))
                    {
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        textBox3.Visible = false;
                        label3.Visible = false;
                    }
                }
            }
        }
    }
}
