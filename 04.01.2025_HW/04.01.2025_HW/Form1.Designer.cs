namespace _04._01._2025_HW
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
            buttonStart = new Button();
            listBox1 = new ListBox();
            labelMax = new Label();
            labelAvg = new Label();
            labelMin = new Label();
            buttonToFile = new Button();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(427, 268);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(112, 34);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(583, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(409, 554);
            listBox1.TabIndex = 1;
            // 
            // labelMax
            // 
            labelMax.AutoSize = true;
            labelMax.Font = new Font("Segoe UI", 13F);
            labelMax.Location = new Point(12, 41);
            labelMax.Name = "labelMax";
            labelMax.Size = new Size(136, 36);
            labelMax.TabIndex = 5;
            labelMax.Text = "Max value:";
            // 
            // labelAvg
            // 
            labelAvg.AutoSize = true;
            labelAvg.Font = new Font("Segoe UI", 13F);
            labelAvg.Location = new Point(12, 333);
            labelAvg.Name = "labelAvg";
            labelAvg.Size = new Size(131, 36);
            labelAvg.TabIndex = 8;
            labelAvg.Text = "Avg value:";
            // 
            // labelMin
            // 
            labelMin.AutoSize = true;
            labelMin.Font = new Font("Segoe UI", 13F);
            labelMin.Location = new Point(12, 184);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(132, 36);
            labelMin.TabIndex = 9;
            labelMin.Text = "Min value:";
            // 
            // buttonToFile
            // 
            buttonToFile.BackColor = Color.FromArgb(255, 192, 128);
            buttonToFile.ForeColor = SystemColors.ControlText;
            buttonToFile.Location = new Point(427, 543);
            buttonToFile.Name = "buttonToFile";
            buttonToFile.Size = new Size(138, 52);
            buttonToFile.TabIndex = 10;
            buttonToFile.Text = "Write to file";
            buttonToFile.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 669);
            Controls.Add(buttonToFile);
            Controls.Add(labelMin);
            Controls.Add(labelAvg);
            Controls.Add(labelMax);
            Controls.Add(listBox1);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private ListBox listBox1;
        private Label labelMax;
        private Label labelAvg;
        private Label labelMin;
        private Button buttonToFile;
    }
}
