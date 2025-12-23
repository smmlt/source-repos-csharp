namespace WinFormsApp70
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
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            textBoxScalar = new TextBox();
            buttonScalar = new Button();
            buttonOpen = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonQUERY = new Button();
            textBoxQUERY = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 20F);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(17, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(314, 48);
            label1.TabIndex = 0;
            label1.Text = "DISCONNECTED";
            // 
            // button1
            // 
            button1.Font = new Font("Roboto", 20F);
            button1.Location = new Point(27, 152);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(284, 130);
            button1.TabIndex = 1;
            button1.Text = "CONNECT";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Roboto", 20F);
            textBox1.Location = new Point(27, 75);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(283, 56);
            textBox1.TabIndex = 2;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 29;
            listBox1.Location = new Point(27, 292);
            listBox1.Margin = new Padding(4, 5, 4, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(283, 410);
            listBox1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Gainsboro;
            richTextBox1.Font = new Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.Location = new Point(333, 75);
            richTextBox1.Margin = new Padding(4, 5, 4, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(791, 632);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 20F);
            label2.Location = new Point(613, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(261, 48);
            label2.TabIndex = 5;
            label2.Text = "TABLE NAME";
            // 
            // textBoxScalar
            // 
            textBoxScalar.Font = new Font("Segoe UI", 12F);
            textBoxScalar.Location = new Point(1131, 77);
            textBoxScalar.Multiline = true;
            textBoxScalar.Name = "textBoxScalar";
            textBoxScalar.Size = new Size(413, 111);
            textBoxScalar.TabIndex = 6;
            // 
            // buttonScalar
            // 
            buttonScalar.BackColor = Color.FromArgb(192, 255, 192);
            buttonScalar.Font = new Font("Segoe UI", 11F);
            buttonScalar.Location = new Point(1131, 199);
            buttonScalar.Name = "buttonScalar";
            buttonScalar.Size = new Size(168, 51);
            buttonScalar.TabIndex = 7;
            buttonScalar.Text = "EXECUTE";
            buttonScalar.UseVisualStyleBackColor = false;
            // 
            // buttonOpen
            // 
            buttonOpen.BackColor = Color.IndianRed;
            buttonOpen.Font = new Font("Segoe UI", 11F);
            buttonOpen.Location = new Point(1380, 199);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(164, 51);
            buttonOpen.TabIndex = 8;
            buttonOpen.Text = "OPEN FILE";
            buttonOpen.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(128, 128, 255);
            buttonSave.Font = new Font("Segoe UI", 11F);
            buttonSave.Location = new Point(1252, 256);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(173, 53);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "SAVE TO DB";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = SystemColors.ActiveCaption;
            buttonLoad.Font = new Font("Segoe UI", 11F);
            buttonLoad.Location = new Point(1167, 315);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(343, 57);
            buttonLoad.TabIndex = 10;
            buttonLoad.Text = "LOAD FROM DB";
            buttonLoad.UseVisualStyleBackColor = false;
            // 
            // buttonQUERY
            // 
            buttonQUERY.Location = new Point(1167, 479);
            buttonQUERY.Name = "buttonQUERY";
            buttonQUERY.Size = new Size(343, 34);
            buttonQUERY.TabIndex = 11;
            buttonQUERY.Text = "SELECT";
            buttonQUERY.UseVisualStyleBackColor = true;
            // 
            // textBoxQUERY
            // 
            textBoxQUERY.Location = new Point(1154, 392);
            textBoxQUERY.Multiline = true;
            textBoxQUERY.Name = "textBoxQUERY";
            textBoxQUERY.Size = new Size(371, 66);
            textBoxQUERY.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1569, 750);
            Controls.Add(textBoxQUERY);
            Controls.Add(buttonQUERY);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonOpen);
            Controls.Add(buttonScalar);
            Controls.Add(textBoxScalar);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private Label label2;
        private TextBox textBoxScalar;
        private Button buttonScalar;
        private Button buttonOpen;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonQUERY;
        private TextBox textBoxQUERY;
    }
}
