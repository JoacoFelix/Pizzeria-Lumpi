using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using System.Data;

namespace GUI_842JF
{
    public partial class formBitacoraCambiosProducto_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLProducto_842JF bllproducto;
        BLLBitacoraCambiosProducto_842JF bllbitacoraCambios;
        IEnumerable<BEProducto_C_842JF> linq;
        public formBitacoraCambiosProducto_842JF()
        {
            InitializeComponent();
            bllbitacoraCambios = new BLLBitacoraCambiosProducto_842JF();
            bllproducto = new BLLProducto_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            linq = null;
            Actualizar_842JF();
        }
        private void CargarGrillas_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
            dataGridView1.DataSource = null;
            linq = from x in bllbitacoraCambios.ObtenerTodos_842JF() select x;
            dataGridView1.DataSource = linq.ToList();
            ActualizarGrillas_842JF();
        }
        private void ActualizarGrillas_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codProd");
            dataGridView1.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView1.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView1.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.descripcion");
            dataGridView1.Columns[6].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioCompra");
            dataGridView1.Columns[7].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.medida");
            dataGridView1.Columns[8].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.disponible");
            dataGridView1.Columns[9].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.activo");
            dataGridView2.DataSource = null;
            var linq2 = from x in bllproducto.ObtenerTodos_842JF() where x.disponible_842JF select x;
            dataGridView2.DataSource = linq2.ToList();
            dataGridView2.Columns[0].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codProd");
            dataGridView2.Columns[1].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView2.Columns[2].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.descripcion");
            dataGridView2.Columns[3].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioCompra");
            dataGridView2.Columns[4].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.medida");
            dataGridView2.Columns[5].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView2.Columns[6].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.disponible");
        }
        public void Actualizar_842JF()
        {
            LimpiarFiltros_842JF();
            VerificarFiltros_842JF();
            comboBox2.Items.Clear();
            IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
            label3.Text = IM_842JF.ObtenerString_842JF("label.codProducto");
            label4.Text = IM_842JF.ObtenerString_842JF("label.fechaInicio");
            label5.Text = IM_842JF.ObtenerString_842JF("label.fechaFin");
            label6.Text = IM_842JF.ObtenerString_842JF("label.nombre");
            button1.Text = IM_842JF.ObtenerString_842JF("button.limpiar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.aplicar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.activar");
            button4.Text = IM_842JF.ObtenerString_842JF("button.salir");
            checkBox1.Text = IM_842JF.ObtenerString_842JF("button.fecha");
            CargarGrillas_842JF();
        }
        private void LimpiarFiltros_842JF()
        {
            CargarGrillas_842JF();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            checkBox1.Checked = false;
            VerificarFiltros_842JF();
        }
        private void VerificarFiltros_842JF()
        {
            if (!checkBox1.Checked && comboBox1.Text == string.Empty && comboBox2.Text == string.Empty)
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
        private void formBitacoraCambiosProducto_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (var item in bllproducto.ObtenerTodos_842JF())
            {
                comboBox1.Items.Add(item.codProducto_842JF);
                comboBox2.Items.Add(item.nombre_842JF);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
                string c1 = string.Empty;
                string c2 = string.Empty;
                if (checkBox1.Checked)
                {
                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.fechamal"));
                    }
                }
                if (checkBox1.Checked)
                {
                    if (comboBox1.Text != string.Empty)
                    {
                        linq = from x in bllbitacoraCambios.ObtenerTodos_842JF() where x.codProducto_842JF == int.Parse(comboBox1.Text) && x.nombre_842JF.StartsWith(comboBox2.Text) && x.fecha_842JF.Date >= dateTimePicker1.Value.Date && x.fecha_842JF.Date <= dateTimePicker2.Value.Date select x;

                    }
                    else
                    {
                        linq = from x in bllbitacoraCambios.ObtenerTodos_842JF() where x.codProducto_842JF.ToString().StartsWith(comboBox1.Text) && x.nombre_842JF.StartsWith(comboBox2.Text) && x.fecha_842JF.Date >= dateTimePicker1.Value.Date && x.fecha_842JF.Date <= dateTimePicker2.Value.Date select x;
                    }

                }
                else
                {
                    if (comboBox1.Text != string.Empty)
                    {
                        linq = from x in bllbitacoraCambios.ObtenerTodos_842JF() where x.codProducto_842JF == int.Parse(comboBox1.Text) && x.nombre_842JF.StartsWith(comboBox2.Text) select x;

                    }
                    else
                    {
                        linq = from x in bllbitacoraCambios.ObtenerTodos_842JF() where x.codProducto_842JF.ToString().StartsWith(comboBox1.Text) && x.nombre_842JF.StartsWith(comboBox2.Text) select x;
                    }
                }
                if (linq.ToList().Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayCambio"));
                }
                ActualizarGrillas_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarFiltros_842JF();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception();
                }
                var prodC = dataGridView1.SelectedRows[0].DataBoundItem as BEProducto_C_842JF;
                if(prodC.activo_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaActivo"));
                }
                bllbitacoraCambios.Activar_842JF(prodC);
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.activado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                LimpiarFiltros_842JF();
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formBitacoraCambiosProducto_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formBitacoraCambiosProducto_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraCambiosProductos_842JF");
            LimpiarFiltros_842JF();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == string.Empty)
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
            }
            VerificarFiltros_842JF();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
            VerificarFiltros_842JF();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            VerificarFiltros_842JF();
        }
    }
}
