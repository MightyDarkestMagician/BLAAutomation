using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
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

            InitializeDatabase(); // Инициализация базы данных

            _currentProject = LoadProject(); // Инициализация проекта
        }

        private void InitializeDatabase()
        {
            try
            {
                DatabaseInitializer.InitializeDatabase();
                MessageBox.Show("Database initialized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DatabaseInitializer.InitializeDatabase();
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

                // Создаем экземпляр SchemeForm и отображаем на нем схему
                SchemeForm schemeForm = new SchemeForm();
                drawScheme.DisplayOnForm(schemeForm);
                schemeForm.Show();
            }
            else
            {
                MessageBox.Show("Проект не загружен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Project LoadProject()
        {
            // Пример данных проекта, замените на реальную логику загрузки
            Project project = new Project
            {
                Compartments = new List<Compartment>
        {
            new Compartment(1, 50, 50, 0, 100, 100, 100, 200),
            new Compartment(2, 150, 150, 0, 100, 100, 100, 200)
        },
                Positions = new List<Position>
        {
            new Position(1, 60, 60, 0, 1),
            new Position(2, 160, 160, 0, 2)
        },
                Antennas = new List<AntennaPosition>
        {
            new AntennaPosition(1, 70, 70, 0, 1),
            new AntennaPosition(2, 170, 170, 0, 2)
        }
            };

            Console.WriteLine($"Loaded project with {project.Compartments.Count} compartments, {project.Positions.Count} positions, and {project.Antennas.Count} antennas.");
            return project;
        }
    }
}
