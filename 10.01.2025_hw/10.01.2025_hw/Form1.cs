namespace _10._01._2025_hw
{
    public partial class Form1 : Form
    {
        public static Semaphore Semaphore { get; set; } = new Semaphore(0, 5);
        List<Horse> Horses = new();

        public Form1()
        {
            InitializeComponent();

            Horses.Add(new Horse(Horse1));
            Horses.Add(new Horse(Horse2));
            Horses.Add(new Horse(Horse3));
            Horses.Add(new Horse(Horse4));

            buttonStart.Click += ButtonStart_Click;
        }

        private void ButtonStart_Click(object? sender, EventArgs e)
        {

            try
            {
                Horse.ResetRank();
                buttonStart.Enabled = false;

                foreach (var horse in Horses)
                {
                    horse.Button.Location = new Point(panel2.Location.X, horse.Button.Location.Y);
                    Task.Run(() => StartHorse(Horses.IndexOf(horse)));
                }
                Task.Run(IsFinish);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void StartHorse(int horseIndex)
        {
            try
            {
                Horse horse = Horses[horseIndex];
                while (horse.Button.Location.X < panel1.Location.X)
                {
                    Invoke(new Action(() =>
                    {
                        horse.Button.Location = new Point(horse.Button.Location.X + horse.Speed, horse.Button.Location.Y);
                    }));
                    Thread.Sleep(100);
                }

                Invoke(new Action(() =>
                {
                    horse.Button.Enabled = false;
                }));
                horse.SetRank();
                Semaphore.Release();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void IsFinish()
        {
            try
            {
                for (int i = 0; i < Horses.Count; i++)
                {
                    Semaphore.WaitOne();
                }

                string message = "Result:\n";
                foreach (var horse in Horses.OrderBy(h => h.Rank))
                {
                    message += $"{horse.Button.Name}, Rank: {horse.Rank}\n ";
                }

                Invoke(new Action(() => MessageBox.Show(message)));
                Invoke(new Action(() => buttonStart.Enabled = true));
            }
            catch ( Exception ex ) { Console.WriteLine(ex.Message); }
            
        }
    }

    internal class Horse
    {
        public static int CurrentRank = 1;
        public int Rank { get; set; }
        public Button Button { get; set; }
        public int Speed => new Random().Next(1, 20);

        public Horse(Button horse)
        {
            Rank = 0;
            Button = horse;
        }

        public void SetRank()
        {
            Rank = CurrentRank++;
        }

        public static void ResetRank()
        {
            CurrentRank = 1;
        }
    }
}
