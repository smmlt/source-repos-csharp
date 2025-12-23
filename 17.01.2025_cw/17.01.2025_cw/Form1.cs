namespace _17._01._2025_cw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            buttonUploadResume.Click += ButtonUploadResume_Click;
            buttonCreateResume.Click += ButtonCreateResume_Click;
            buttonExperienced.Click += ButtonExperienced_Click;
            buttonInExperienced.Click += ButtonInExperienced_Click;
            buttonSearchByCity.Click += ButtonSearchByCity_Click;
            buttonMinSalary.Click += ButtonMinSalary_Click;
            buttonMaxSalary.Click += ButtonMaxSalary_Click;


        }

        private void ButtonMaxSalary_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonMinSalary_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonSearchByCity_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonInExperienced_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonExperienced_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonCreateResume_Click(object? sender, EventArgs e)
        {
            try
            {
                string folderPath = @"C:\Users\Bohdan\Desktop\Resume";
                string fullName = textBoxFullName.Text;

                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(textBoxAge.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPosition.Text) || string.IsNullOrWhiteSpace(textBoxCity.Text) ||
                    string.IsNullOrWhiteSpace(textBoxSalary.Text) || string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxYearsOfExperience.Text))
                {
                    MessageBox.Show("Please fill in all the fields.");
                    return;
                }

                string fileName = $"{fullName}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                Resume newResume = new Resume
                {
                    FullName = fullName,
                    Age = int.Parse(textBoxAge.Text),
                    Position = textBoxPosition.Text,
                    City = textBoxCity.Text,
                    DesiredSalary = decimal.Parse(textBoxSalary.Text),
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Email = textBoxEmail.Text,
                    YearsOfExperience = int.Parse(textBoxYearsOfExperience.Text)
                };


                try
                {
                    string[] lines = new string[]
                    {
                        newResume.FullName,
                        newResume.Age.ToString(),
                        newResume.Position,
                        newResume.City,
                        newResume.DesiredSalary.ToString(),
                        newResume.PhoneNumber,
                        newResume.Email,
                        newResume.YearsOfExperience.ToString()
                    };

                    File.WriteAllLines(filePath, lines);

                    MessageBox.Show($"Resume successfully saved as {fileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving resume: {ex.Message}");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        private void ButtonUploadResume_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
