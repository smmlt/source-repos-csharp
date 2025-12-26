using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MusicProfileApp.Models; 

namespace MusicProfileApp
{
    public partial class Form1 : Form
    {
        private Panel loginPanel, profilePanel;
        private Label lblLogin, lblPassword, lblName, lblBirthDate, lblCountry, lblNewsletter, lblBands;
        private TextBox txtLogin, txtPassword, txtName, txtCountry, txtNewBand;
        private DateTimePicker dtpBirthDate;
        private CheckBox chkNewsletter;
        private Button btnLogin, btnSave, btnAddBand;
        private ListBox lstBands;

        private int currentUserId = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "MusicProfileApp";
            this.Size = new System.Drawing.Size(450, 500);

            // --- LOGIN PANEL ---
            loginPanel = new Panel() { Dock = DockStyle.Fill };
            lblLogin = new Label() { Text = "Login:", Top = 30, Left = 30 };
            txtLogin = new TextBox() { Top = 50, Left = 30, Width = 200 };
            lblPassword = new Label() { Text = "Password:", Top = 90, Left = 30 };
            txtPassword = new TextBox() { Top = 110, Left = 30, Width = 200, PasswordChar = '*' };
            btnLogin = new Button() { Text = "Login", Top = 150, Left = 30 };
            btnLogin.Click += BtnLogin_Click;

            loginPanel.Controls.Add(lblLogin);
            loginPanel.Controls.Add(txtLogin);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(btnLogin);
            this.Controls.Add(loginPanel);

            // --- PROFILE PANEL ---
            profilePanel = new Panel() { Dock = DockStyle.Fill, Visible = false };

            lblName = new Label() { Text = "Name:", Top = 20, Left = 30 };
            txtName = new TextBox() { Top = 40, Left = 30, Width = 200 };

            lblBirthDate = new Label() { Text = "Birth Date:", Top = 70, Left = 30 };
            dtpBirthDate = new DateTimePicker() { Top = 90, Left = 30, Width = 200 };

            lblCountry = new Label() { Text = "Country:", Top = 120, Left = 30 };
            txtCountry = new TextBox() { Top = 140, Left = 30, Width = 200 };

            lblNewsletter = new Label() { Text = "Newsletter:", Top = 170, Left = 30 };
            chkNewsletter = new CheckBox() { Top = 190, Left = 30 };

            lblBands = new Label() { Text = "Favorite Bands:", Top = 220, Left = 30 };
            lstBands = new ListBox() { Top = 240, Left = 30, Width = 200, Height = 100 };
            txtNewBand = new TextBox() { Top = 350, Left = 30, Width = 150 };
            btnAddBand = new Button() { Text = "Add Band", Top = 350, Left = 190 };
            btnAddBand.Click += BtnAddBand_Click;

            btnSave = new Button() { Text = "Save", Top = 400, Left = 30 };
            btnSave.Click += BtnSave_Click;

            profilePanel.Controls.Add(lblName);
            profilePanel.Controls.Add(txtName);
            profilePanel.Controls.Add(lblBirthDate);
            profilePanel.Controls.Add(dtpBirthDate);
            profilePanel.Controls.Add(lblCountry);
            profilePanel.Controls.Add(txtCountry);
            profilePanel.Controls.Add(lblNewsletter);
            profilePanel.Controls.Add(chkNewsletter);
            profilePanel.Controls.Add(lblBands);
            profilePanel.Controls.Add(lstBands);
            profilePanel.Controls.Add(txtNewBand);
            profilePanel.Controls.Add(btnAddBand);
            profilePanel.Controls.Add(btnSave);

            this.Controls.Add(profilePanel);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            string login = txtLogin.Text;
            string password = txtPassword.Text;

            var user = db.Users.Include(u => u.FavoriteBands)
                               .FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                user = new User
                {
                    Login = login,
                    Password = password,
                    Name = "New User",
                    BirthDate = DateTime.Now.AddYears(-20),
                    Country = "Unknown",
                    Newsletter = false
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            currentUserId = user.Id;
            LoadProfile(user);
            loginPanel.Visible = false;
            profilePanel.Visible = true;
        }

        private void LoadProfile(User user)
        {
            txtName.Text = user.Name;
            dtpBirthDate.Value = user.BirthDate;
            txtCountry.Text = user.Country;
            chkNewsletter.Checked = user.Newsletter;

            lstBands.Items.Clear();
            foreach (var band in user.FavoriteBands)
                lstBands.Items.Add(band.BandName);
        }

        private void BtnAddBand_Click(object sender, EventArgs e)
        {
            string band = txtNewBand.Text.Trim();
            if (!string.IsNullOrEmpty(band))
            {
                lstBands.Items.Add(band);
                txtNewBand.Clear();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            var user = db.Users.Include(u => u.FavoriteBands)
                               .FirstOrDefault(u => u.Id == currentUserId);
            if (user == null) return;

            user.Name = txtName.Text;
            user.BirthDate = dtpBirthDate.Value;
            user.Country = txtCountry.Text;
            user.Newsletter = chkNewsletter.Checked;

            user.FavoriteBands.Clear();
            foreach (var item in lstBands.Items)
                user.FavoriteBands.Add(new FavoriteBand { BandName = item.ToString() });

            db.SaveChanges();
        }
    }
}
