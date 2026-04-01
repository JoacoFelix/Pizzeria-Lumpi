using BE_842JF;
using BLL_842JF;
using Servicios_842JF;
using Servicios_842JF.Observer;
using Servicios_842JF.Singleton;
using System.Diagnostics;

namespace GUI_842JF
{
    public partial class FormPrincipal_842JF : Form, IIdiomaObserver_842JF
    {
        BLLUsuario_842JF bllUsuario_842JF;
        BLLBitacoraEvento_842JF bLLBitacoraEvento_842JF;
        BLLSolicitudPresupuesto_842JF bllsolicitud;
        BLLDV_842JF bllDV;
        BLLReporteInteligente_842JF bllreporteInteligente;
        Usuario_842JF u;
        IdiomaManager_842JF IM_842JF;
        string idiomita;
        public FormPrincipal_842JF()
        {
            InitializeComponent();
            bllUsuario_842JF = new BLLUsuario_842JF();
            bLLBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
            bllreporteInteligente = new BLLReporteInteligente_842JF();
            bllsolicitud = new BLLSolicitudPresupuesto_842JF();
            idiomita = "spanish";
            FormMenu_842JF frm = new FormMenu_842JF();
            bllDV = new BLLDV_842JF();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (var item in bllUsuario_842JF.ObtenerTodos_842JF())
            {
                if (item != null && item.contador_842JF > 0)
                {
                    if ((DateTime.Now - item.ultimoIntento_842JF).TotalHours >= 4)
                    {
                        item.contador_842JF = 0;
                        bllUsuario_842JF.Modificar_842JF(item);
                    }
                }
            }
            foreach (var item in bllsolicitud.ObtenerTodos_842JF())
            {
                if ((DateTime.Now - item.fecha_842JF).TotalDays >= 5)
                {
                    bllsolicitud.Eliminar_842JF(item);
                }
            }
            //foreach (var item in dALDV_842JF.ObtenerTodos_842JF())
            //{
            //    item.vertical_842JF = dALDV_842JF.CalcularDigitoVerificadorVertical_842JF(item);
            //    item.horizontal_842JF = dALDV_842JF.CalcularDigitoVerificadorHorizontal_842JF(item);
            //    dALDV_842JF.GuardarDigitoVerificador_842JF(item);
            //}
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            CargarIdioma_842JF();
            IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
            IM_842JF.Agregar_842JF(this);
            Actualizar_842JF();
            frm.Show();

            //bllUsuario_842JF.Guardar_842JF(new Usuario_842JF("46208842", "Joaquin", "Felix", "46208842Joaquin", "46208842Felix", "Admin", "joaquinsfelix03@gmail.com", false, true,0,DateTime.Now));

        }
        public void ValidarForm_842JF()
        {
            if (SessionManager_842JF.IsLogged_842JF())
            {
                u = SessionManager_842JF.Instancia.Usuario_842JF;
                this.toolStripStatusLabel2.Text = $"{u.nombre_842JF} {u.apellido_842JF} {u.rol_842JF.nombre_842JF}";
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Usuarios"))
                {
                    adminToolStripMenuItem.Enabled = true;
                    usuariosToolStripMenuItem.Enabled = true;
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Perfiles"))
                {
                    adminToolStripMenuItem.Enabled = true;
                    perfilesToolStripMenuItem.Enabled = true;
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Familias"))
                {
                    adminToolStripMenuItem.Enabled = true;
                    familiasToolStripMenuItem.Enabled = true;
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "BackUpRestore"))
                {
                    adminToolStripMenuItem.Enabled = true;
                    backUpRestoreToolStripMenuItem.Enabled = true;
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Maestro"))
                {
                    maestrosToolStripMenuItem.Enabled = true;
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Cliente"))
                    {
                        clientesToolStripMenuItem.Enabled = true;
                    }
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Proveedor"))
                    {
                        proveedoresToolStripMenuItem.Enabled = true;
                    }
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Producto"))
                    {
                        productosCToolStripMenuItem.Enabled = true;
                        productosToolStripMenuItem.Enabled = true;
                    }
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Ventas"))
                {
                    usuarioToolStripMenuItem.Enabled = true;
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Pedido"))
                    {
                        pedidoToolStripMenuItem.Enabled = true;
                    }
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Generar Factura"))
                    {
                        generarFacturaToolStripMenuItem.Enabled = true;
                    }
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Compras"))
                {
                    comprasToolStripMenuItem.Enabled = true;
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Solicitud Presupuesto"))
                    {
                        solicitarPresupuestoToolStripMenuItem.Enabled = true;
                    }
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Generar Orden de Compra"))
                    {
                        generarOrdenDeCompraToolStripMenuItem.Enabled = true;
                    }
                    if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Registrar Recepción"))
                    {
                        registrarRecepciónToolStripMenuItem.Enabled = true;
                    }
                }
                if (u.rol_842JF.ObtenerPermisosSimples_842JF().Any(x => x.nombre_842JF == "Factura"))
                {
                    reportesToolStripMenuItem.Enabled = true;
                    facturaToolStripMenuItem.Enabled = true;
                }

                cambiarContraseñaToolStripMenuItem.Enabled = true;
                idiomita  = SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF;
            }
            else
            {
                u = null;
                this.toolStripStatusLabel2.Text = IM_842JF.ObtenerString_842JF("label.sesionNoIniciada");
                menuStrip1.Items[1].Enabled = false;
                menuStrip1.Items[2].Enabled = false;
                menuStrip1.Items[3].Enabled = false;
                menuStrip1.Items[4].Enabled = false;
                menuStrip1.Items[5].Enabled = false;
                perfilesToolStripMenuItem.Enabled = false;
                backUpRestoreToolStripMenuItem.Enabled = false;
                cambiarContraseñaToolStripMenuItem.Enabled = false;
                pedidoToolStripMenuItem.Enabled = false;
                usuariosToolStripMenuItem.Enabled = false;
                familiasToolStripMenuItem.Enabled = false;
                generarFacturaToolStripMenuItem.Enabled = false;
                solicitarPresupuestoToolStripMenuItem.Enabled = false;
                generarOrdenDeCompraToolStripMenuItem.Enabled = false;
                facturaToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                proveedoresToolStripMenuItem.Enabled = false;
                productosCToolStripMenuItem.Enabled = false;
                productosToolStripMenuItem.Enabled = false;
                registrarRecepciónToolStripMenuItem.Enabled = false;
                foreach (Form hijo in MdiChildren)
                {
                    if (hijo is not FormMenu_842JF)
                    {
                        hijo.Close();
                    }
                }
            }

        }
        public void AbrirFormulario<T>() where T : Form, new()
        {
            Form form = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (form != null)
            {
                form.BringToFront();
            }
            else
            {
                form = new T();
                form.MdiParent = this;
                form.Show();
            }
        }
        private void botonIniciarSesion(object sender, EventArgs e)
        {
            AbrirFormulario<FormLogin_842JF>();
        }

        private void botonCerrarSesion(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
                if (!SessionManager_842JF.IsLogged_842JF())
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.sesionNoIniciada"));
                if (msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seguro"), IM_842JF.ObtenerString_842JF("mensaje.alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), IM_842JF.ObtenerString_842JF("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Usuarios", "Cerrar Sesión", 1));
                    bllUsuario_842JF.LogOut_842JF();
                    ValidarForm_842JF();
                    IM_842JF.CambiarIdioma_842JF("spanish");
                    idiomita = "spanish";
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formUsuarios_842JF>();
        }

        private void botonCambiarContraseña(object sender, EventArgs e)
        {
            AbrirFormulario<FormCambiarContraseña_842JF>();
        }

        private void FormPrincipal_842JF_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formPedido_842JF>();
        }

        private void generarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formGenerarFactura_842JF>();
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
            sesionToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.texto");
            iniciarSesiónToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.iniciarSesion");
            cambiarContraseñaToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.cambiarContra");
            cerrarSesiónToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.cerrarSesion");
            cambiarIdiomaToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.cambiarIdioma");
            españolToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.español");
            inglésToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.sesion.items.ingles");
            //
            adminToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.admin.texto");
            usuariosToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.admin.items.usuarios");
            perfilesToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.admin.items.perfiles");
            familiasToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.admin.items.familias");
            bitacoraEventosToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.admin.items.bitacoraEventos");
            //
            maestrosToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.maestros.texto");
            clientesToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.maestros.items.clientes");
            proveedoresToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.maestros.items.proveedores");
            productosCToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.maestros.items.productosC");
            productosToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.maestros.items.productos");
            //
            usuarioToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.ventas.texto");
            pedidoToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.ventas.items.pedido");
            generarFacturaToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.ventas.items.generarFac");
            //
            comprasToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.compras.texto");
            solicitarPresupuestoToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.compras.items.solicitar");
            generarOrdenDeCompraToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.compras.items.orden");
            registrarRecepciónToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.compras.items.recepcion");
            //
            reportesToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.reportes.texto");
            facturaToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.reportes.items.facturas");
            ordenesDeCompraToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.reportes.items.ordenes");
            reporteInteligenteToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.reportes.items.inteligente");
            //
            ayudaToolStripMenuItem.Text = IM_842JF.ObtenerString_842JF("menu.ayuda.texto");
            toolStripStatusLabel1.Text = IM_842JF.ObtenerString_842JF("label.usuario");
            ValidarForm_842JF();
        }

        private void FormPrincipal_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
            ValidarForm_842JF();
        }
        public void CargarIdioma_842JF()
        {
            if (SessionManager_842JF.Instancia == null)
                IdiomaManager_842JF.Instancia_842JF.CambiarIdioma_842JF("spanish");
            else
            {
                IdiomaManager_842JF.Instancia_842JF.CambiarIdioma_842JF(SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF);
            }
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
                if (SessionManager_842JF.Instancia != null)
                {
                    if (SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF == "spanish")
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaEspanol"));
                    }
                    else
                    {
                        IdiomaManager_842JF.Instancia_842JF.CambiarIdioma_842JF("spanish");
                        SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF = "spanish";
                        bllUsuario_842JF.Modificar_842JF(SessionManager_842JF.Instancia.Usuario_842JF);
                        idiomita = "spanish";
                    }
                }
                else
                {
                    IM_842JF.CambiarIdioma_842JF("spanish");
                    idiomita = "spanish";
                }

            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }

        }

        private void inglésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IM_842JF.CargarFormulario_842JF("formPrincipal_842JF");
                if (SessionManager_842JF.Instancia != null)
                {
                    if (SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF == "english")
                    {
                        throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.yaIngles"));
                    }
                    else
                    {
                        IdiomaManager_842JF.Instancia_842JF.CambiarIdioma_842JF("english");
                        SessionManager_842JF.Instancia.Usuario_842JF.idioma_842JF = "english";
                        bllUsuario_842JF.Modificar_842JF(SessionManager_842JF.Instancia.Usuario_842JF);
                        idiomita = "english";
                    }
                }
                else
                {
                    IM_842JF.CambiarIdioma_842JF("english");
                    idiomita = "english";
                }
            }
            catch (Exception ex)
            {

                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formClientes_842JF>();
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formFamilias_842JF>();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formPerfiles_842JF>();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formFacturas_842JF>();
        }

        private void backUpRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBackUpRestore_842JF>();
        }
        private void bitacoraEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formBitacoraEventos_842JF>();
        }
        private void FormPrincipal_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void FormPrincipal_842JF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager_842JF.IsLogged_842JF())
            {
                bLLBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bLLBitacoraEvento_842JF.ObtenerTodos_842JF().Count + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Usuarios", "Cerrar Sesión", 1));
                bllUsuario_842JF.LogOut_842JF();
            }
        }



        private void solicitarPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formSolicitarPresupuesto_842JF>();
        }

        private void generarOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formGenerarOrdenDeCompra_842JF>();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formRegistrarProveedor_842JF>();
        }

        private void registrarRecepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formRegistrarRecepcion_842JF>();
        }

        private void productosCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formBitacoraCambiosProducto_842JF>();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formProductos_842JF>();

        }

        private void reporteInteligenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bllreporteInteligente.GenerarReporte();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Manuales", $"{idiomita}", $"ManualAyuda.pdf");
            try
            {
                if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ordenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formOrdenesDeCompra_842JF>();
        }
    }
}
