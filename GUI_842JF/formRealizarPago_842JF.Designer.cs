namespace GUI_842JF
{
    partial class formRealizarPago_842JF
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
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(317, 291);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(96, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 264);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 18;
            label4.Text = "Vencimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 206);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 17;
            label3.Text = "Código de seguridad";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(317, 223);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(155, 23);
            textBox3.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 145);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 15;
            label2.Text = "Nobre del Titular";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 89);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 14;
            label1.Text = "Nro. Tarjeta";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(317, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 23);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(317, 107);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Location = new Point(317, 328);
            button2.Name = "button2";
            button2.Size = new Size(128, 23);
            button2.TabIndex = 11;
            button2.Text = "Confirmar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // formRealizarPago_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Name = "formRealizarPago_842JF";
            Text = "formRealizarPago_842JF";
            FormClosed += formRealizarPago_842JF_FormClosed;
            Load += formRealizarPago_842JF_Load;
            Enter += formRealizarPago_842JF_Enter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
    }
}