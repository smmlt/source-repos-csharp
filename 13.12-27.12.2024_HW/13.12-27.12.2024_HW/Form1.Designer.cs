namespace _13._12_27._12._2024_HW
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
            panelStudio = new Panel();
            textBoxStudio_GameId = new TextBox();
            buttonStudioUpdate = new Button();
            buttonAddNewStudio = new Button();
            textBoxStudioCountry = new TextBox();
            textBoxStudioName = new TextBox();
            listBoxStudioInfo = new ListBox();
            panelGenre = new Panel();
            buttonGenreUpdate = new Button();
            buttonAddNewGenre = new Button();
            textBoxGenre_GameId = new TextBox();
            textBoxGenreName = new TextBox();
            listBoxGenreInfo = new ListBox();
            panelGame = new Panel();
            dateTimePickerGameReleaseYear = new DateTimePicker();
            buttonGameUpdate = new Button();
            buttonAddNewGame = new Button();
            textBoxGame_GenreId = new TextBox();
            textBoxGame_StudioId = new TextBox();
            textBoxGameTitle = new TextBox();
            listBoxGameInfo = new ListBox();
            panelFind1 = new Panel();
            buttonFindToGameAndStudio = new Button();
            buttonFindToYearRelease = new Button();
            buttonFindToGenre = new Button();
            buttonFindToStudio = new Button();
            buttonFindToName = new Button();
            textBoxFindToYear = new TextBox();
            textBoxFindToGenre = new TextBox();
            textBoxFindToStudioName = new TextBox();
            textBoxFindToGameName = new TextBox();
            listBoxFind1 = new ListBox();
            panelShowTop3 = new Panel();
            buttonShowAllNeedInfo = new Button();
            listBoxShowTop3 = new ListBox();
            buttonStudioDelete = new Button();
            panelStudio.SuspendLayout();
            panelGenre.SuspendLayout();
            panelGame.SuspendLayout();
            panelFind1.SuspendLayout();
            panelShowTop3.SuspendLayout();
            SuspendLayout();
            // 
            // panelStudio
            // 
            panelStudio.Controls.Add(buttonStudioDelete);
            panelStudio.Controls.Add(textBoxStudio_GameId);
            panelStudio.Controls.Add(buttonStudioUpdate);
            panelStudio.Controls.Add(buttonAddNewStudio);
            panelStudio.Controls.Add(textBoxStudioCountry);
            panelStudio.Controls.Add(textBoxStudioName);
            panelStudio.Controls.Add(listBoxStudioInfo);
            panelStudio.Location = new Point(28, 34);
            panelStudio.Name = "panelStudio";
            panelStudio.Size = new Size(495, 596);
            panelStudio.TabIndex = 0;
            // 
            // textBoxStudio_GameId
            // 
            textBoxStudio_GameId.Location = new Point(25, 365);
            textBoxStudio_GameId.Name = "textBoxStudio_GameId";
            textBoxStudio_GameId.PlaceholderText = "Enter the game ID from the list table";
            textBoxStudio_GameId.Size = new Size(441, 31);
            textBoxStudio_GameId.TabIndex = 5;
            // 
            // buttonStudioUpdate
            // 
            buttonStudioUpdate.Location = new Point(305, 408);
            buttonStudioUpdate.Name = "buttonStudioUpdate";
            buttonStudioUpdate.Size = new Size(161, 34);
            buttonStudioUpdate.TabIndex = 4;
            buttonStudioUpdate.Text = "Update info";
            buttonStudioUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewStudio
            // 
            buttonAddNewStudio.Location = new Point(25, 408);
            buttonAddNewStudio.Name = "buttonAddNewStudio";
            buttonAddNewStudio.Size = new Size(161, 34);
            buttonAddNewStudio.TabIndex = 3;
            buttonAddNewStudio.Text = "Add new";
            buttonAddNewStudio.UseVisualStyleBackColor = true;
            // 
            // textBoxStudioCountry
            // 
            textBoxStudioCountry.Location = new Point(25, 328);
            textBoxStudioCountry.Name = "textBoxStudioCountry";
            textBoxStudioCountry.PlaceholderText = "Enter the name of the country";
            textBoxStudioCountry.Size = new Size(441, 31);
            textBoxStudioCountry.TabIndex = 2;
            // 
            // textBoxStudioName
            // 
            textBoxStudioName.Location = new Point(25, 276);
            textBoxStudioName.Multiline = true;
            textBoxStudioName.Name = "textBoxStudioName";
            textBoxStudioName.PlaceholderText = "Enter the title of the studio (necessarily)";
            textBoxStudioName.Size = new Size(441, 46);
            textBoxStudioName.TabIndex = 1;
            // 
            // listBoxStudioInfo
            // 
            listBoxStudioInfo.FormattingEnabled = true;
            listBoxStudioInfo.ItemHeight = 25;
            listBoxStudioInfo.Location = new Point(25, 27);
            listBoxStudioInfo.Name = "listBoxStudioInfo";
            listBoxStudioInfo.Size = new Size(441, 229);
            listBoxStudioInfo.TabIndex = 0;
            // 
            // panelGenre
            // 
            panelGenre.Controls.Add(buttonGenreUpdate);
            panelGenre.Controls.Add(buttonAddNewGenre);
            panelGenre.Controls.Add(textBoxGenre_GameId);
            panelGenre.Controls.Add(textBoxGenreName);
            panelGenre.Controls.Add(listBoxGenreInfo);
            panelGenre.Location = new Point(1066, 34);
            panelGenre.Name = "panelGenre";
            panelGenre.Size = new Size(495, 596);
            panelGenre.TabIndex = 1;
            // 
            // buttonGenreUpdate
            // 
            buttonGenreUpdate.Location = new Point(309, 408);
            buttonGenreUpdate.Name = "buttonGenreUpdate";
            buttonGenreUpdate.Size = new Size(161, 34);
            buttonGenreUpdate.TabIndex = 9;
            buttonGenreUpdate.Text = "Update info";
            buttonGenreUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewGenre
            // 
            buttonAddNewGenre.Location = new Point(29, 408);
            buttonAddNewGenre.Name = "buttonAddNewGenre";
            buttonAddNewGenre.Size = new Size(161, 34);
            buttonAddNewGenre.TabIndex = 9;
            buttonAddNewGenre.Text = "Add new";
            buttonAddNewGenre.UseVisualStyleBackColor = true;
            // 
            // textBoxGenre_GameId
            // 
            textBoxGenre_GameId.Location = new Point(29, 315);
            textBoxGenre_GameId.Name = "textBoxGenre_GameId";
            textBoxGenre_GameId.PlaceholderText = "Enter the game ID from the list table";
            textBoxGenre_GameId.Size = new Size(441, 31);
            textBoxGenre_GameId.TabIndex = 11;
            // 
            // textBoxGenreName
            // 
            textBoxGenreName.Location = new Point(29, 278);
            textBoxGenreName.Name = "textBoxGenreName";
            textBoxGenreName.PlaceholderText = "Enter the title of the genre";
            textBoxGenreName.Size = new Size(441, 31);
            textBoxGenreName.TabIndex = 10;
            // 
            // listBoxGenreInfo
            // 
            listBoxGenreInfo.FormattingEnabled = true;
            listBoxGenreInfo.ItemHeight = 25;
            listBoxGenreInfo.Location = new Point(29, 27);
            listBoxGenreInfo.Name = "listBoxGenreInfo";
            listBoxGenreInfo.Size = new Size(441, 229);
            listBoxGenreInfo.TabIndex = 9;
            // 
            // panelGame
            // 
            panelGame.Controls.Add(dateTimePickerGameReleaseYear);
            panelGame.Controls.Add(buttonGameUpdate);
            panelGame.Controls.Add(buttonAddNewGame);
            panelGame.Controls.Add(textBoxGame_GenreId);
            panelGame.Controls.Add(textBoxGame_StudioId);
            panelGame.Controls.Add(textBoxGameTitle);
            panelGame.Controls.Add(listBoxGameInfo);
            panelGame.Location = new Point(544, 34);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(495, 596);
            panelGame.TabIndex = 1;
            // 
            // dateTimePickerGameReleaseYear
            // 
            dateTimePickerGameReleaseYear.Location = new Point(26, 315);
            dateTimePickerGameReleaseYear.Name = "dateTimePickerGameReleaseYear";
            dateTimePickerGameReleaseYear.Size = new Size(300, 31);
            dateTimePickerGameReleaseYear.TabIndex = 4;
            // 
            // buttonGameUpdate
            // 
            buttonGameUpdate.Location = new Point(306, 457);
            buttonGameUpdate.Name = "buttonGameUpdate";
            buttonGameUpdate.Size = new Size(161, 34);
            buttonGameUpdate.TabIndex = 4;
            buttonGameUpdate.Text = "Update info";
            buttonGameUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewGame
            // 
            buttonAddNewGame.Location = new Point(26, 457);
            buttonAddNewGame.Name = "buttonAddNewGame";
            buttonAddNewGame.Size = new Size(161, 34);
            buttonAddNewGame.TabIndex = 5;
            buttonAddNewGame.Text = "Add new";
            buttonAddNewGame.UseVisualStyleBackColor = true;
            // 
            // textBoxGame_GenreId
            // 
            textBoxGame_GenreId.Location = new Point(26, 382);
            textBoxGame_GenreId.Name = "textBoxGame_GenreId";
            textBoxGame_GenreId.PlaceholderText = "Enter the ID of the genre from the list table (necessarily)";
            textBoxGame_GenreId.Size = new Size(441, 31);
            textBoxGame_GenreId.TabIndex = 8;
            // 
            // textBoxGame_StudioId
            // 
            textBoxGame_StudioId.BorderStyle = BorderStyle.None;
            textBoxGame_StudioId.Location = new Point(26, 352);
            textBoxGame_StudioId.Name = "textBoxGame_StudioId";
            textBoxGame_StudioId.PlaceholderText = "Enter the studio ID from the list table (necessarily)";
            textBoxGame_StudioId.Size = new Size(441, 24);
            textBoxGame_StudioId.TabIndex = 7;
            // 
            // textBoxGameTitle
            // 
            textBoxGameTitle.Location = new Point(26, 278);
            textBoxGameTitle.Name = "textBoxGameTitle";
            textBoxGameTitle.PlaceholderText = "Enter the title of the game (necessarily)";
            textBoxGameTitle.Size = new Size(441, 31);
            textBoxGameTitle.TabIndex = 6;
            // 
            // listBoxGameInfo
            // 
            listBoxGameInfo.FormattingEnabled = true;
            listBoxGameInfo.HorizontalScrollbar = true;
            listBoxGameInfo.ItemHeight = 25;
            listBoxGameInfo.Location = new Point(26, 27);
            listBoxGameInfo.Name = "listBoxGameInfo";
            listBoxGameInfo.Size = new Size(441, 229);
            listBoxGameInfo.TabIndex = 5;
            // 
            // panelFind1
            // 
            panelFind1.Controls.Add(buttonFindToGameAndStudio);
            panelFind1.Controls.Add(buttonFindToYearRelease);
            panelFind1.Controls.Add(buttonFindToGenre);
            panelFind1.Controls.Add(buttonFindToStudio);
            panelFind1.Controls.Add(buttonFindToName);
            panelFind1.Controls.Add(textBoxFindToYear);
            panelFind1.Controls.Add(textBoxFindToGenre);
            panelFind1.Controls.Add(textBoxFindToStudioName);
            panelFind1.Controls.Add(textBoxFindToGameName);
            panelFind1.Controls.Add(listBoxFind1);
            panelFind1.Location = new Point(28, 636);
            panelFind1.Name = "panelFind1";
            panelFind1.Size = new Size(495, 557);
            panelFind1.TabIndex = 2;
            // 
            // buttonFindToGameAndStudio
            // 
            buttonFindToGameAndStudio.Location = new Point(187, 379);
            buttonFindToGameAndStudio.Name = "buttonFindToGameAndStudio";
            buttonFindToGameAndStudio.Size = new Size(112, 34);
            buttonFindToGameAndStudio.TabIndex = 9;
            buttonFindToGameAndStudio.Text = "1 and 2";
            buttonFindToGameAndStudio.UseVisualStyleBackColor = true;
            // 
            // buttonFindToYearRelease
            // 
            buttonFindToYearRelease.Location = new Point(368, 339);
            buttonFindToYearRelease.Name = "buttonFindToYearRelease";
            buttonFindToYearRelease.Size = new Size(112, 34);
            buttonFindToYearRelease.TabIndex = 8;
            buttonFindToYearRelease.Text = "4";
            buttonFindToYearRelease.UseVisualStyleBackColor = true;
            // 
            // buttonFindToGenre
            // 
            buttonFindToGenre.Location = new Point(250, 339);
            buttonFindToGenre.Name = "buttonFindToGenre";
            buttonFindToGenre.Size = new Size(112, 34);
            buttonFindToGenre.TabIndex = 7;
            buttonFindToGenre.Text = "3";
            buttonFindToGenre.UseVisualStyleBackColor = true;
            // 
            // buttonFindToStudio
            // 
            buttonFindToStudio.Location = new Point(132, 339);
            buttonFindToStudio.Name = "buttonFindToStudio";
            buttonFindToStudio.Size = new Size(112, 34);
            buttonFindToStudio.TabIndex = 6;
            buttonFindToStudio.Text = "2";
            buttonFindToStudio.UseVisualStyleBackColor = true;
            // 
            // buttonFindToName
            // 
            buttonFindToName.Location = new Point(14, 339);
            buttonFindToName.Name = "buttonFindToName";
            buttonFindToName.Size = new Size(112, 34);
            buttonFindToName.TabIndex = 5;
            buttonFindToName.Text = "1";
            buttonFindToName.UseVisualStyleBackColor = true;
            // 
            // textBoxFindToYear
            // 
            textBoxFindToYear.Location = new Point(25, 291);
            textBoxFindToYear.Name = "textBoxFindToYear";
            textBoxFindToYear.PlaceholderText = "4. Enter year of release";
            textBoxFindToYear.Size = new Size(441, 31);
            textBoxFindToYear.TabIndex = 4;
            // 
            // textBoxFindToGenre
            // 
            textBoxFindToGenre.Location = new Point(25, 254);
            textBoxFindToGenre.Name = "textBoxFindToGenre";
            textBoxFindToGenre.PlaceholderText = "3. Enter genre";
            textBoxFindToGenre.Size = new Size(441, 31);
            textBoxFindToGenre.TabIndex = 3;
            // 
            // textBoxFindToStudioName
            // 
            textBoxFindToStudioName.Location = new Point(25, 217);
            textBoxFindToStudioName.Name = "textBoxFindToStudioName";
            textBoxFindToStudioName.PlaceholderText = "2. Enter studio title";
            textBoxFindToStudioName.Size = new Size(441, 31);
            textBoxFindToStudioName.TabIndex = 2;
            // 
            // textBoxFindToGameName
            // 
            textBoxFindToGameName.Location = new Point(25, 180);
            textBoxFindToGameName.Name = "textBoxFindToGameName";
            textBoxFindToGameName.PlaceholderText = "1. Enter game anme";
            textBoxFindToGameName.Size = new Size(441, 31);
            textBoxFindToGameName.TabIndex = 1;
            // 
            // listBoxFind1
            // 
            listBoxFind1.FormattingEnabled = true;
            listBoxFind1.ItemHeight = 25;
            listBoxFind1.Location = new Point(25, 14);
            listBoxFind1.Name = "listBoxFind1";
            listBoxFind1.Size = new Size(441, 154);
            listBoxFind1.TabIndex = 0;
            // 
            // panelShowTop3
            // 
            panelShowTop3.Controls.Add(buttonShowAllNeedInfo);
            panelShowTop3.Controls.Add(listBoxShowTop3);
            panelShowTop3.Location = new Point(545, 650);
            panelShowTop3.Name = "panelShowTop3";
            panelShowTop3.Size = new Size(495, 271);
            panelShowTop3.TabIndex = 3;
            // 
            // buttonShowAllNeedInfo
            // 
            buttonShowAllNeedInfo.Location = new Point(187, 203);
            buttonShowAllNeedInfo.Name = "buttonShowAllNeedInfo";
            buttonShowAllNeedInfo.Size = new Size(112, 34);
            buttonShowAllNeedInfo.TabIndex = 1;
            buttonShowAllNeedInfo.Text = "button1";
            buttonShowAllNeedInfo.UseVisualStyleBackColor = true;
            // 
            // listBoxShowTop3
            // 
            listBoxShowTop3.FormattingEnabled = true;
            listBoxShowTop3.HorizontalScrollbar = true;
            listBoxShowTop3.ItemHeight = 25;
            listBoxShowTop3.Location = new Point(26, 16);
            listBoxShowTop3.Name = "listBoxShowTop3";
            listBoxShowTop3.Size = new Size(441, 154);
            listBoxShowTop3.TabIndex = 0;
            // 
            // buttonStudioDelete
            // 
            buttonStudioDelete.Location = new Point(163, 457);
            buttonStudioDelete.Name = "buttonStudioDelete";
            buttonStudioDelete.Size = new Size(161, 34);
            buttonStudioDelete.TabIndex = 6;
            buttonStudioDelete.Text = "Delete";
            buttonStudioDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1573, 1205);
            Controls.Add(panelShowTop3);
            Controls.Add(panelFind1);
            Controls.Add(panelGenre);
            Controls.Add(panelGame);
            Controls.Add(panelStudio);
            Name = "Form1";
            Text = "Form1";
            panelStudio.ResumeLayout(false);
            panelStudio.PerformLayout();
            panelGenre.ResumeLayout(false);
            panelGenre.PerformLayout();
            panelGame.ResumeLayout(false);
            panelGame.PerformLayout();
            panelFind1.ResumeLayout(false);
            panelFind1.PerformLayout();
            panelShowTop3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelStudio;
        private Panel panelGenre;
        private ListBox listBoxStudioInfo;
        private Panel panelGame;
        private Button buttonAddNewStudio;
        private TextBox textBoxStudioCountry;
        private TextBox textBoxStudioName;
        private Button buttonStudioUpdate;
        private ListBox listBoxGameInfo;
        private TextBox textBoxGameTitle;
        private TextBox textBoxGame_GenreId;
        private TextBox textBoxGame_StudioId;
        private Button buttonGameUpdate;
        private Button buttonAddNewGame;
        private TextBox textBoxGenreName;
        private ListBox listBoxGenreInfo;
        private TextBox textBoxGenre_GameId;
        private TextBox textBoxStudio_GameId;
        private Button buttonGenreUpdate;
        private Button buttonAddNewGenre;
        private DateTimePicker dateTimePickerGameReleaseYear;
        private Panel panelFind1;
        private TextBox textBoxFindToGenre;
        private TextBox textBoxFindToStudioName;
        private TextBox textBoxFindToGameName;
        private ListBox listBoxFind1;
        private Button buttonFindToGameAndStudio;
        private Button buttonFindToYearRelease;
        private Button buttonFindToGenre;
        private Button buttonFindToStudio;
        private Button buttonFindToName;
        private TextBox textBoxFindToYear;
        private Label label1;
        private DateTimePicker dateTimePickerFindToYear;
        private Panel panelShowTop3;
        private Button buttonShowAllNeedInfo;
        private ListBox listBoxShowTop3;
        private Button buttonStudioDelete;
    }
}
