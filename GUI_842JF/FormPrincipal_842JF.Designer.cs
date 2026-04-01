namespace GUI_842JF
{
    partial class FormPrincipal_842JF
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            sesionToolStripMenuItem = new ToolStripMenuItem();
            iniciarSesiónToolStripMenuItem = new ToolStripMenuItem();
            cambiarIdiomaToolStripMenuItem = new ToolStripMenuItem();
            españolToolStripMenuItem = new ToolStripMenuItem();
            inglésToolStripMenuItem = new ToolStripMenuItem();
            cambiarContraseñaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            perfilesToolStripMenuItem = new ToolStripMenuItem();
            familiasToolStripMenuItem = new ToolStripMenuItem();
            backUpRestoreToolStripMenuItem = new ToolStripMenuItem();
            bitacoraEventosToolStripMenuItem = new ToolStripMenuItem();
            maestrosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            productosCToolStripMenuItem = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            pedidoToolStripMenuItem = new ToolStripMenuItem();
            generarFacturaToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            solicitarPresupuestoToolStripMenuItem = new ToolStripMenuItem();
            generarOrdenDeCompraToolStripMenuItem = new ToolStripMenuItem();
            registrarRecepciónToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            facturaToolStripMenuItem = new ToolStripMenuItem();
            reporteInteligenteToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ordenesDeCompraToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Peru;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sesionToolStripMenuItem, adminToolStripMenuItem, maestrosToolStripMenuItem, usuarioToolStripMenuItem, comprasToolStripMenuItem, reportesToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1272, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // sesionToolStripMenuItem
            // 
            sesionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesiónToolStripMenuItem, cambiarIdiomaToolStripMenuItem, cambiarContraseñaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            sesionToolStripMenuItem.Name = "sesionToolStripMenuItem";
            sesionToolStripMenuItem.Size = new Size(53, 20);
            sesionToolStripMenuItem.Text = "Sesión";
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            iniciarSesiónToolStripMenuItem.Size = new Size(182, 22);
            iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            iniciarSesiónToolStripMenuItem.Click += botonIniciarSesion;
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            cambiarIdiomaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { españolToolStripMenuItem, inglésToolStripMenuItem });
            cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            cambiarIdiomaToolStripMenuItem.Size = new Size(182, 22);
            cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            cambiarIdiomaToolStripMenuItem.Click += cambiarIdiomaToolStripMenuItem_Click;
            // 
            // españolToolStripMenuItem
            // 
            españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            españolToolStripMenuItem.Size = new Size(180, 22);
            españolToolStripMenuItem.Text = "Español";
            españolToolStripMenuItem.Click += españolToolStripMenuItem_Click;
            // 
            // inglésToolStripMenuItem
            // 
            inglésToolStripMenuItem.Name = "inglésToolStripMenuItem";
            inglésToolStripMenuItem.Size = new Size(180, 22);
            inglésToolStripMenuItem.Text = "Inglés";
            inglésToolStripMenuItem.Click += inglésToolStripMenuItem_Click;
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            cambiarContraseñaToolStripMenuItem.Size = new Size(182, 22);
            cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            cambiarContraseñaToolStripMenuItem.Click += botonCambiarContraseña;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(182, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += botonCerrarSesion;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, perfilesToolStripMenuItem, familiasToolStripMenuItem, backUpRestoreToolStripMenuItem, bitacoraEventosToolStripMenuItem });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(164, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // perfilesToolStripMenuItem
            // 
            perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            perfilesToolStripMenuItem.Size = new Size(164, 22);
            perfilesToolStripMenuItem.Text = "Perfiles";
            perfilesToolStripMenuItem.Click += perfilesToolStripMenuItem_Click;
            // 
            // familiasToolStripMenuItem
            // 
            familiasToolStripMenuItem.Name = "familiasToolStripMenuItem";
            familiasToolStripMenuItem.Size = new Size(164, 22);
            familiasToolStripMenuItem.Text = "Familias";
            familiasToolStripMenuItem.Click += familiasToolStripMenuItem_Click;
            // 
            // backUpRestoreToolStripMenuItem
            // 
            backUpRestoreToolStripMenuItem.Name = "backUpRestoreToolStripMenuItem";
            backUpRestoreToolStripMenuItem.Size = new Size(164, 22);
            backUpRestoreToolStripMenuItem.Text = "BackUp - Restore";
            backUpRestoreToolStripMenuItem.Click += backUpRestoreToolStripMenuItem_Click;
            // 
            // bitacoraEventosToolStripMenuItem
            // 
            bitacoraEventosToolStripMenuItem.Name = "bitacoraEventosToolStripMenuItem";
            bitacoraEventosToolStripMenuItem.Size = new Size(164, 22);
            bitacoraEventosToolStripMenuItem.Text = "Bitacora Eventos";
            bitacoraEventosToolStripMenuItem.Click += bitacoraEventosToolStripMenuItem_Click;
            // 
            // maestrosToolStripMenuItem
            // 
            maestrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, proveedoresToolStripMenuItem, productosToolStripMenuItem, productosCToolStripMenuItem });
            maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            maestrosToolStripMenuItem.Size = new Size(67, 20);
            maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(141, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(141, 22);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(141, 22);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // productosCToolStripMenuItem
            // 
            productosCToolStripMenuItem.Name = "productosCToolStripMenuItem";
            productosCToolStripMenuItem.Size = new Size(141, 22);
            productosCToolStripMenuItem.Text = "Productos_C";
            productosCToolStripMenuItem.Click += productosCToolStripMenuItem_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pedidoToolStripMenuItem, generarFacturaToolStripMenuItem });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(53, 20);
            usuarioToolStripMenuItem.Text = "Ventas";
            // 
            // pedidoToolStripMenuItem
            // 
            pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            pedidoToolStripMenuItem.Size = new Size(157, 22);
            pedidoToolStripMenuItem.Text = "Pedido";
            pedidoToolStripMenuItem.Click += pedidoToolStripMenuItem_Click;
            // 
            // generarFacturaToolStripMenuItem
            // 
            generarFacturaToolStripMenuItem.Name = "generarFacturaToolStripMenuItem";
            generarFacturaToolStripMenuItem.Size = new Size(157, 22);
            generarFacturaToolStripMenuItem.Text = "Generar Factura";
            generarFacturaToolStripMenuItem.Click += generarFacturaToolStripMenuItem_Click;
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { solicitarPresupuestoToolStripMenuItem, generarOrdenDeCompraToolStripMenuItem, registrarRecepciónToolStripMenuItem });
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.Size = new Size(67, 20);
            comprasToolStripMenuItem.Text = "Compras";
            // 
            // solicitarPresupuestoToolStripMenuItem
            // 
            solicitarPresupuestoToolStripMenuItem.Name = "solicitarPresupuestoToolStripMenuItem";
            solicitarPresupuestoToolStripMenuItem.Size = new Size(213, 22);
            solicitarPresupuestoToolStripMenuItem.Text = "Solicitar Presupuesto";
            solicitarPresupuestoToolStripMenuItem.Click += solicitarPresupuestoToolStripMenuItem_Click;
            // 
            // generarOrdenDeCompraToolStripMenuItem
            // 
            generarOrdenDeCompraToolStripMenuItem.Name = "generarOrdenDeCompraToolStripMenuItem";
            generarOrdenDeCompraToolStripMenuItem.Size = new Size(213, 22);
            generarOrdenDeCompraToolStripMenuItem.Text = "Generar Orden de Compra";
            generarOrdenDeCompraToolStripMenuItem.Click += generarOrdenDeCompraToolStripMenuItem_Click;
            // 
            // registrarRecepciónToolStripMenuItem
            // 
            registrarRecepciónToolStripMenuItem.Name = "registrarRecepciónToolStripMenuItem";
            registrarRecepciónToolStripMenuItem.Size = new Size(213, 22);
            registrarRecepciónToolStripMenuItem.Text = "Registrar Recepción";
            registrarRecepciónToolStripMenuItem.Click += registrarRecepciónToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { facturaToolStripMenuItem, ordenesDeCompraToolStripMenuItem, reporteInteligenteToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // facturaToolStripMenuItem
            // 
            facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            facturaToolStripMenuItem.Size = new Size(180, 22);
            facturaToolStripMenuItem.Text = "Factura";
            facturaToolStripMenuItem.Click += facturaToolStripMenuItem_Click;
            // 
            // reporteInteligenteToolStripMenuItem
            // 
            reporteInteligenteToolStripMenuItem.Name = "reporteInteligenteToolStripMenuItem";
            reporteInteligenteToolStripMenuItem.Size = new Size(180, 22);
            reporteInteligenteToolStripMenuItem.Text = "Reporte Inteligente";
            reporteInteligenteToolStripMenuItem.Click += reporteInteligenteToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            ayudaToolStripMenuItem.Click += ayudaToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Bisque;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 485);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(1272, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(47, 17);
            toolStripStatusLabel1.Text = "Usuario";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // ordenesDeCompraToolStripMenuItem
            // 
            ordenesDeCompraToolStripMenuItem.Name = "ordenesDeCompraToolStripMenuItem";
            ordenesDeCompraToolStripMenuItem.Size = new Size(180, 22);
            ordenesDeCompraToolStripMenuItem.Text = "Ordenes de Compra";
            ordenesDeCompraToolStripMenuItem.Click += ordenesDeCompraToolStripMenuItem_Click;
            // 
            // FormPrincipal_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 507);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrincipal_842JF";
            Text = "Lumpi";
            FormClosing += FormPrincipal_842JF_FormClosing;
            FormClosed += FormPrincipal_842JF_FormClosed;
            Load += FormPrincipal_842JF_Load;
            Enter += FormPrincipal_842JF_Enter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sesionToolStripMenuItem;
        private ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolTip toolTip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem maestrosToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidoToolStripMenuItem;
        private ToolStripMenuItem generarFacturaToolStripMenuItem;
        private ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private ToolStripMenuItem españolToolStripMenuItem;
        private ToolStripMenuItem inglésToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem perfilesToolStripMenuItem;
        private ToolStripMenuItem familiasToolStripMenuItem;
        private ToolStripMenuItem facturaToolStripMenuItem;
        private ToolStripMenuItem backUpRestoreToolStripMenuItem;
        private ToolStripMenuItem bitacoraEventosToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem solicitarPresupuestoToolStripMenuItem;
        private ToolStripMenuItem generarOrdenDeCompraToolStripMenuItem;
        private ToolStripMenuItem registrarRecepciónToolStripMenuItem;
        private ToolStripMenuItem productosCToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem reporteInteligenteToolStripMenuItem;
        private ToolStripMenuItem ordenesDeCompraToolStripMenuItem;
    }
}
