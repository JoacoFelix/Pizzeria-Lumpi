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
using DAL_842JF;
using Servicios_842JF.Observer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_842JF
{
    public partial class formRepararInconsistencia_842JF : Form, IIdiomaObserver_842JF
    {
        List<string> lista;
        IdiomaManager_842JF IM_842JF;
        BLLDV_842JF bllDV;
        BLLBackUpRestore_842JF bllBackUpRestore;
        public void llenarLista(List<string> list)
        {
            lista = list;
        }
        public formRepararInconsistencia_842JF()
        {
            InitializeComponent();
            lista = new List<string>();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            bllDV = new BLLDV_842JF();
            bllBackUpRestore = new BLLBackUpRestore_842JF();
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("formRepararInconsistencia_842JF");
            Actualizar_842JF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "SQL Backup Files (*.bak)|*.bak";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ruta = openFileDialog.FileName;
                    }
                }
                if (string.IsNullOrEmpty(ruta))
                {
                    throw new Exception(IM_842JF.ObtenerString_842JF("mensaje.selVaciaRes"));
                }
                try
                {
                    bllBackUpRestore.Restore_842JF(ruta);
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.exitoRestore"), IM_842JF.ObtenerString_842JF("alerta"), IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.errorRestore"), "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formRepararInconsistencia_842JF_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            foreach (var item in lista)
            {
                label3.Text += item + " ";
            }
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("formRepararInconsistencia_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblInconsistencia");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblTablas");
            button1.Text = IM_842JF.ObtenerString_842JF("button.btnRecalcular");
            button2.Text = IM_842JF.ObtenerString_842JF("button.btnRestore");
            button3.Text = IM_842JF.ObtenerString_842JF("button.btnSalir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in lista)
                {
                    bllDV.Recalcular_842JF(new BEDV_842JF(item));
                }
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.seRecalculo"), "", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                msgBox_842JF.Show_842JF(ex.Message, "Error", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void formRepararInconsistencia_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("mensaje.noSeReparo"), "", IM_842JF.ObtenerString_842JF("messagebox.button.aceptar"), MessageBoxIcon.Information);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
