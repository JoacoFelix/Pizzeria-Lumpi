namespace GUI_842JF
{
    partial class formGenerarOrdenDeCompra_842JF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label6 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            button4 = new Button();
            checkBox1 = new CheckBox();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 23);
            textBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 110);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 5;
            label3.Text = "Cantidad:";
            // 
            // button1
            // 
            button1.Location = new Point(79, 217);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Generar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(350, 217);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(210, 217);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(387, 110);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 14;
            label6.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 152);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 19;
            label4.Text = "Precio por medida:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 144);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 23);
            textBox2.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(552, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(855, 237);
            dataGridView1.TabIndex = 21;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(552, 65);
            label5.Name = "label5";
            label5.Size = new Size(148, 15);
            label5.TabIndex = 22;
            label5.Text = "Solicitudes de Presupuesto";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(552, 368);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(855, 223);
            dataGridView2.TabIndex = 23;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 350);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 24;
            label1.Text = "Ordenes de Compra";
            // 
            // button4
            // 
            button4.Location = new Point(365, 437);
            button4.Name = "button4";
            button4.Size = new Size(181, 23);
            button4.TabIndex = 25;
            button4.Text = "Pagar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(369, 466);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(140, 19);
            checkBox1.TabIndex = 26;
            checkBox1.Text = "Mostrar solo impagas";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button5
            // 
            button5.Location = new Point(365, 504);
            button5.Name = "button5";
            button5.Size = new Size(181, 23);
            button5.TabIndex = 27;
            button5.Text = "Eliminar Orden de Compra";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(364, 297);
            button6.Name = "button6";
            button6.Size = new Size(181, 23);
            button6.TabIndex = 28;
            button6.Text = "Eliminar Solicitud";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // formGenerarOrdenDeCompra_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1430, 636);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(checkBox1);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Name = "formGenerarOrdenDeCompra_842JF";
            FormClosed += formGenerarOrdenDeCompra_842JF_FormClosed;
            Load += formGenerarOrdenDeCompra_842JF_Load;
            Enter += formGenerarOrdenDeCompra_842JF_Enter;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label6;
        private Label label4;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Label label5;
        private DataGridView dataGridView2;
        private Label label1;
        private Button button4;
        private CheckBox checkBox1;
        private Button button5;
        private Button button6;
    }
}