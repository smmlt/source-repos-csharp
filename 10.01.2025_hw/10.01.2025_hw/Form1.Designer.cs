namespace _10._01._2025_hw
{
    partial class Form1
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
            panel1 = new Panel();
            Horse4 = new Button();
            Horse3 = new Button();
            Horse2 = new Button();
            Horse1 = new Button();
            buttonStart = new Button();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Location = new Point(1092, 101);
            panel1.Name = "panel1";
            panel1.Size = new Size(21, 478);
            panel1.TabIndex = 0;
            // 
            // Horse4
            // 
            Horse4.BackColor = Color.Red;
            Horse4.Location = new Point(75, 138);
            Horse4.Name = "Horse4";
            Horse4.Size = new Size(133, 58);
            Horse4.TabIndex = 1;
            Horse4.Text = "Horse 4";
            Horse4.UseVisualStyleBackColor = false;
            // 
            // Horse3
            // 
            Horse3.BackColor = Color.Lime;
            Horse3.Location = new Point(75, 243);
            Horse3.Name = "Horse3";
            Horse3.Size = new Size(133, 58);
            Horse3.TabIndex = 2;
            Horse3.Text = "Horse 3";
            Horse3.UseVisualStyleBackColor = false;
            // 
            // Horse2
            // 
            Horse2.BackColor = Color.Blue;
            Horse2.Location = new Point(75, 350);
            Horse2.Name = "Horse2";
            Horse2.Size = new Size(133, 58);
            Horse2.TabIndex = 3;
            Horse2.Text = "Horse 2";
            Horse2.UseVisualStyleBackColor = false;
            // 
            // Horse1
            // 
            Horse1.BackColor = Color.FromArgb(255, 128, 0);
            Horse1.Location = new Point(75, 449);
            Horse1.Name = "Horse1";
            Horse1.Size = new Size(133, 58);
            Horse1.TabIndex = 4;
            Horse1.Text = "Horse 1";
            Horse1.UseVisualStyleBackColor = false;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(466, 607);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(199, 57);
            buttonStart.TabIndex = 5;
            buttonStart.Text = "Go go go!";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Location = new Point(58, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(21, 478);
            panel2.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 711);
            Controls.Add(panel2);
            Controls.Add(buttonStart);
            Controls.Add(Horse1);
            Controls.Add(Horse2);
            Controls.Add(Horse3);
            Controls.Add(Horse4);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Horse4;
        private Button Horse3;
        private Button Horse2;
        private Button Horse1;
        private Button buttonStart;
        private Panel panel2;
    }
}
