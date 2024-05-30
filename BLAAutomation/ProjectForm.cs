using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class ProjectForm : MaterialForm
    {
        private string _connectionString;

        public ProjectForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void buttonCreateProject_Click(object sender, EventArgs e)
        {
            // Логика для создания нового проекта
            string projectName = Prompt.ShowDialog("Введите название проекта:", "Создать проект");
            if (!string.IsNullOrEmpty(projectName))
            {
                // Добавление проекта в базу данных
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Projects (Name) VALUES (@name)";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.Parameters.AddWithValue("@name", projectName);
                    command.ExecuteNonQuery();
                }
                LoadProjects();
            }
        }

        private void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            // Логика для удаления выбранного проекта
            if (dataGridViewProjects.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewProjects.SelectedRows[0].Cells["Id"].Value);
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Projects WHERE Id = @id";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                LoadProjects();
            }
        }

        private void LoadProjects()
        {
            // Логика для загрузки проектов из базы данных
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Projects";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewProjects.DataSource = dataTable;
            }
        }

        // Метод для отображения диалогового окна ввода
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
}
