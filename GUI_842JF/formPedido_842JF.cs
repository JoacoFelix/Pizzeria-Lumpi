using System.Data;
using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Observer;

namespace GUI_842JF
{
    public partial class formPedido_842JF : Form, IIdiomaObserver_842JF
    {
        BLLCliente_842JF bllcliente;
        BLLPedido_842JF bllpedido;
        BLLPedidoPizza_842JF bllpedidopizza;
        BLLProducto_842JF bllproducto;
        BEPedido_842JF pedido;
        List<BEPizza_842JF> listapizzas;
        IdiomaManager_842JF IM_842JF;
        public formPedido_842JF()
        {
            InitializeComponent();
            bllcliente = new BLLCliente_842JF();
            bllpedido = new BLLPedido_842JF();
            bllproducto = new BLLProducto_842JF();
            listapizzas = new List<BEPizza_842JF>();
            bllpedidopizza = new BLLPedidoPizza_842JF();
            pedido = bllpedido.CrearPedido_842JF();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formPedido_842JF");
            Actualizar_842JF();
        }
        public void CargarLista(List<BEPizza_842JF> pizzas)
        {
            listapizzas = pizzas;
        }
        private void ActualizarGrilla_842JF()
        {
            dataGridView1.DataSource = null;
            var linq = from x in bllcliente.ObtenerTodos_842JF() where x.activo_842JF select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Mail = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF), Telefono = x.telefono_842JF };
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["DNI"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.DNI");
            dataGridView1.Columns["Nombre"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns["Apellido"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.apellido");
            dataGridView1.Columns["Mail"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns["Telefono"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
        }
        private void formPedido_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormPrincipal_842JF frm = (FormPrincipal_842JF)this.MdiParent;
            frm.AbrirFormulario<formSeleccionarPizza_842JF>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPrincipal_842JF frm = (FormPrincipal_842JF)this.MdiParent;
            frm.AbrirFormulario<formRegistrarCliente_842JF>();
        }

        private void formPedido_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formPedido_842JF");
            ActualizarGrilla_842JF();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listapizzas.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        if (listapizzas.Count > 0)
                        {
                            var d = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            var c = bllcliente.ObtenerTodos_842JF().FirstOrDefault(x=>x.DNI_842JF == d);
                            pedido = bllpedido.CargarPedido_842JF(listapizzas, pedido);
                            pedido = bllpedido.AsignarCliente_842JF(c, pedido);
                            BEPedido_842JF ped = new BEPedido_842JF(bllpedido.ObtenerTodos_842JF()[bllpedido.ObtenerTodos_842JF().Count - 1].nroPedido_842JF + 1, pedido.cliente_842JF, "Confirmado", pedido.pizzas_842JF, false);
                            var pizzasAgrupadas = listapizzas.GroupBy(p => new { p.codPizza_842JF, p.nombre_842JF, p.precio_842JF }).Select(g => $"{g.Count()}x{g.Key.nombre_842JF} - {g.Count() * g.Key.precio_842JF}");
                            var textoMostrar = string.Join(Environment.NewLine, pizzasAgrupadas) +
                                               Environment.NewLine +
                                               $"{IM_842JF.ObtenerString_842JF("mensaje.totSinIva")} {(ped.total_842JF - ped.total_842JF * 0.21m):F2}" +
                                               Environment.NewLine + Environment.NewLine +
                                               $"{IM_842JF.ObtenerString_842JF("mensaje.total")} {ped.total_842JF}";
                            int harina = 0;
                            int jamon = 0;
                            int queso = 0;
                            int salsa = 0;
                            int oregano = 0;
                            int cebolla = 0;
                            int rucula = 0;
                            int aceituna = 0;
                            int jamonCrudo = 0;
                            int morron = 0;
                            foreach (var item in ped.pizzas_842JF)
                            {
                                foreach(var item2 in item.productos)
                                {
                                    if(item2.Key.codProducto_842JF == 1)
                                    {
                                        jamon += item2.Value;
                                    }
                                    else if(item2.Key.codProducto_842JF == 2)
                                    {
                                        queso += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 3)
                                    {
                                        aceituna += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 4)
                                    {
                                        salsa += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 5)
                                    {
                                        cebolla += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 6)
                                    {
                                        oregano += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 7)
                                    {
                                        morron += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 8)
                                    {
                                        jamonCrudo += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 9)
                                    {
                                        rucula += item2.Value;
                                    }
                                    else if (item2.Key.codProducto_842JF == 10)
                                    {
                                        harina += item2.Value;
                                    }
                                }
                            }
                            if(bllproducto.ObtenerTodos_842JF().Find(x =>x.codProducto_842JF == 1).cantidad_842JF < jamon)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayJamon"));
                            }
                            else if(bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 2).cantidad_842JF < queso)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayQueso"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 3).cantidad_842JF < aceituna)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayAceituna"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 4).cantidad_842JF < salsa)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHaySalsa"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 5).cantidad_842JF < cebolla)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayCebolla"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 6).cantidad_842JF < oregano)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayOregano"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 7).cantidad_842JF < morron)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayMorron"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 8).cantidad_842JF < jamonCrudo)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayJamonCrudo"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 9).cantidad_842JF < rucula)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayRucula"));
                            }
                            else if (bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == 10).cantidad_842JF < harina)
                            {
                                throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayHarina"));
                            }
                            else
                            {
                                foreach(var item in bllproducto.ObtenerTodos_842JF())
                                {
                                    if(item.codProducto_842JF == 1)
                                    {
                                        item.cantidad_842JF -= jamon;
                                    }
                                    else if(item.codProducto_842JF == 2)
                                    {
                                        item.cantidad_842JF -= queso;
                                    }
                                    else if (item.codProducto_842JF == 3)
                                    {
                                        item.cantidad_842JF -= aceituna;
                                    }
                                    else if (item.codProducto_842JF == 4)
                                    {
                                        item.cantidad_842JF -= salsa;
                                    }
                                    else if (item.codProducto_842JF == 5)
                                    {
                                        item.cantidad_842JF -= cebolla;
                                    }
                                    else if (item.codProducto_842JF == 6)
                                    {
                                        item.cantidad_842JF -= oregano;
                                    }
                                    else if (item.codProducto_842JF == 7)
                                    {
                                        item.cantidad_842JF -= morron;
                                    }
                                    else if (item.codProducto_842JF == 8)
                                    {
                                        item.cantidad_842JF -= jamonCrudo;
                                    }
                                    else if (item.codProducto_842JF == 9)
                                    {
                                        item.cantidad_842JF -= rucula;
                                    }
                                    else if (item.codProducto_842JF == 10)
                                    {
                                        item.cantidad_842JF -= harina;
                                    }
                                    bllproducto.Modificar_842JF(item);
                                }
                            }
                            if (msgBox_842JF.Show_842JF($"{textoMostrar}", IM_842JF.ObtenerString_842JF("mensaje.confirmar"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                bllpedido.ConfirmarPedido_842JF(ped);
                                var linq = from x in listapizzas where x.codPizza_842JF == 1 select x;
                                int c1 = linq.ToList().Count;
                                var linq2 = from x in listapizzas where x.codPizza_842JF == 2 select x;
                                int c2 = linq2.ToList().Count;
                                var linq3 = from x in listapizzas where x.codPizza_842JF == 3 select x;
                                int c3 = linq3.ToList().Count;
                                var linq4 = from x in listapizzas where x.codPizza_842JF == 4 select x;
                                int c4 = linq4.ToList().Count;
                                var linq5 = from x in listapizzas where x.codPizza_842JF == 5 select x;
                                int c5 = linq5.ToList().Count;
                                var linq6 = from x in listapizzas where x.codPizza_842JF == 6 select x;
                                int c6 = linq6.ToList().Count;
                                if (c1 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(1, ped.nroPedido_842JF, c1));
                                }
                                if (c2 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(2, ped.nroPedido_842JF, c2));
                                }
                                if (c3 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(3, ped.nroPedido_842JF, c3));
                                }
                                if (c4 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(4, ped.nroPedido_842JF, c4));
                                }
                                if (c5 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(5, ped.nroPedido_842JF, c5));
                                }
                                if (c6 != 0)
                                {
                                    bllpedidopizza.ConfirmarPedido_842JF(new BEPedidoPizza_842JF(6, ped.nroPedido_842JF, c6));
                                }

                                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.confirmado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            }
                            else
                            {
                                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.cancelado"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            }
                            listapizzas.Clear();

                        }
                        else
                        {
                            throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVacia"));
                        }

                    }
                    else
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.clienteVacio"));
                    }
                }
                else
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noHayCliente"));
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            var linq = from x in bllcliente.ObtenerTodos_842JF() where x.DNI_842JF.StartsWith(s) && x.activo_842JF select new { DNI = x.DNI_842JF, Nombre = x.nombre_842JF, Apellido = x.apellido_842JF, Mail = Servicios_842JF.Encriptador_842JF.DesencriptarReversible_842JF(x.mail_842JF), Telefono = x.telefono_842JF };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = linq.ToList();
            dataGridView1.Columns["DNI"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.DNI");
            dataGridView1.Columns["Nombre"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.nombre");
            dataGridView1.Columns["Apellido"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.apellido");
            dataGridView1.Columns["Mail"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.mail");
            dataGridView1.Columns["Telefono"].HeaderText = IM_842JF.ObtenerString_842JF("datagridview.columna.telefono");
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formPedido_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblClientes");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblBuscarCliente");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnAsignar");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnRegistrarCliente");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnSeleccionar");
            ActualizarGrilla_842JF();
        }

        private void formPedido_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }
    }
}
