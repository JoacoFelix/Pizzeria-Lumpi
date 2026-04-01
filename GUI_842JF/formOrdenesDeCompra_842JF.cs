using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XAct;

namespace GUI_842JF
{
    public partial class formOrdenesDeCompra_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLOrdenDeCompra_842JF bllorden;
        public formOrdenesDeCompra_842JF()
        {
            InitializeComponent();
            bllorden = new BLLOrdenDeCompra_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formOrdenesDeCompra_842JF");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }
        public void LlenarGrillas_842JF()
        {
            var linq2 = from x in bllorden.ObtenerTodos_842JF() select new { codOrden = x.codOrdenCompra_842JF, fecha = x.fecha_842JF, producto = x.producto_842JF.nombre_842JF, proveedor = x.proveedor_842JF.nombre_842JF, precioUnitario = x.precioUnitario_842JF, cantidad = x.cantidad_842JF, total = x.cantidad_842JF * x.precioUnitario_842JF, recibida = x.recibida_842JF, pago = x.pago_842JF };
            dataGridView1.DataSource = linq2.ToList();
            dataGridView1.Columns["codOrden"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.codigoOrd");
            dataGridView1.Columns["fecha"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView1.Columns["producto"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.producto");
            dataGridView1.Columns["proveedor"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.proveedor");
            dataGridView1.Columns["precioUnitario"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.precioUnitario");
            dataGridView1.Columns["cantidad"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.cantidad");
            dataGridView1.Columns["total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
            dataGridView1.Columns["recibida"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.recibida");
            dataGridView1.Columns["pago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pago");
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formOrdenesDeCompra_842JF");
            if (dataGridView1.Rows.Count > 0)
            {
                var nro = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEOrdenCompra_842JF orden = bllorden.ObtenerTodos_842JF().Find(x => x.codOrdenCompra_842JF == nro);
                bllorden.ImprimirOrden_842JF(orden);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formOrdenesDeCompra_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblordenes");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            LlenarGrillas_842JF();
        }

        private void formOrdenesDeCompra_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formOrdenesDeCompra_842JF");
            LlenarGrillas_842JF();
        }

        private void formOrdenesDeCompra_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formOrdenesDeCompra_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
