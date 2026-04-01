namespace GUI_842JF
{
    partial class formFamilias_842JF
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
            listBox1 = new ListBox();
            treeView1 = new TreeView();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button6 = new Button();
            button9 = new Button();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(46, 59);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(162, 379);
            listBox1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(367, 59);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(200, 371);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 41);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "Permisos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(367, 41);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = "Familias";
            // 
            // button1
            // 
            button1.Location = new Point(878, 86);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 4;
            button1.Text = "Generar Familia";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(573, 135);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 5;
            button2.Text = "Asignar Permiso";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(573, 185);
            button3.Name = "button3";
            button3.Size = new Size(118, 23);
            button3.TabIndex = 6;
            button3.Text = "Asignar Familia";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(573, 234);
            button4.Name = "button4";
            button4.Size = new Size(118, 23);
            button4.TabIndex = 7;
            button4.Text = "Eliminar Familia";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(573, 281);
            button5.Name = "button5";
            button5.Size = new Size(118, 23);
            button5.TabIndex = 8;
            button5.Text = "Eliminar Hijo";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(569, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(684, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(188, 23);
            textBox2.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(569, 71);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 11;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(684, 68);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 12;
            label4.Text = "Descripción";
            // 
            // button6
            // 
            button6.Location = new Point(573, 407);
            button6.Name = "button6";
            button6.Size = new Size(118, 23);
            button6.TabIndex = 13;
            button6.Text = "Salir";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button9
            // 
            button9.Location = new Point(573, 323);
            button9.Name = "button9";
            button9.Size = new Size(118, 23);
            button9.TabIndex = 16;
            button9.Text = "Seleccionar";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(367, 433);
            label5.Name = "label5";
            label5.Size = new Size(169, 15);
            label5.TabIndex = 17;
            label5.Text = "Familia seleccionada TreeView:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(573, 375);
            label6.Name = "label6";
            label6.Size = new Size(122, 15);
            label6.TabIndex = 18;
            label6.Text = "Familia seleccionada: ";
            // 
            // formFamilias_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1126, 561);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button9);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Controls.Add(listBox1);
            Name = "formFamilias_842JF";
            Text = "formFamilias_842JF";
            FormClosed += formFamilias_842JF_FormClosed;
            Load += formFamilias_842JF_Load;
            Enter += formFamilias_842JF_Enter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TreeView treeView1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Button button6;
        private Button button9;
        private Label label5;
        private Label label6;
    }
}