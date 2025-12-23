namespace _04._12._2024_CW2
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
            textBoxName = new TextBox();
            textBoxGenre = new TextBox();
            buttonAdd = new Button();
            textBoxRating = new TextBox();
            checkBox1 = new CheckBox();
            buttonShow = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(203, 9);
            label1.Name = "label1";
            label1.Size = new Size(171, 30);
            label1.TabIndex = 0;
            label1.Text = "DISCONNECTED";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 484);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Enter name";
            textBoxName.Size = new Size(300, 31);
            textBoxName.TabIndex = 5;
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(12, 537);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.PlaceholderText = "Enter genre";
            textBoxGenre.Size = new Size(300, 31);
            textBoxGenre.TabIndex = 6;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(64, 726);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(178, 63);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Add game";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxRating
            // 
            textBoxRating.Location = new Point(12, 636);
            textBoxRating.Name = "textBoxRating";
            textBoxRating.PlaceholderText = "Enter rating";
            textBoxRating.Size = new Size(300, 31);
            textBoxRating.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(104, 682);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(109, 29);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "For Sale?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(439, 713);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(178, 63);
            buttonShow.TabIndex = 11;
            buttonShow.Text = "Show all game";
            buttonShow.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(414, 617);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(240, 50);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(414, 518);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(240, 50);
            buttonUpdate.TabIndex = 13;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(12, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(768, 429);
            listBox1.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 585);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 833);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(buttonShow);
            Controls.Add(checkBox1);
            Controls.Add(textBoxRating);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxGenre);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxGenre;
        private Button buttonAdd;
        private TextBox textBoxRating;
        private CheckBox checkBox1;
        private Button buttonShow;
        private Button buttonDelete;
        private Button buttonUpdate;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
    }
}
