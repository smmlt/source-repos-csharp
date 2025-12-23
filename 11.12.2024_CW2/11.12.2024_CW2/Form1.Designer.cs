namespace _11._12._2024_CW2
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
            panelLogIn = new Panel();
            buttonLogIn = new Button();
            textBoxPassword = new TextBox();
            textBoxLogIn = new TextBox();
            labelLogIn = new Label();
            listBoxUser_info = new ListBox();
            panelInfo = new Panel();
            buttonLogOut = new Button();
            dateTimePickerUser = new DateTimePicker();
            buttonUpdateMusicGr = new Button();
            buttonAddUserInfo = new Button();
            radioButtonNo = new RadioButton();
            radioButtonYes = new RadioButton();
            labelSubscr = new Label();
            textBoxLike_Music_Groups = new TextBox();
            textBoxUserCountry = new TextBox();
            textBoxUserName = new TextBox();
            labelInfo = new Label();
            panelMusicGroup = new Panel();
            listBoxMusicGroup = new ListBox();
            buttonNewMusicGroup = new Button();
            buttonUpdateUserInfo = new Button();
            buttonDeleteMusicGr = new Button();
            textBoxTitleMusicGr = new TextBox();
            textBoxGengeMusicGr = new TextBox();
            panelLogIn.SuspendLayout();
            panelInfo.SuspendLayout();
            panelMusicGroup.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogIn
            // 
            panelLogIn.BackColor = Color.LightSeaGreen;
            panelLogIn.Controls.Add(buttonLogIn);
            panelLogIn.Controls.Add(textBoxPassword);
            panelLogIn.Controls.Add(textBoxLogIn);
            panelLogIn.Controls.Add(labelLogIn);
            panelLogIn.Location = new Point(35, 56);
            panelLogIn.Name = "panelLogIn";
            panelLogIn.Size = new Size(429, 355);
            panelLogIn.TabIndex = 1;
            // 
            // buttonLogIn
            // 
            buttonLogIn.Location = new Point(102, 218);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(223, 81);
            buttonLogIn.TabIndex = 3;
            buttonLogIn.Text = "Sign in";
            buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(54, 154);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(319, 31);
            textBoxPassword.TabIndex = 2;
            // 
            // textBoxLogIn
            // 
            textBoxLogIn.Location = new Point(54, 108);
            textBoxLogIn.Name = "textBoxLogIn";
            textBoxLogIn.PlaceholderText = "Login";
            textBoxLogIn.Size = new Size(319, 31);
            textBoxLogIn.TabIndex = 1;
            // 
            // labelLogIn
            // 
            labelLogIn.AutoSize = true;
            labelLogIn.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelLogIn.Location = new Point(54, 43);
            labelLogIn.Name = "labelLogIn";
            labelLogIn.Size = new Size(303, 27);
            labelLogIn.TabIndex = 0;
            labelLogIn.Text = "Enter your login and password";
            // 
            // listBoxUser_info
            // 
            listBoxUser_info.FormattingEnabled = true;
            listBoxUser_info.ItemHeight = 25;
            listBoxUser_info.Location = new Point(18, 56);
            listBoxUser_info.Name = "listBoxUser_info";
            listBoxUser_info.Size = new Size(594, 354);
            listBoxUser_info.TabIndex = 2;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.LightSeaGreen;
            panelInfo.Controls.Add(buttonUpdateUserInfo);
            panelInfo.Controls.Add(buttonLogOut);
            panelInfo.Controls.Add(dateTimePickerUser);
            panelInfo.Controls.Add(buttonAddUserInfo);
            panelInfo.Controls.Add(radioButtonNo);
            panelInfo.Controls.Add(radioButtonYes);
            panelInfo.Controls.Add(labelSubscr);
            panelInfo.Controls.Add(textBoxLike_Music_Groups);
            panelInfo.Controls.Add(textBoxUserCountry);
            panelInfo.Controls.Add(textBoxUserName);
            panelInfo.Controls.Add(labelInfo);
            panelInfo.Controls.Add(listBoxUser_info);
            panelInfo.Location = new Point(521, 56);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(635, 695);
            panelInfo.TabIndex = 3;
            // 
            // buttonLogOut
            // 
            buttonLogOut.Location = new Point(430, 615);
            buttonLogOut.Name = "buttonLogOut";
            buttonLogOut.Size = new Size(182, 50);
            buttonLogOut.TabIndex = 14;
            buttonLogOut.Text = "Log out";
            buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerUser
            // 
            dateTimePickerUser.Location = new Point(346, 429);
            dateTimePickerUser.Name = "dateTimePickerUser";
            dateTimePickerUser.Size = new Size(266, 31);
            dateTimePickerUser.TabIndex = 13;
            // 
            // buttonUpdateMusicGr
            // 
            buttonUpdateMusicGr.Location = new Point(150, 412);
            buttonUpdateMusicGr.Name = "buttonUpdateMusicGr";
            buttonUpdateMusicGr.Size = new Size(118, 50);
            buttonUpdateMusicGr.TabIndex = 12;
            buttonUpdateMusicGr.Text = "Update info";
            buttonUpdateMusicGr.UseVisualStyleBackColor = true;
            // 
            // buttonAddUserInfo
            // 
            buttonAddUserInfo.Location = new Point(18, 615);
            buttonAddUserInfo.Name = "buttonAddUserInfo";
            buttonAddUserInfo.Size = new Size(182, 50);
            buttonAddUserInfo.TabIndex = 11;
            buttonAddUserInfo.Text = "Add info";
            buttonAddUserInfo.UseVisualStyleBackColor = true;
            // 
            // radioButtonNo
            // 
            radioButtonNo.AutoSize = true;
            radioButtonNo.Location = new Point(349, 561);
            radioButtonNo.Name = "radioButtonNo";
            radioButtonNo.Size = new Size(61, 29);
            radioButtonNo.TabIndex = 10;
            radioButtonNo.TabStop = true;
            radioButtonNo.Text = "No";
            radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonYes
            // 
            radioButtonYes.AutoSize = true;
            radioButtonYes.Location = new Point(213, 561);
            radioButtonYes.Name = "radioButtonYes";
            radioButtonYes.Size = new Size(62, 29);
            radioButtonYes.TabIndex = 9;
            radioButtonYes.TabStop = true;
            radioButtonYes.Text = "Yes";
            radioButtonYes.UseVisualStyleBackColor = true;
            // 
            // labelSubscr
            // 
            labelSubscr.AutoSize = true;
            labelSubscr.BackColor = Color.Lime;
            labelSubscr.Location = new Point(213, 533);
            labelSubscr.Name = "labelSubscr";
            labelSubscr.Size = new Size(197, 25);
            labelSubscr.TabIndex = 8;
            labelSubscr.Text = "Newsletter subscription";
            // 
            // textBoxLike_Music_Groups
            // 
            textBoxLike_Music_Groups.Location = new Point(346, 482);
            textBoxLike_Music_Groups.Name = "textBoxLike_Music_Groups";
            textBoxLike_Music_Groups.PlaceholderText = "Enter your favorite group";
            textBoxLike_Music_Groups.Size = new Size(266, 31);
            textBoxLike_Music_Groups.TabIndex = 7;
            // 
            // textBoxUserCountry
            // 
            textBoxUserCountry.Location = new Point(18, 482);
            textBoxUserCountry.Name = "textBoxUserCountry";
            textBoxUserCountry.PlaceholderText = "Enter your country";
            textBoxUserCountry.Size = new Size(266, 31);
            textBoxUserCountry.TabIndex = 6;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(18, 429);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.PlaceholderText = "Enter name";
            textBoxUserName.Size = new Size(266, 31);
            textBoxUserName.TabIndex = 4;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(18, 18);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(99, 27);
            labelInfo.TabIndex = 3;
            labelInfo.Text = "Your info";
            // 
            // panelMusicGroup
            // 
            panelMusicGroup.BackColor = Color.Orange;
            panelMusicGroup.Controls.Add(textBoxGengeMusicGr);
            panelMusicGroup.Controls.Add(textBoxTitleMusicGr);
            panelMusicGroup.Controls.Add(buttonDeleteMusicGr);
            panelMusicGroup.Controls.Add(buttonNewMusicGroup);
            panelMusicGroup.Controls.Add(listBoxMusicGroup);
            panelMusicGroup.Controls.Add(buttonUpdateMusicGr);
            panelMusicGroup.Location = new Point(35, 468);
            panelMusicGroup.Name = "panelMusicGroup";
            panelMusicGroup.Size = new Size(429, 493);
            panelMusicGroup.TabIndex = 4;
            // 
            // listBoxMusicGroup
            // 
            listBoxMusicGroup.FormattingEnabled = true;
            listBoxMusicGroup.ItemHeight = 25;
            listBoxMusicGroup.Location = new Point(26, 29);
            listBoxMusicGroup.Name = "listBoxMusicGroup";
            listBoxMusicGroup.Size = new Size(376, 229);
            listBoxMusicGroup.TabIndex = 0;
            // 
            // buttonNewMusicGroup
            // 
            buttonNewMusicGroup.Location = new Point(26, 412);
            buttonNewMusicGroup.Name = "buttonNewMusicGroup";
            buttonNewMusicGroup.Size = new Size(118, 50);
            buttonNewMusicGroup.TabIndex = 15;
            buttonNewMusicGroup.Text = "Add info";
            buttonNewMusicGroup.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateUserInfo
            // 
            buttonUpdateUserInfo.Location = new Point(228, 615);
            buttonUpdateUserInfo.Name = "buttonUpdateUserInfo";
            buttonUpdateUserInfo.Size = new Size(182, 50);
            buttonUpdateUserInfo.TabIndex = 16;
            buttonUpdateUserInfo.Text = "Update info";
            buttonUpdateUserInfo.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMusicGr
            // 
            buttonDeleteMusicGr.Location = new Point(284, 412);
            buttonDeleteMusicGr.Name = "buttonDeleteMusicGr";
            buttonDeleteMusicGr.Size = new Size(118, 50);
            buttonDeleteMusicGr.TabIndex = 16;
            buttonDeleteMusicGr.Text = "Delete";
            buttonDeleteMusicGr.UseVisualStyleBackColor = true;
            // 
            // textBoxTitleMusicGr
            // 
            textBoxTitleMusicGr.Location = new Point(26, 279);
            textBoxTitleMusicGr.Multiline = true;
            textBoxTitleMusicGr.Name = "textBoxTitleMusicGr";
            textBoxTitleMusicGr.PlaceholderText = "Enter title of the music group";
            textBoxTitleMusicGr.Size = new Size(376, 43);
            textBoxTitleMusicGr.TabIndex = 17;
            // 
            // textBoxGengeMusicGr
            // 
            textBoxGengeMusicGr.Location = new Point(26, 339);
            textBoxGengeMusicGr.Name = "textBoxGengeMusicGr";
            textBoxGengeMusicGr.PlaceholderText = "Enter genre of the music group";
            textBoxGengeMusicGr.Size = new Size(376, 31);
            textBoxGengeMusicGr.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 1002);
            Controls.Add(panelMusicGroup);
            Controls.Add(panelInfo);
            Controls.Add(panelLogIn);
            Name = "Form1";
            Text = "Form1";
            panelLogIn.ResumeLayout(false);
            panelLogIn.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelMusicGroup.ResumeLayout(false);
            panelMusicGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelLogIn;
        private Button buttonLogIn;
        private TextBox textBoxPassword;
        private TextBox textBoxLogIn;
        private Label labelLogIn;
        private ListBox listBoxUser_info;
        private Panel panelInfo;
        private Label labelInfo;
        private Label labelSubscr;
        private TextBox textBoxLike_Music_Groups;
        private TextBox textBoxUserCountry;
        private TextBox textBoxUserName;
        private Button buttonDelete_Profile;
        private DateTimePicker dateTimePickerUser;
        private Button buttonUpdateMusicGr;
        private Button buttonAddUserInfo;
        private RadioButton radioButtonNo;
        private RadioButton radioButtonYes;
        private Button buttonLogOut;
        private Panel panelMusicGroup;
        private ListBox listBoxMusicGroup;
        private Button buttonNewMusicGroup;
        private Button buttonUpdateUserInfo;
        private Button buttonDeleteMusicGr;
        private TextBox textBoxTitleMusicGr;
        private TextBox textBoxGengeMusicGr;
    }
}
