using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;

namespace GUI_842JF
{
    public partial class formFacturas_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLFactura_842JF bllfactura_842JF;
        public formFacturas_842JF()
        {
            InitializeComponent();
            bllfactura_842JF = new BLLFactura_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formFacturas_842JF");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formFacturas_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.facturas");
            button1.Text = IM_842JF.ObtenerString_842JF("button.salir");
            LlenarGrillas_842JF();
        }
        public void LlenarGrillas_842JF()
        {
            dataGridView1.DataSource = null;
            var linq = from x in bllfactura_842JF.ObtenerTodos_842JF() select new { nroFactura = x.nroFactura_842JF, fechayHora = x.fecha_842JF, medioDePago = x.medioDePago_842JF, pedido = x.pedido_842JF.nroPedido_842JF, total = x.total_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["nroFactura"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.numero");
            dataGridView1.Columns["fechayHora"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.fecha");
            dataGridView1.Columns["medioDePago"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.medioDePago");
            dataGridView1.Columns["pedido"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.pedido");
            dataGridView1.Columns["total"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.total");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formFacturas_842JF");
            if (dataGridView1.Rows.Count > 0)
            {
                var nro = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                BEFactura_842JF factura = bllfactura_842JF.ObtenerTodos_842JF().Find(x => x.nroFactura_842JF == nro);
                bllfactura_842JF.GenerarFactura_842JF(factura);
            }
        }

        private void formFacturas_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formFacturas_842JF");
            LlenarGrillas_842JF();
        }

        private void formFacturas_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formFacturas_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }
    }
}
