using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22._01._2025_hw
{
    public partial class Form1 : Form
    {
        private string filePath;

        public Form1()
        {
            InitializeComponent();
            buttonFilePath.Click += ButtonFilePath_Click;
            buttonFind.Click += ButtonFind_Click;
        }

        private async void ButtonFind_Click(object sender, EventArgs e)
        {
            string wordToFind = textBoxWordToFind.Text.Trim();
            if (string.IsNullOrEmpty(wordToFind))
            {
                MessageBox.Show("Please enter a word to search.");
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            int count = await FindWordInFileAsync(wordToFind, filePath);
            labelResult.Text = $"The word '{wordToFind}' was found {count} times.";
        }
        private void ButtonFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }

        private async Task<int> FindWordInFileAsync(string wordToFind, string filePath)
        {
            int count = 0;

            try
            {
                string[] lines = await File.ReadAllLinesAsync(filePath);

                foreach (string line in lines)
                {
                    count += CountOccurrences(line, wordToFind);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return count;
        }

        private int CountOccurrences(string line, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }
    }
}
