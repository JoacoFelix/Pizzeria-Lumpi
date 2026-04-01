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
    public partial class FormMenu_842JF : Form
    {
        public FormMenu_842JF()
        {
            InitializeComponent();

        }

        private void FormMenu_842JF_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Enabled = false;
        }

        private void FormMenu_842JF_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormMenu_842JF_Enter(object sender, EventArgs e)
        {

        }
    }
}
