using System.Runtime.Intrinsics.X86;

namespace _04._01._2025_HW
{
    public partial class Form1 : Form
    {
        private int[] numbers;
        private int max;
        private int min;
        private double average;
        private string filePath = "C:\\Users\\Bohdan\\source\\repos\\04.01.2025_HW\\04.01.2025_HW\\value.txt";

        public Form1()
        {
            InitializeComponent();

            buttonStart.Click += ButtonStart_Click;
            buttonToFile.Click += ButtonToFile_Click;
        }

        private async void ButtonStart_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Clear();
            labelMax.Text = "Max value:";
            labelMin.Text = "Min value:";
            labelAvg.Text = "Avg value:";
            buttonToFile.Text = "Write to file";

            Thread generateThread = new Thread(RandomNum);
            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread avgThread = new Thread(FindAverage);

            generateThread.Start();
            generateThread.Join();

            maxThread.Start();
            minThread.Start();
            avgThread.Start();

            maxThread.Join();
            minThread.Join();
            avgThread.Join();

            labelMax.Text = $"Max: {max}";
            labelMin.Text = $"Min: {min}";
            labelAvg.Text = $"Average: {average}";
        }


        private void ButtonToFile_Click(object? sender, EventArgs e)
        {
            WriteToFile();
        }

        private void RandomNum()
        {
            Random random = new Random();
            numbers = new int[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
                Invoke(new Action(() => listBox1.Items.Add(numbers[i])));
            }
        }
        private void FindMax()
        {
            max = numbers.Max();
        }

        private void FindMin()
        {
            min = numbers.Min();
        }

        private void FindAverage()
        {
            average = numbers.Average();
        }

        private void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Generated Numbers:");
                foreach (var number in numbers)
                {
                    sw.WriteLine(number);
                }
                sw.WriteLine();
                sw.WriteLine($"Maximum: {max}");
                sw.WriteLine($"Minimum: {min}");
                sw.WriteLine($"Average: {average}");
            }
            Invoke(new Action(() =>
            {
                listBox1.Items.Add("Results written to file.");
                buttonToFile.Text = "Written";
            }));
        }

        
    }
}
