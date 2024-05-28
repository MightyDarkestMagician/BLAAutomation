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
        public ProjectForm()
        {
            InitializeComponent();
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
                using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
                {
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
                using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
                {
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
            using (var conn = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                string sql = "SELECT * FROM Projects";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewProjects.DataSource = dataTable;
            }
        }
    }
}
