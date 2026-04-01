using BE_842JF;
using BLL_842JF;
using Servicios_842JF.Composite;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;

namespace GUI_842JF
{
    public partial class formPerfiles_842JF : Form, IIdiomaObserver_842JF
    {
        IdiomaManager_842JF IM_842JF;
        BLLFamilia_842JF bllfamilia_842JF;
        BLLPermiso_842JF bllpermiso_842JF;
        BLLPerfil_842JF bllperfil_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;

        public formPerfiles_842JF()
        {
            InitializeComponent();
            bllfamilia_842JF = new BLLFamilia_842JF();
            bllpermiso_842JF = new BLLPermiso_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllperfil_842JF = new BLLPerfil_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formPerfiles_842JF");
            Actualizar_842JF();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formPerfiles_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.permisos");
            label2.Text = IM_842JF.ObtenerString_842JF("label.familias");
            label3.Text = IM_842JF.ObtenerString_842JF("label.nombre");
            label4.Text = IM_842JF.ObtenerString_842JF("label.descripcion");
            label5.Text = IM_842JF.ObtenerString_842JF("label.perfil");
            label6.Text = IM_842JF.ObtenerString_842JF("label.familiaSeleccionada");
            label7.Text = IM_842JF.ObtenerString_842JF("label.perfilSeleccionado");
            Labels_842JF();
            button1.Text = IM_842JF.ObtenerString_842JF("button.generarPerfil");
            button2.Text = IM_842JF.ObtenerString_842JF("button.asignarPermiso");
            button3.Text = IM_842JF.ObtenerString_842JF("button.asignarFamilia");
            button4.Text = IM_842JF.ObtenerString_842JF("button.eliminarPerfil");
            button5.Text = IM_842JF.ObtenerString_842JF("button.eliminarHijo");
            button6.Text = IM_842JF.ObtenerString_842JF("button.salir");
            RellenarCosas_842JF();
        }
        public void RellenarCosas_842JF()
        {
            listBox1.Items.Clear();
            foreach (var item in bllpermiso_842JF.ObtenerTodos_842JF())
            {
                listBox1.Items.Add(item.ToString());
            }
            CargarTreeView_842JF();
            CargarTreeViewPerfiles_842JF();
        }
        private void Labels_842JF()
        {
            if (treeView1.SelectedNode != null)
            {
                label6.Text = IM_842JF.ObtenerString_842JF("label.familiaSeleccionada") + " " + treeView1.SelectedNode.Text;
            }
            if (treeView2.SelectedNode != null)
            {
                label7.Text = IM_842JF.ObtenerString_842JF("label.perfilSeleccionado") + " " + treeView2.SelectedNode.Text;
            }
        }

        private TreeNode CrearNodoComponente(Perfil_842JF componente)
        {
            TreeNode nodo = new TreeNode(componente.ToString());
            nodo.Tag = componente;

            if (componente is Familia_842JF)
            {
                var hijos = componente.ObtenerHijos_842JF();
                if (hijos != null)
                {
                    foreach (var hijo in hijos)
                    {
                        nodo.Nodes.Add(CrearNodoComponente(hijo));
                    }
                }
            }
            return nodo;
        }
        private void CargarTreeView_842JF()
        {
            treeView1.Nodes.Clear();
            var familias = bllfamilia_842JF.ObtenerTodas_842JF();

            foreach (var familia in familias)
            {
                TreeNode nodo = CrearNodoComponente(familia);
                treeView1.Nodes.Add(nodo);
                nodo.Expand();
            }
        }
        private void CargarTreeViewPerfiles_842JF()
        {
            treeView2.Nodes.Clear();
            var familias = bllperfil_842JF.ObtenerTodos_842JF();

            foreach (var familia in familias)
            {
                if (familia.nombre_842JF != "SuperAdmin")
                {
                    TreeNode nodo = CrearNodoComponente(familia);
                    treeView2.Nodes.Add(nodo);
                    nodo.Expand();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;
                string descripcion = textBox2.Text;
                if (nombre == string.Empty)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.nombreVacio"));
                }
                if (descripcion == string.Empty)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.descripcionVacia"));
                }
                int cod = 1;
                if (bllperfil_842JF.ObtenerTodos_842JF().Count() > 0)
                { cod = bllperfil_842JF.ObtenerTodos_842JF().Last().codPerfil_842JF + 1; }
                bllperfil_842JF.GuardarPerfil_842JF(new Familia_842JF(cod, descripcion, nombre));
                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Generar Perfil", 2));
                RellenarCosas_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItems.Count == 0)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaList"));
                }
                if (treeView2.SelectedNode == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaTree2"));
                }
                if (treeView2.SelectedNode.Parent != null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noEsPerfil"));
                }
                if(treeView2.SelectedNode.Text == SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noASiMismo"));
                }
                Perfil_842JF perfil = bllperfil_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == treeView2.SelectedNode.Text);
                Perfil_842JF permiso = bllpermiso_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == listBox1.SelectedItems[0].ToString());
                bllperfil_842JF.AgregarPermiso_842JF(perfil, permiso);
                RellenarCosas_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaTree1"));
                }
                if (treeView1.SelectedNode.Parent != null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noEsFamilia"));
                }
                if (treeView2.SelectedNode == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaTree2"));
                }
                if (treeView2.SelectedNode.Parent != null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noEsPerfil"));
                }
                if (treeView2.SelectedNode.Text == SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noASiMismo"));
                }
                Perfil_842JF perfil = bllperfil_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == treeView2.SelectedNode.Text);
                Perfil_842JF familia = bllfamilia_842JF.ObtenerTodas_842JF().Find(x => x.nombre_842JF == treeView1.SelectedNode.Text);
                bllperfil_842JF.AgregarFamilia_842JF(perfil, familia);
                RellenarCosas_842JF();
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaTree2"));
                }
                if (treeView2.SelectedNode.Parent != null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noEsPerfil"));
                }
                if (treeView2.SelectedNode.Text == SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noASiMismo"));
                }
                if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminar"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Perfil_842JF perfil = bllperfil_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == treeView2.SelectedNode.Text);
                    bllperfil_842JF.EliminarPerfil_842JF(perfil);
                    RellenarCosas_842JF();
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.seleccionVaciaTree2"));
                }
                if (treeView2.SelectedNode.Parent == null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.EsPerfil"));
                }
                if (treeView2.SelectedNode.Parent.Parent != null)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noEsHijoDirecto"));
                }
                if (treeView2.SelectedNode.Text == SessionManager_842JF.Instancia.Usuario_842JF.rol_842JF.nombre_842JF)
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.noASiMismo"));
                }
                if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguroEliminarHijo"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Perfil_842JF perfil = bllperfil_842JF.ObtenerTodos_842JF().Find(x => x.nombre_842JF == treeView2.SelectedNode.Parent.Text);
                    Perfil_842JF hijo = perfil.ObtenerHijo_842JF(treeView2.SelectedNode.Tag as Perfil_842JF);
                    perfil.EliminarHijo_842JF(hijo);
                    bllperfil_842JF.EliminarHijo_842JF(perfil, hijo);
                    RellenarCosas_842JF();
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void formPerfiles_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void formPerfiles_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formPerfiles_842JF");
            RellenarCosas_842JF();
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Labels_842JF();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Labels_842JF();
        }

        private void formPerfiles_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }
    }
}
