using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class ViewProjects : MaterialForm
    {
        private string _connectionString;

        public ViewProjects(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void ViewProjects_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var projects = Project.GetAllProjects(connection);
                    foreach (var project in projects)
                    {
                        listBoxProjects.Items.Add(project.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке проектов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
