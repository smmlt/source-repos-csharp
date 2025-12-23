using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _13._12_27._12._2024_HW
{
    public partial class Form1 : Form
    {
        private MyDBContext db;

        public Form1()
        {
            InitializeComponent();

            db = new MyDBContext(@"Server=localhost\SQLEXPRESS;
                                 Database=GameStudio;
                                 Trusted_Connection=True;
                                 Encrypt=False;
                                 TrustServerCertificate=True");

            ShowAllStudio();
            ShowAllGames();
            ShowAllGenres();

            listBoxStudioInfo.SelectedIndexChanged += ListBoxStudioInfo_SelectedIndexChanged;
            buttonAddNewStudio.Click += ButtonAddNewStudio_Click;
            buttonStudioUpdate.Click += ButtonStudioUpdate_Click;

            listBoxGameInfo.SelectedIndexChanged += ListBoxGameInfo_SelectedIndexChanged;
            buttonAddNewGame.Click += ButtonAddNewGame_Click;
            buttonGameUpdate.Click += ButtonGameUpdate_Click;

            listBoxGenreInfo.SelectedIndexChanged += ListBoxGenreInfo_SelectedIndexChanged;
            buttonAddNewGenre.Click += ButtonAddNewGenre_Click;
            buttonGenreUpdate.Click += ButtonGenreUpdate_Click;

            //-----------------------------------------------------------------------
            // 4
            buttonFindToName.Click += ButtonFindToName_Click;
            buttonFindToStudio.Click += ButtonFindToStudio_Click;
            buttonFindToGenre.Click += ButtonFindToGenre_Click;
            buttonFindToYearRelease.Click += ButtonFindToYearRelease_Click;
            buttonFindToGameAndStudio.Click += ButtonFindToGameAndStudio_Click;
            // 4
            //-----------------------------------------------------------------------


            //-----------------------------------------------------------
            // Дедлайн: 01.01.2025
            // Задание 1

            buttonShowAllNeedInfo.Click += ButtonShowAllNeedInfo_Click;

            // Задание 1
            // Дедлайн: 01.01.2025
            //-----------------------------------------------------------



            //------------------------------------------------------------------
            // Дедлайн: 01.01.2025
            // Задание 3

            buttonStudioDelete.Click += ButtonStudioDelete_Click;

            // Задание 3
            // Дедлайн: 01.01.2025
            //------------------------------------------------------------------
        }



        //---------------------------------------------------------------------------------------------------------------------------------------
        // Дедлайн: 01.01.2025
        // Задание 1
        private void ButtonShowAllNeedInfo_Click(object? sender, EventArgs e)
        {
            try
            {
                listBoxShowTop3.Items.Clear();

                var topStudios = db.Studios
                    .Select(s => new { Studio = s, GameCount = s.Games.Count })
                    .OrderByDescending(s => s.GameCount)
                    .Take(3)
                    .ToList();

                listBoxShowTop3.Items.Add("Top-3 studios with the maximum number of games:");
                foreach (var studio in topStudios)
                {
                    listBoxShowTop3.Items.Add($"{studio.Studio.Name} - {studio.GameCount} games");
                }

                var maxStudio = topStudios.FirstOrDefault();
                if (maxStudio != null)
                {
                    listBoxShowTop3.Items.Add($"Studio with the maximum number of games: {maxStudio.Studio.Name} - {maxStudio.GameCount} games");
                }

                var topGenres = db.Genres
                    .Select(g => new { Genre = g, GameCount = g.Games.Count })
                    .OrderByDescending(g => g.GameCount)
                    .Take(3)
                    .ToList();

                listBoxShowTop3.Items.Add("\nTop-3 most popular genres:");
                foreach (var genre in topGenres)
                {
                    listBoxShowTop3.Items.Add($"{genre.Genre.Name} - {genre.GameCount} games");
                }

                var maxGenre = topGenres.FirstOrDefault();
                if (maxGenre != null)
                {
                    listBoxShowTop3.Items.Add($"Most popular genre: {maxGenre.Genre.Name} - {maxGenre.GameCount} games");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // Задание 1
        // Дедлайн: 01.01.2025
        //---------------------------------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------
        // 4
        private void ButtonFindToGameAndStudio_Click(object? sender, EventArgs e)
        {
            try
            {
                string gameName = textBoxFindToGameName.Text.Trim();
                string studioName = textBoxFindToStudioName.Text.Trim();

                if (string.IsNullOrEmpty(gameName) && string.IsNullOrEmpty(studioName))
                {
                    MessageBox.Show("Please enter at least one search criterion (game or studio).");
                    return;
                }
                var games = db.Games.Include(g => g.Studio).ToList();

                if (!string.IsNullOrEmpty(gameName))
                {
                    games = games.Where(g => g.Title.Contains(gameName)).ToList();
                }

                if (!string.IsNullOrEmpty(studioName))
                {
                    games = games.Where(g => g.Studio.Name.Contains(studioName)).ToList();
                }

                listBoxFind1.Items.Clear();
                foreach (var game in games)
                {
                    listBoxFind1.Items.Add(game);
                }
                if (games.Count == 0)
                {
                    MessageBox.Show("No games found with the specified criteria.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ButtonFindToYearRelease_Click(object? sender, EventArgs e)
        {
            try
            {
                string yearText = textBoxFindToYear.Text.Trim();
                if (string.IsNullOrEmpty(yearText) || !int.TryParse(yearText, out int year))
                {
                    MessageBox.Show("Please enter a valid year.");
                    return;
                }

                var games = db.Games
                              .Where(g => g.ReleaseYear.HasValue && g.ReleaseYear.Value.Year == year)
                              .ToList();

                listBoxFind1.Items.Clear();
                foreach (var game in games)
                {
                    listBoxFind1.Items.Add(game);
                }
                if (games.Count == 0)
                {
                    MessageBox.Show("No games found from that year.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ButtonFindToGenre_Click(object? sender, EventArgs e)
        {
            try
            {
                string genreName = textBoxFindToGenre.Text.Trim();

                if (string.IsNullOrEmpty(genreName))
                {
                    MessageBox.Show("Please enter a genre to search.");
                    return;
                }
                var games = db.Games.Include(g => g.Genre)
                                    .Where(g => g.Genre.Name.Contains(genreName))
                                    .ToList();

                listBoxFind1.Items.Clear();
                foreach (var game in games)
                {
                    listBoxFind1.Items.Add(game);
                }

                if (games.Count == 0)
                {
                    MessageBox.Show("No games found with that genre.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ButtonFindToStudio_Click(object? sender, EventArgs e)
        {
            try
            {
                string studioName = textBoxFindToStudioName.Text.Trim();
                if (string.IsNullOrEmpty(studioName))
                {
                    MessageBox.Show("Please enter a studio name to search.");
                    return;
                }
                var studios = db.Studios.Include(s => s.Games)
                                         .Where(s => s.Name.Contains(studioName))
                                         .ToList();

                listBoxFind1.Items.Clear();
                if (studios.Count == 0)
                {
                    MessageBox.Show("No studios found with that name.");
                    return;
                }
                foreach (var studio in studios)
                {
                    foreach (var game in studio.Games)
                    {
                        listBoxFind1.Items.Add(game);
                    }
                }

                if (listBoxFind1.Items.Count == 0)
                {
                    MessageBox.Show("No games found for this studio.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ButtonFindToName_Click(object? sender, EventArgs e)
        {
            try
            {
                string gameName = textBoxFindToGameName.Text.Trim();
                if (string.IsNullOrEmpty(gameName))
                {
                    MessageBox.Show("Please enter a game name to search.");
                    return;
                }

                var games = db.Games.Where(g => g.Title.Contains(gameName)).ToList();

                listBoxFind1.Items.Clear();
                foreach (var game in games)
                {
                    listBoxFind1.Items.Add(game);
                }

                if (games.Count == 0)
                {
                    MessageBox.Show("No games found with that name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // 4
        //-----------------------------------------------------------------------

        private void ButtonGenreUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxGenreInfo.SelectedItem == null)
                {
                    MessageBox.Show("Select a genre to update.");
                    return;
                }

                Genre tempGenre = (Genre)listBoxGenreInfo.SelectedItem;
                int id = tempGenre.Id;

                var genre = (from g in db.Genres
                             where g.Id == id
                             select g).FirstOrDefault();

                if (genre == null)
                {
                    MessageBox.Show("Genre not found.");
                    return;
                }

                genre.Name = textBoxGenreName.Text;

                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Genre updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddNewGenre_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxGenreName.Text))
                {
                    MessageBox.Show("Genre name is required.");
                    return;
                }

                var newGenre = new Genre
                {
                    Name = textBoxGenreName.Text
                };

                db.Genres.Add(newGenre);
                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Genre added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxGenreInfo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxGenreInfo.SelectedItem == null) return;

                Genre selectedGenre = (Genre)listBoxGenreInfo.SelectedItem;

                textBoxGenreName.Text = selectedGenre.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonGameUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxGameInfo.SelectedItem == null)
                {
                    MessageBox.Show("Select a game to update.");
                    return;
                }

                Game selectedGame = (Game)listBoxGameInfo.SelectedItem;
                int id = selectedGame.Id;

                var game = db.Games.Include(g => g.Studio).Include(g => g.Genre)
                                    .FirstOrDefault(g => g.Id == id);

                if (game == null)
                {
                    MessageBox.Show("Game not found.");
                    return;
                }

                game.Title = textBoxGameTitle.Text;
                game.ReleaseYear = dateTimePickerGameReleaseYear.Value != null
                                  ? DateOnly.FromDateTime(dateTimePickerGameReleaseYear.Value)
                                  : new DateOnly(2000, 1, 1);

                if (int.TryParse(textBoxGame_StudioId.Text, out int studioId))
                {
                    var studio = db.Studios.Find(studioId);
                    if (studio != null)
                    {
                        game.StudioId = studioId;
                    }
                    else
                    {
                        MessageBox.Show("Studio with this ID does not exist.");
                        return;
                    }
                }

                if (int.TryParse(textBoxGame_GenreId.Text, out int genreId))
                {
                    var genre = db.Genres.Find(genreId);
                    if (genre != null)
                    {
                        game.GenreId = genreId;
                    }
                    else
                    {
                        MessageBox.Show("Genre with this ID does not exist.");
                        return;
                    }
                }

                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Game updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddNewGame_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxGameTitle.Text))
                {
                    MessageBox.Show("Game title is required.");
                    return;
                }

                if (!int.TryParse(textBoxGame_StudioId.Text, out int studioId) ||
                    !int.TryParse(textBoxGame_GenreId.Text, out int genreId))
                {
                    MessageBox.Show("Invalid Studio or Genre ID format.");
                    return;
                }

                var studio = db.Studios.Find(studioId);
                if (studio == null)
                {
                    MessageBox.Show("Studio with this ID does not exist.");
                    return;
                }

                var genre = db.Genres.Find(genreId);
                if (genre == null)
                {
                    MessageBox.Show("Genre with this ID does not exist.");
                    return;
                }

                var newGame = new Game
                {
                    Title = textBoxGameTitle.Text,
                    ReleaseYear = dateTimePickerGameReleaseYear.Value != null
                                  ? DateOnly.FromDateTime(dateTimePickerGameReleaseYear.Value)
                                  : new DateOnly(2000, 1, 1),
                    StudioId = studioId,
                    GenreId = genreId,
                    Studio = studio,
                    Genre = genre
                };

                db.Games.Add(newGame);
                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Game added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxGameInfo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxGameInfo.SelectedItem == null)
                {
                    MessageBox.Show("No game selected.");
                    return;
                }

                Game selectedGame = (Game)listBoxGameInfo.SelectedItem;

                textBoxGameTitle.Text = selectedGame.Title;
                dateTimePickerGameReleaseYear.Value = selectedGame.ReleaseYear?.ToDateTime(new TimeOnly()) ?? DateTime.Now;
                textBoxGame_StudioId.Text = selectedGame.StudioId.ToString();
                textBoxGame_GenreId.Text = selectedGame.GenreId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //------------------------------------------------------------------
        // Дедлайн: 01.01.2025
        // Задание 3
        private void ButtonStudioDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxStudioInfo.SelectedItem == null)
                {
                    MessageBox.Show("Please select a studio to delete.");
                    return;
                }

                Studio selectedStudio = (Studio)listBoxStudioInfo.SelectedItem;


                // красота
                var confirmation = MessageBox.Show(
                    $"Are you sure you want to delete the studio '{selectedStudio.Name}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmation == DialogResult.No)
                {
                    return;
                }

                db.Studios.Remove(selectedStudio);
                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Studio deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // Задание 3
        // Дедлайн: 01.01.2025
        //------------------------------------------------------------------

        private void ButtonStudioUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxStudioInfo.SelectedItem == null)
                {
                    MessageBox.Show("Select a studio to update.");
                    return;
                }

                Studio tempStudio = (Studio)listBoxStudioInfo.SelectedItem;
                int id = tempStudio.Id;

                var studio = (from s in db.Studios
                              where s.Id == id
                              select s).Include(s => s.Games).FirstOrDefault();

                if (studio == null)
                {
                    MessageBox.Show("Studio not found.");
                    return;
                }

                studio.Name = textBoxStudioName.Text;
                studio.Country = string.IsNullOrWhiteSpace(textBoxStudioCountry.Text) ? null : textBoxStudioCountry.Text;

                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Studio updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddNewStudio_Click(object? sender, EventArgs e)
        {
            try
            {
                string studioName = textBoxStudioName.Text.Trim();

                if (string.IsNullOrWhiteSpace(studioName))
                {
                    MessageBox.Show("Studio name is required.");
                    return;
                }

                //------------------------------------------------------------------
                // Дедлайн: 01.01.2025
                // Задание 3
                bool studioExists = db.Studios.Any(s => s.Name == studioName);
                if (studioExists)
                {
                    MessageBox.Show("A studio with this name already exists.");
                    return;
                }

                // Задание 3
                // Дедлайн: 01.01.2025
                //------------------------------------------------------------------


                var newStudio = new Studio
                {
                    Name = studioName,
                    Country = string.IsNullOrWhiteSpace(textBoxStudioCountry.Text) ? null : textBoxStudioCountry.Text
                };

                db.Studios.Add(newStudio);
                db.SaveChanges();
                ShowAllInfo();

                MessageBox.Show("Studio added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxStudioInfo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (listBoxStudioInfo.SelectedItem == null) return;

                Studio selectedStudio = (Studio)listBoxStudioInfo.SelectedItem;

                textBoxStudioName.Text = selectedStudio.Name;
                textBoxStudioCountry.Text = selectedStudio.Country;

                textBoxStudio_GameId.Text = string.Join(", ", selectedStudio.Games.Select(g => g.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAllInfo()
        {
            ShowAllStudio();
            ShowAllGames();
            ShowAllGenres();
        }

        private void ShowAllStudio()
        {
            try
            {
                listBoxStudioInfo.Items.Clear();
                foreach (var studio in db.Studios)
                {
                    listBoxStudioInfo.Items.Add(studio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAllGames()
        {
            try
            {
                listBoxGameInfo.Items.Clear();
                foreach (var game in db.Games.Include(g => g.Studio).Include(g => g.Genre))
                {
                    listBoxGameInfo.Items.Add(game);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAllGenres()
        {
            try
            {
                listBoxGenreInfo.Items.Clear();
                foreach (var genre in db.Genres)
                {
                    listBoxGenreInfo.Items.Add(genre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
