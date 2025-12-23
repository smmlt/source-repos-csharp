using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp70
{
    public partial class Form1 : Form
    {
        DBManager dbManager;
        bool connected = false;
        string fileName = "";

        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            buttonScalar.Click += ButtonScalar_Click;

            buttonOpen.Click += ButtonOpen_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonLoad.Click += ButtonLoad_Click;

            //-----------------------------------
            //27.11.2024
            buttonQUERY.Click += ButtonQUERY_Click;
            //-----------------------------------
        }

        //-----------------------------------
        //27.11.2024
        private void ButtonQUERY_Click(object? sender, EventArgs e)
        {
            try
            {
                if (connected && !string.IsNullOrEmpty(textBoxQUERY.Text))
                {
                    string query = textBoxQUERY.Text;
                    string result = dbManager.ExecuteQuery(query);
                    richTextBox1.Text = result;
                }
                else
                {
                    MessageBox.Show($"ERROR: need connected to DB");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }
        //-----------------------------------

        private void ButtonLoad_Click(object? sender, EventArgs e)
        {
            if (connected) dbManager.LoadFiles();
            else
            {
                MessageBox.Show($"ERROR: need connected to DB");
            }
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            if (connected && !string.IsNullOrEmpty(fileName))
            {
                dbManager.SaveFile(fileName);
            }
            else
            {
                MessageBox.Show($"ERROR: need connected to DB");
            }
        }

        private void ButtonOpen_Click(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            richTextBox1.Text = ofd.InitialDirectory + ofd.FileName;
            fileName = ofd.InitialDirectory + ofd.FileName;
        }

        private void ButtonScalar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (connected && string.IsNullOrEmpty(textBoxScalar.Text))
                {
                    object result = dbManager.ExecuteScalar(textBoxScalar.Text);
                    richTextBox1.Text = textBoxScalar.Text + "\n" + result?.ToString();
                }
            }
            catch { }
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                string? tableName = listBox1.SelectedItem as string;
                if (connected)
                {
                    //--------------------------------------------------
                    // 05.12.2024
                    string count = $"SELECT COUNT(*) FROM {tableName}";
                    object result = dbManager.ExecuteScalar(count);
                    //--------------------------------------------------

                    SqlDataReader reader = dbManager.GetAllFromTable(tableName);
                                                //--------------------
                                                // 05.12.2024
                    label2.Text = $"{tableName}, (Records: {result})";
                                                //--------------------
                    ;
                    string tableData = "";

                    for (int i = 0; i < reader.FieldCount; i++)
                        tableData += reader.GetName(i) + "\t";
                    tableData += "\n\n";

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            tableData += reader.GetValue(i) + "\t";
                        tableData += "\n";
                    }

                    richTextBox1.Text = tableData;
                    reader.Close();
                }
            }
            catch { label2.Text = "ERROR"; }
        }

        // ----------------------------------------------------
        private void Button1_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!connected)
                {
                    dbManager = new DBManager(textBox1.Text);
                    FillListWithTables(dbManager.ShowTables());

                    connected = true;
                    label1.Text = "CONNECTED";
                    label1.ForeColor = Color.DarkGreen;
                }
                else label1.Text = "ALREADY CONNECTED";
            }
            catch
            {
                label1.ForeColor = Color.DarkRed;
                label1.Text = "ERROR";
            }
        }

        void FillListWithTables(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string? name = row[2].ToString();
                listBox1.Items.Add(name);
            }
        }

    }
}
