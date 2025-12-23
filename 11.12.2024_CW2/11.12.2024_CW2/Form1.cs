using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _11._12._2024_CW2
{
    public partial class Form1 : Form
    {
        private MyDBContext db;
        private User currentUser;  // Для хранения текущего пользователя

        public Form1()
        {
            InitializeComponent();

            db = new MyDBContext(@"Server=localhost\SQLEXPRESS;
                                 Database=LoginUser;
                                 Trusted_Connection=True;
                                 Encrypt=False;
                                 TrustServerCertificate=True");

            //-----------------------------------
            panelLogIn.Enabled = true;
            panelInfo.Enabled = false;
            panelMusicGroup.Enabled = false;
            //-----------------------------------

            buttonLogIn.Click += ButtonLogIn_Click;
            buttonAddUserInfo.Click += ButtonAddUserInfo_Click;
            buttonUpdateUserInfo.Click += ButtonUpdateUserInfo_Click;
            buttonLogOut.Click += ButtonLogOut_Click;
            listBoxUser_info.SelectedIndexChanged += ListBoxUser_info_SelectedIndexChanged;

            buttonNewMusicGroup.Click += ButtonNewMusicGroup_Click;
            buttonUpdateMusicGr.Click += ButtonUpdateMusicGr_Click;
            buttonDeleteMusicGr.Click += ButtonDeleteMusicGr_Click;
            listBoxMusicGroup.SelectedIndexChanged += ListBoxMusicGroup_SelectedIndexChanged;
        }

        private void ButtonLogIn_Click(object? sender, EventArgs e)
        {
            try
            {
                string login = textBoxLogIn.Text;
                string password = textBoxPassword.Text;

                if (string.IsNullOrEmpty(login))
                {
                    MessageBox.Show("Please enter a login.");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password.");
                    return;
                }

                var logIn = db.Logins.FirstOrDefault(l => l.Login == login && l.Password == password);

                if (logIn != null)
                {
                    // Загружаем пользователя и его музыкальные группы
                    User user = db.Users.Include(u => u.MusicGroup).FirstOrDefault(u => u.LogInId == logIn.id);
                    if (user != null)
                    {
                        // Переходим на панель с информацией о пользователе
                        ShowUserProfile(user);
                    }
                    MessageBox.Show($"Welcome: {logIn.Login}");
                }
                else
                {
                    var newLogIn = new LogIn { Login = login, Password = password };
                    db.Logins.Add(newLogIn);
                    db.SaveChanges();

                    var newUser = new User
                    {
                        Name = login,
                        BirthDate = DateOnly.FromDateTime(DateTime.Now),
                        Country = "Unknown",
                        IsSubscription = false,
                        LogInId = newLogIn.id,
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // Отображаем информацию о новом пользователе
                    ShowUserProfile(newUser);
                    MessageBox.Show($"Welcome new user: {login}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void ButtonAddUserInfo_Click(object? sender, EventArgs e)
        {
            try
            {
                string userName = textBoxUserName.Text;
                string userCountry = textBoxUserCountry.Text;
                DateOnly birthDate = DateOnly.FromDateTime(dateTimePickerUser.Value);
                bool isSubscription = radioButtonYes.Checked;

                var logIn = db.Logins.FirstOrDefault(l => l.Login == textBoxLogIn.Text);

                if (logIn != null)
                {
                    var newUser = new User
                    {
                        Name = userName,
                        Country = userCountry,
                        BirthDate = birthDate,
                        IsSubscription = isSubscription,
                        LogInId = logIn.id
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // Отображаем профиль нового пользователя
                    ShowUserProfile(newUser);
                    MessageBox.Show("New user created successfully!");
                }
                else
                {
                    MessageBox.Show("LogIn does not exist. Please log in first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonUpdateUserInfo_Click(object? sender, EventArgs e)
        {
            try
            {
                if (currentUser != null)
                {
                    currentUser.Name = textBoxUserName.Text;
                    currentUser.Country = textBoxUserCountry.Text;
                    currentUser.BirthDate = DateOnly.FromDateTime(dateTimePickerUser.Value);
                    currentUser.IsSubscription = radioButtonYes.Checked;

                    db.Users.Update(currentUser);
                    db.SaveChanges();

                    ShowUserProfile(currentUser);
                    MessageBox.Show("User information updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please log in first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonLogOut_Click(object? sender, EventArgs e)
        {
            try
            {
                // Сброс всех данных и возврат на экран логина
                panelLogIn.Enabled = true;
                panelInfo.Enabled = false;
                panelMusicGroup.Enabled = false;

                currentUser = null;
                MessageBox.Show("You have been logged out.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonNewMusicGroup_Click(object? sender, EventArgs e)
        {
            try
            {
                string groupTitle = textBoxTitleMusicGr.Text; // Используем правильное поле для ввода

                if (string.IsNullOrEmpty(groupTitle))
                {
                    MessageBox.Show("Please enter a valid group title.");
                    return;
                }

                var newGroup = new MusicGroup
                {
                    Title = groupTitle
                };

                db.MusicGroups.Add(newGroup);
                db.SaveChanges();

                // Обновляем отображение музыкальных групп
                ShowMusicGroups();
                MessageBox.Show("New music group added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void ButtonUpdateMusicGr_Click(object? sender, EventArgs e)
        {
            try
            {
                var selectedGroup = listBoxMusicGroup.SelectedItem as MusicGroup;

                if (selectedGroup != null)
                {
                    selectedGroup.Title = textBoxTitleMusicGr.Text; // Поле для обновления названия группы
                    db.MusicGroups.Update(selectedGroup);
                    db.SaveChanges();

                    ShowMusicGroups();
                    MessageBox.Show("Music group updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a group to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonDeleteMusicGr_Click(object? sender, EventArgs e)
        {
            try
            {
                var selectedGroup = listBoxMusicGroup.SelectedItem as MusicGroup;

                if (selectedGroup != null)
                {
                    db.MusicGroups.Remove(selectedGroup);
                    db.SaveChanges();

                    ShowMusicGroups();
                    MessageBox.Show("Music group deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a group to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ListBoxMusicGroup_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                var selectedGroup = listBoxMusicGroup.SelectedItem as MusicGroup;

                if (selectedGroup != null)
                {
                    textBoxTitleMusicGr.Text = selectedGroup.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ListBoxUser_info_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                var selectedUserGroup = listBoxUser_info.SelectedItem as MusicGroup;

                if (selectedUserGroup != null)
                {
                    MessageBox.Show($"You selected: {selectedUserGroup.Title}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowUserProfile(User user)
        {
            panelLogIn.Enabled = false;  // Скрываем панель входа
            panelInfo.Enabled = true;    // Показываем панель с информацией о пользователе
            panelMusicGroup.Enabled = true;

            // Отображаем данные о пользователе
            textBoxUserName.Text = user.Name;
            textBoxUserCountry.Text = user.Country;
            dateTimePickerUser.Value = user.BirthDate.ToDateTime(TimeOnly.MinValue);
            radioButtonYes.Checked = user.IsSubscription ?? false;
            radioButtonNo.Checked = !(user.IsSubscription ?? false);

            // Отображаем музыкальные группы
            listBoxUser_info.Items.Clear();
            if (user.MusicGroup != null && user.MusicGroup.Any())
            {
                foreach (var group in user.MusicGroup)
                {
                    listBoxUser_info.Items.Add(group.Title);
                }
            }
        }


        private void ShowMusicGroups()
        {
            // Очищаем список перед добавлением новых данных
            listBoxMusicGroup.Items.Clear();

            // Загружаем музыкальные группы текущего пользователя
            var musicGroups = db.MusicGroups.Where(mg => mg.UserId == currentUser.Id).ToList();

            foreach (var group in musicGroups)
            {
                listBoxMusicGroup.Items.Add(group.Title); // Добавляем группу в listBox
            }
        }

    }
}
