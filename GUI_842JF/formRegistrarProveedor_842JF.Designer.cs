namespace GUI_842JF
{
    partial class formRegistrarProveedor_842JF
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
            textBox6 = new TextBox();
            label6 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button7 = new Button();
            textBox5 = new TextBox();
            label7 = new Label();
            listBox1 = new ListBox();
            label3 = new Label();
            button1 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox6
            // 
            textBox6.Location = new Point(347, 259);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(183, 23);
            textBox6.TabIndex = 68;
            textBox6.Text = "Modo Consulta.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(347, 241);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 67;
            label6.Text = "Mensaje";
            // 
            // button6
            // 
            button6.Location = new Point(605, 311);
            button6.Name = "button6";
            button6.Size = new Size(121, 23);
            button6.TabIndex = 66;
            button6.Text = "Cancelar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(605, 176);
            button5.Name = "button5";
            button5.Size = new Size(121, 23);
            button5.TabIndex = 65;
            button5.Text = "Aplicar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(605, 127);
            button4.Name = "button4";
            button4.Size = new Size(121, 23);
            button4.TabIndex = 64;
            button4.Text = "Eliminar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 335);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(134, 23);
            textBox4.TabIndex = 63;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 236);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(134, 23);
            textBox1.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 239);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 54;
            label1.Text = "CUIT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 275);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 55;
            label2.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 305);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 57;
            label4.Text = "Teléfono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 338);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 58;
            label5.Text = "Mail:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 267);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 23);
            textBox2.TabIndex = 60;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(142, 302);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(134, 23);
            textBox3.TabIndex = 61;
            // 
            // button3
            // 
            button3.Location = new Point(605, 83);
            button3.Name = "button3";
            button3.Size = new Size(121, 23);
            button3.TabIndex = 53;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(605, 37);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 52;
            button2.Text = "Registrar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(53, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(511, 187);
            dataGridView1.TabIndex = 50;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // button7
            // 
            button7.Location = new Point(605, 355);
            button7.Name = "button7";
            button7.Size = new Size(121, 23);
            button7.TabIndex = 69;
            button7.Text = "Salir";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(142, 371);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(134, 23);
            textBox5.TabIndex = 72;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 374);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 71;
            label7.Text = "Direccion:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(400, 305);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(130, 139);
            listBox1.TabIndex = 73;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 310);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 74;
            label3.Text = "Productos:";
            // 
            // button1
            // 
            button1.Location = new Point(605, 222);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 75;
            button1.Text = "Agregar Producto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button8
            // 
            button8.Location = new Point(605, 267);
            button8.Name = "button8";
            button8.Size = new Size(121, 23);
            button8.TabIndex = 76;
            button8.Text = "Eliminar Producto";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // formRegistrarProveedor_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(923, 537);
            Controls.Add(button8);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(textBox5);
            Controls.Add(label7);
            Controls.Add(button7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Name = "formRegistrarProveedor_842JF";
            Text = "formRegistrarProveedor";
            FormClosed += formRegistrarProveedor_842JF_FormClosed;
            Load += formRegistrarProveedor_842JF_Load;
            Enter += formRegistrarProveedor_842JF_Enter;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox6;
        private Label label6;
        private Button button6;
        private Button button5;
        private Button button4;
        private TextBox textBox4;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button3;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button7;
        private TextBox textBox5;
        private Label label7;
        private ListBox listBox1;
        private Label label3;
        private Button button1;
        private Button button8;
    }
}