namespace GUI_842JF
{
    partial class formPerfiles_842JF
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
            button6 = new Button();
            label4 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            treeView1 = new TreeView();
            listBox1 = new ListBox();
            treeView2 = new TreeView();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(709, 310);
            button6.Name = "button6";
            button6.Size = new Size(118, 23);
            button6.TabIndex = 28;
            button6.Text = "Salir";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(820, 49);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 27;
            label4.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(705, 52);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 26;
            label3.Text = "Nombre";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(820, 67);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(188, 23);
            textBox2.TabIndex = 25;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(705, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 24;
            // 
            // button5
            // 
            button5.Location = new Point(709, 262);
            button5.Name = "button5";
            button5.Size = new Size(118, 23);
            button5.TabIndex = 23;
            button5.Text = "Eliminar Hijo";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(709, 215);
            button4.Name = "button4";
            button4.Size = new Size(118, 23);
            button4.TabIndex = 22;
            button4.Text = "Eliminar Perfil";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(709, 166);
            button3.Name = "button3";
            button3.Size = new Size(118, 23);
            button3.TabIndex = 21;
            button3.Text = "Asignar Familia";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(709, 116);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 20;
            button2.Text = "Asignar Permiso";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1014, 67);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 19;
            button1.Text = "Generar Perfil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(225, 28);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 18;
            label2.Text = "Familias";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 17;
            label1.Text = "Permisos";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(225, 46);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(200, 371);
            treeView1.TabIndex = 16;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(26, 46);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(158, 379);
            listBox1.TabIndex = 15;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(467, 46);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(200, 371);
            treeView2.TabIndex = 30;
            treeView2.AfterSelect += treeView2_AfterSelect;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(467, 28);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 31;
            label5.Text = "Perfiles";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 420);
            label6.Name = "label6";
            label6.Size = new Size(122, 15);
            label6.TabIndex = 33;
            label6.Text = "Familia seleccionada: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(467, 420);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 34;
            label7.Text = "Perfil seleccionado: ";
            // 
            // formPerfiles_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1146, 590);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(treeView2);
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
            Name = "formPerfiles_842JF";
            Text = "Perfiles_842JF";
            FormClosed += formPerfiles_842JF_FormClosed;
            Load += formPerfiles_842JF_Load;
            Enter += formPerfiles_842JF_Enter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button6;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private TreeView treeView1;
        private ListBox listBox1;
        private TreeView treeView2;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}