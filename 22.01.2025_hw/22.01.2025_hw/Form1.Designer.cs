namespace _22._01._2025_hw
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
            textBoxWordToFind = new TextBox();
            buttonFilePath = new Button();
            buttonFind = new Button();
            labelResult = new Label();
            SuspendLayout();
            // 
            // textBoxWordToFind
            // 
            textBoxWordToFind.Location = new Point(157, 198);
            textBoxWordToFind.Name = "textBoxWordToFind";
            textBoxWordToFind.PlaceholderText = "Enter word to find";
            textBoxWordToFind.Size = new Size(261, 31);
            textBoxWordToFind.TabIndex = 0;
            // 
            // buttonFilePath
            // 
            buttonFilePath.BackColor = Color.OrangeRed;
            buttonFilePath.Location = new Point(206, 108);
            buttonFilePath.Name = "buttonFilePath";
            buttonFilePath.Size = new Size(165, 54);
            buttonFilePath.TabIndex = 1;
            buttonFilePath.Text = "Select FIle";
            buttonFilePath.UseVisualStyleBackColor = false;
            // 
            // buttonFind
            // 
            buttonFind.BackColor = Color.FromArgb(128, 255, 128);
            buttonFind.Location = new Point(229, 265);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(112, 34);
            buttonFind.TabIndex = 2;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(157, 326);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(59, 25);
            labelResult.TabIndex = 3;
            labelResult.Text = "Result";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 460);
            Controls.Add(labelResult);
            Controls.Add(buttonFind);
            Controls.Add(buttonFilePath);
            Controls.Add(textBoxWordToFind);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxWordToFind;
        private Button buttonFilePath;
        private Button buttonFind;
        private Label labelResult;
    }
}
