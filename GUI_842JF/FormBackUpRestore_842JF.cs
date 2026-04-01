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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI_842JF
{
    public partial class FormBackUpRestore_842JF : Form, IIdiomaObserver_842JF
    {
        BLLBackUpRestore_842JF bllBackUpRestore_842JF;
        IdiomaManager_842JF IM_842JF;
        public FormBackUpRestore_842JF()
        {
            InitializeComponent();
            bllBackUpRestore_842JF = new BLLBackUpRestore_842JF();
            IM_842JF = IdiomaManager_842JF.Instancia_842JF;
            IM_842JF.Agregar_842JF(this);
            IM_842JF.CargarFormulario_842JF("FormBackUpRestore_842JF");
            Actualizar_842JF();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog explorador = new FolderBrowserDialog())
            {
                if (explorador.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = explorador.SelectedPath;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Backup Files (*.bak)|*.bak";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("FormBackUpRestore_842JF");
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    bllBackUpRestore_842JF.BackUp_842JF(textBox1.Text);
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.exitoBackUp"), "", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
                    textBox1.Text = "";
                }
                catch (Exception)
                {
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.errorBkUp"), "Error", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
                }
            }
            else
            {
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.selVaciaBak"), "Error", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
            }
        }

        public void Actualizar_842JF()
        {
            IM_842JF.CargarFormulario_842JF("FormBackUpRestore_842JF");
            label1.Text = IM_842JF.ObtenerString_842JF("label.lblBkUp");
            label2.Text = IM_842JF.ObtenerString_842JF("label.lblRestore");
            button5.Text = IM_842JF.ObtenerString_842JF("button.salir");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("FormBackUpRestore_842JF");
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    bllBackUpRestore_842JF.Restore_842JF(textBox2.Text);
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.exitoRestore"), "", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
                    textBox2.Text = "";
                }
                catch (Exception ex)
                {
                    msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.errorRestore"), "Error", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
                }
            }
            else
            {
                msgBox_842JF.Show_842JF(IM_842JF.ObtenerString_842JF("msg.selVaciaRes"), "Error", IM_842JF.ObtenerString_842JF("button.aceptar"), MessageBoxIcon.Information);
            }
        }

        private void FormBackUpRestore_842JF_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBackUpRestore_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {
            IM_842JF.Eliminar_842JF(this);
        }

        private void FormBackUpRestore_842JF_Enter(object sender, EventArgs e)
        {
            IM_842JF.CargarFormulario_842JF("FormBackUpRestore_842JF");
        }
    }
}
