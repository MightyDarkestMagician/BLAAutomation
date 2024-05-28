using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class DataForm : MaterialForm
    {
        public DataForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            LoadCompartments();
            LoadDevices();
            LoadAntennas();
        }

        private void LoadCompartments()
        {
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "SELECT * FROM Compartments";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewCompartments.DataSource = dataTable;
            }
        }

        private void LoadDevices()
        {
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "SELECT * FROM Devices";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewDevices.DataSource = dataTable;
            }
        }

        private void LoadAntennas()
        {
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "SELECT * FROM Antennas";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAntennas.DataSource = dataTable;
            }
        }

        private void buttonAddCompartment_Click(object sender, EventArgs e)
        {
            // Логика для добавления нового отсека
            string name = Prompt.ShowDialog("Введите имя отсека:", "Добавить Отсек");
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "INSERT INTO Compartments (Name) VALUES (@name)";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            LoadCompartments();
        }

        private void buttonDeleteCompartment_Click(object sender, EventArgs e)
        {
            // Логика для удаления выбранного отсека
            if (dataGridViewCompartments.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewCompartments.SelectedRows[0].Cells["Id"].Value);
                using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
                {
                    string sql = "DELETE FROM Compartments WHERE Id = @id";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                LoadCompartments();
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            // Логика для добавления нового устройства
            string name = Prompt.ShowDialog("Введите имя устройства:", "Добавить Устройство");
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "INSERT INTO Devices (Name) VALUES (@name)";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            LoadDevices();
        }

        private void buttonDeleteDevice_Click(object sender, EventArgs e)
        {
            // Логика для удаления выбранного устройства
            if (dataGridViewDevices.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewDevices.SelectedRows[0].Cells["Id"].Value);
                using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
                {
                    string sql = "DELETE FROM Devices WHERE Id = @id";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                LoadDevices();
            }
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            // Логика для добавления новой антенны
            string name = Prompt.ShowDialog("Введите имя антенны:", "Добавить Антенну");
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "INSERT INTO Antennas (Name) VALUES (@name)";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            LoadAntennas();
        }

        private void buttonDeleteAntenna_Click(object sender, EventArgs e)
        {
            // Логика для удаления выбранной антенны
            if (dataGridViewAntennas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewAntennas.SelectedRows[0].Cells["Id"].Value);
                using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
                {
                    string sql = "DELETE FROM Antennas WHERE Id = @id";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                LoadAntennas();
            }
        }
    }

    // Вспомогательный класс для отображения диалогового окна ввода
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }
}
