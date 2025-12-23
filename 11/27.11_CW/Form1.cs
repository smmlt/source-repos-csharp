namespace _27._11_CW
{
    public partial class Form1 : Form
    {
        DBManager dBManager;
        bool connected = false;

        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click; 
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!connected)
                {
                    dBManager = new DBManager(textBox1.Text);
                    connected = true;
                    label1.Text = "CONNECTED";
                    label1.ForeColor = Color.DarkGreen;
                }
                else { label1.Text = "ALREADY CONNECTED"; }
                
            }
            catch 
            {
                label1.ForeColor = Color.DarkRed;
                label1.Text = "ERROR"; 
            }
        }
    }
}
