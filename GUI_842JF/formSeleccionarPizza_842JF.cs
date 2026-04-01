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

namespace GUI_842JF
{
    public partial class formSeleccionarPizza_842JF : Form, IIdiomaObserver_842JF
    {
        List<BEPizza_842JF> listapizzas;
        BLLPizza_842JF bllpizza_842JF;
        BLLProducto_842JF bllproducto;
        List<BEPizza_842JF> pizzas;
        IdiomaManager_842JF IM_842JF;
        public formSeleccionarPizza_842JF()
        {
            InitializeComponent();
            listapizzas = new List<BEPizza_842JF>();
            bllpizza_842JF = new BLLPizza_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            bllproducto = new BLLProducto_842JF();
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formSeleccionarPizza_842JF");
            Actualizar_842JF();
        }

        private void formSeleccionarPizza_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            pizzas = bllpizza_842JF.ObtenerTodas_842JF();
            label13.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 1).descripcion_842JF.ToString();
            label14.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 2).descripcion_842JF.ToString();
            label15.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 3).descripcion_842JF.ToString();
            label16.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 4).descripcion_842JF.ToString();
            label17.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 5).descripcion_842JF.ToString();
            label18.Text = bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 6).descripcion_842JF.ToString();
            label13.Size = new Size(210, label13.PreferredHeight);
            label14.Size = new Size(210, label14.PreferredHeight);
            label15.Size = new Size(210, label15.PreferredHeight);
            label16.Size = new Size(210, label16.PreferredHeight);
            label17.Size = new Size(210, label17.PreferredHeight);
            label18.Size = new Size(210, label18.PreferredHeight);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            formPedido_842JF frm = (formPedido_842JF)this.MdiParent.MdiChildren.FirstOrDefault(x => x is formPedido_842JF);
            frm.CargarLista(listapizzas);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 1);
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                BEPizzaMuzzarella_842JF p = new BEPizzaMuzzarella_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 2);
            for (int i = 0; i < numericUpDown2.Value; i++)
            {
                BEPizzaJamon_842JF p = new BEPizzaJamon_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 3);
            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                BEPizzaJamonyMorron_842JF p = new BEPizzaJamonyMorron_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Morron"), 50);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 4);
            for (int i = 0; i < numericUpDown4.Value; i++)
            {
                BEPizzaFugazzetta_842JF p = new BEPizzaFugazzetta_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Cebolla"), 400);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 5);
            for (int i = 0; i < numericUpDown5.Value; i++)
            {
                BEPizzaJamonCrudoyRucula_842JF p = new BEPizzaJamonCrudoyRucula_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon Crudo"), 150);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Rucula"), 100);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var pizza = pizzas.Find(x => x.codPizza_842JF == 6);
            for (int i = 0; i < numericUpDown6.Value; i++)
            {
                BEPizzaEspecial_842JF p = new BEPizzaEspecial_842JF(pizza.codPizza_842JF, pizza.descripcion_842JF, pizza.nombre_842JF, pizza.precio_842JF);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 400);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Cebolla"), 200);
                p.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                listapizzas.Add(p);
                listBox1.Items.Add(p.nombre_842JF);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItems.Count > 0)
                {
                    var p = listapizzas.FirstOrDefault(x => x.nombre_842JF == listBox1.SelectedItem.ToString());
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listapizzas.Remove(p);
                }
                else
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje"));
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }

        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formSeleccionarPizza_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblMuzza");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblJamon");
            label3.Text = IM_842JF.ObtenerString_842JF("label.lblJyM");
            label4.Text = IM_842JF.ObtenerString_842JF("label.lblFuga");
            label5.Text = IM_842JF.ObtenerString_842JF("label.lblJCyR");
            label6.Text = IM_842JF.ObtenerString_842JF("label.lblEspecial");
            label7.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 1).precio_842JF.ToString();
            label8.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 2).precio_842JF.ToString();
            label9.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 3).precio_842JF.ToString();
            label10.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 4).precio_842JF.ToString();
            label11.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 5).precio_842JF.ToString();
            label12.Text = IM_842JF.ObtenerString_842JF("label.lblPrecio") + " " + bllpizza_842JF.ObtenerTodas_842JF().Find(x => x.codPizza_842JF == 6).precio_842JF.ToString();
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button4.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button5.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button6.Text = IM_842JF.ObtenerString_842JF("button.btnAnadir");
            button7.Text = IM_842JF.ObtenerString_842JF("button.btnGuardar");
            button8.Text = IM_842JF.ObtenerString_842JF("button.btnCancelar");
            button15.Text = IM_842JF.ObtenerString_842JF("button.btnBorrar");
        }

        private void formSeleccionarPizza_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void formSeleccionarPizza_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formSeleccionarPizza_842JF");
        }
    }
}
