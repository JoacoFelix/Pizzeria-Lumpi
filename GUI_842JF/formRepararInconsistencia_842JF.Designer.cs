namespace GUI_842JF
{
    partial class formRepararInconsistencia_842JF
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(297, 185);
            button1.Name = "button1";
            button1.Size = new Size(151, 66);
            button1.TabIndex = 0;
            button1.Text = "Recalcular DV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(297, 299);
            button2.Name = "button2";
            button2.Size = new Size(151, 66);
            button2.TabIndex = 1;
            button2.Text = "Restore";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(297, 422);
            button3.Name = "button3";
            button3.Size = new Size(151, 66);
            button3.TabIndex = 2;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(238, 45);
            label1.Name = "label1";
            label1.Size = new Size(282, 30);
            label1.TabIndex = 3;
            label1.Text = "INCONSISTENCIA EN LA BD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 107);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 4;
            label2.Text = "Tabla/s Alterada/s:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(349, 107);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // formRepararInconsistencia_842JF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(817, 612);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "formRepararInconsistencia_842JF";
            Text = "formRepararInconsistencia_842JF";
            FormClosed += formRepararInconsistencia_842JF_FormClosed;
            Load += formRepararInconsistencia_842JF_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}