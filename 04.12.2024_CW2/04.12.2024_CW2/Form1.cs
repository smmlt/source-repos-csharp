using Microsoft.EntityFrameworkCore;

namespace _04._12._2024_CW2
{
    public partial class Form1 : Form
    {
        MyDatabaseContext db;
        public Form1()
        {
            InitializeComponent();

            MyDatabaseContext db = new MyDatabaseContext();


            try
            {
                db.Database.OpenConnection();
                label1.Text = "Connected to Database: Multimedia";
            }
            catch (Exception ex)
            {
                label1.Text = $"Error: {ex.Message}";
            }
            ShowAllGames();


            buttonAdd.Click += ButtonAdd_Click;
            buttonShow.Click += ButtonShow_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
            buttonDelete.Click += ButtonDelete_Click;

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            Game tempGame = (Game)listBox1.SelectedItem;
            int id = tempGame.id;
            var game = (from g in db.Games
                        where g.id == id
                        select g).FirstOrDefault();

            if (game == null) return;

            textBoxName.Text = game.Name;
            textBoxGenre.Text = game.Genre;
            dateTimePicker1.Value = game.YearOfPublication?.ToDateTime(new TimeOnly()) ?? DateTime.Now;
            textBoxRating.Text = game.Rating?.ToString();
            checkBox1.Checked = game.Selling ?? false;
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a game to delete.");
                return;
            }

            Game tempGame = (Game)listBox1.SelectedItem;
            int id = tempGame.id;
            var game = (from g in db.Games
                        where g.id == id
                        select g).FirstOrDefault();
            if (game == null)
            {
                MessageBox.Show("Game not found.");
                return;
            }

            db.Games.Remove(game);
            db.SaveChanges();
            ShowAllGames();

            MessageBox.Show("Game deleted successfully.");
        }

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a game to update.");
                return;
            }

            Game tempGame = (Game)listBox1.SelectedItem;
            int id = tempGame.id;

            var game = (from g in db.Games
                        where g.id == id
                        select g).FirstOrDefault();

            if (game == null)
            {
                MessageBox.Show("Game not found.");
                return;
            }

            game.Name = textBoxName.Text;
            game.Genre = string.IsNullOrWhiteSpace(textBoxGenre.Text) ? null : textBoxGenre.Text;
            game.YearOfPublication = DateOnly.FromDateTime(dateTimePicker1.Value);
            game.Rating = double.TryParse(textBoxRating.Text, out var rating) ? rating : null;
            game.Selling = checkBox1.Checked;

            db.SaveChanges();
            ShowAllGames();

            MessageBox.Show("Game updated successfully.");
        }

        private void ButtonShow_Click(object? sender, EventArgs e)
        {
            ShowAllGames();
        }

        private void ButtonAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name is required.");
                return;
            }

            var newGame = new Game
            {
                Name = textBoxName.Text,
                Genre = string.IsNullOrWhiteSpace(textBoxGenre.Text) ? null : textBoxGenre.Text,
                YearOfPublication = DateOnly.FromDateTime(dateTimePicker1.Value),
                Rating = double.TryParse(textBoxRating.Text, out var rating) ? rating : null,
                Selling = checkBox1.Checked
            };

            db.Games.Add(newGame);
            db.SaveChanges();
            ShowAllGames();

            MessageBox.Show("Game added successfully.");
        }


        private void ShowAllGames()
        {
            listBox1.Items.Clear();
            foreach (var game in db.Games)
            {
                listBox1.Items.Add(game);
            }
        }

        private void AppLicationExit()
        {
            db.Dispose();
        }
    }
}
