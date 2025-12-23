namespace _20._12._2024_HW
{
    public partial class Form1 : Form
    {
        private MyDBContext db;
        public Form1()
        {
            InitializeComponent();

            db = new MyDBContext(@"Server=localhost\SQLEXPRESS;
                                             Database=LeagueManagerDB;
                                             Trusted_Connection=True;
                                             Encrypt=False;
                                             TrustServerCertificate=True");

            buttonAdd.Click += ButtonAdd_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonShowLg.Click += ButtonShowLg_Click;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            buttonAddPl.Click += ButtonAddPl_Click;
            buttonUpdatePl.Click += ButtonUpdatePl_Click;
            buttonDeletePl.Click += ButtonDeletePl_Click;
            buttonShowPl.Click += ButtonShowPl_Click;

            buttonSearch.Click += ButtonSearch_Click;
        }


        private void ButtonSearch_Click(object? sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string nameSearch = textBoxNameSearch.Text.Trim();
            string positionSearch = textBoxPosSearch.Text.Trim();

            bool foundPlayer = false;

            foreach (var player in db.Players)
            {
                bool PlName = string.IsNullOrEmpty(nameSearch) || player.Name.Contains(nameSearch);
                bool PlPosition = string.IsNullOrEmpty(positionSearch) || player.Position.Contains(positionSearch);

                if (PlName && PlPosition)
                {
                    listBox3.Items.Add(player);
                    foundPlayer = true;
                }
            }

            if (!foundPlayer)
            {
                listBox3.Items.Add("Not found");
            }
        }


        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            League selectedLeague = (League)listBox1.SelectedItem;
            int leagueId = selectedLeague.Id;

            var league = (from l in db.Leagues
                          where l.Id == leagueId
                          select l).FirstOrDefault();

            if (league == null) return;

            textBoxLeagueTitle.Text = league.Name;
            textBoxDescLeague.Text = league.Description;
        }

        private void ButtonShowPl_Click(object? sender, EventArgs e)
        {
            ShowAllPlayers();
        }

        private void ButtonShowLg_Click(object? sender, EventArgs e)
        {
            ShowAllLeagues();
        }

        private void ButtonDeletePl_Click(object? sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Select a player to delete.");
                return;
            }

            Player selectedPlayer = (Player)listBox2.SelectedItem;
            int id = selectedPlayer.Id;

            var player = db.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                MessageBox.Show("Player not found.");
                return;
            }

            db.Players.Remove(player);
            db.SaveChanges();

            ShowAllPlayers();

            MessageBox.Show("Player deleted successfully.");
        }

        private void ButtonUpdatePl_Click(object? sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Select a player to update.");
                return;
            }

            Player selectedPlayer = (Player)listBox2.SelectedItem;
            int id = selectedPlayer.Id;

            var player = db.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                MessageBox.Show("Player not found.");
                return;
            }

            player.Name = textBoxName.Text;
            player.Age = int.Parse(textBoxAge.Text);
            player.Position = string.IsNullOrWhiteSpace(textBoxPosition.Text) ? null : textBoxPosition.Text;
            player.LeagueId = int.Parse(textBoxLeague.Text);

            db.SaveChanges();
            ShowAllPlayers();

            MessageBox.Show("Player updated successfully.");
        }

        private void ButtonAddPl_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxAge.Text))
            {
                MessageBox.Show("Name and Age are required.");
                return;
            }

            if (int.TryParse(textBoxLeague.Text, out int leagueId))
            {
                var league = db.Leagues.FirstOrDefault(l => l.Id == leagueId);
                if (league == null)
                {
                    MessageBox.Show("League not found.");
                    return;
                }

                var newPlayer = new Player
                {
                    Name = textBoxName.Text,
                    Age = int.Parse(textBoxAge.Text),
                    Position = string.IsNullOrWhiteSpace(textBoxPosition.Text) ? null : textBoxPosition.Text,
                    LeagueId = leagueId
                };

                db.Players.Add(newPlayer);
                db.SaveChanges();

                ShowAllPlayers();
                MessageBox.Show("Player added successfully.");
            }
            else
            {
                MessageBox.Show("Invalid League ID.");
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a league to delete.");
                return;
            }

            League selectedLeague = (League)listBox1.SelectedItem;
            int id = selectedLeague.Id;

            var league = db.Leagues.FirstOrDefault(l => l.Id == id);
            if (league == null)
            {
                MessageBox.Show("League not found.");
                return;
            }

            db.Leagues.Remove(league);
            db.SaveChanges();
            ShowAllLeagues();

            MessageBox.Show("League deleted successfully.");
        }

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a league to update.");
                return;
            }

            League selectedLeague = (League)listBox1.SelectedItem;
            int id = selectedLeague.Id;

            var league = db.Leagues.FirstOrDefault(l => l.Id == id);
            if (league == null)
            {
                MessageBox.Show("League not found.");
                return;
            }

            league.Name = textBoxLeagueTitle.Text;
            league.Description = string.IsNullOrWhiteSpace(textBoxDescLeague.Text) ? null : textBoxDescLeague.Text;
            
            db.SaveChanges();
            ShowAllLeagues();

            MessageBox.Show("League updated successfully.");
        }

        private void ButtonAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLeagueTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return;
            }

            var newLeague = new League
            {
                Name = textBoxLeagueTitle.Text,
                Description = string.IsNullOrWhiteSpace(textBoxDescLeague.Text) ? null : textBoxDescLeague.Text
            };

            db.Leagues.Add(newLeague);
            db.SaveChanges();

            ShowAllLeagues();

            MessageBox.Show("League added successfully.");
        }

        private void ShowAllLeagues()
        {
            listBox1.Items.Clear();
            foreach (var league in db.Leagues)
            {
                listBox1.Items.Add(league);
            }
        }
        private void ShowAllPlayers()
        {
            listBox2.Items.Clear();
            foreach (var player in db.Players)
            {
                listBox2.Items.Add(player);
            }
        }
    }
}
