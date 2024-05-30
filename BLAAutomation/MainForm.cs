using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class MainForm : MaterialForm
    {
        private Project _currentProject;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _currentProject = LoadProject(); // Инициализация проекта
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SQLiteDatabaseHelper.InitializeDatabase();
        }

        private void проектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.Show();
        }

        private void данныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataForm dataForm = new DataForm();
            dataForm.Show();
        }

        private void алгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgorithmSettingsForm algorithmForm = new AlgorithmSettingsForm();
            algorithmForm.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void buttonOpenAlgorithmForm_Click(object sender, EventArgs e)
        {
            AlgorithmSettingsForm algorithmForm = new AlgorithmSettingsForm();
            algorithmForm.Show();
        }

        private void buttonDrawScheme_Click(object sender, EventArgs e)
        {
            if (_currentProject != null)
            {
                Bitmap image = new Bitmap(800, 600); // Размер изображения
                DrawScheme drawScheme = new DrawScheme(_currentProject, image);
                drawScheme.DrawProject();
                drawScheme.DisplayOnForm(this);
            }
            else
            {
                MessageBox.Show("Проект не загружен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Project LoadProject()
        {
            // Логика загрузки проекта
            // Верните объект Project с заполненными данными
            return new Project
            {
                // Инициализация свойств объекта Project
            };
        }
    }
}
