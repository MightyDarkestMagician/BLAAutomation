using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class MainForm : MaterialForm
    {
        private string _connectionString;
        private Project _currentProject;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            _connectionString = SQLiteDatabaseHelper.GetConnectionString(); // Изменение для получения строки подключения

            InitializeDatabase();           // Инициализация базы данных
            LoadProject();                  // Загрузка проекта
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

        private void LoadProject()
        {
            // Логика загрузки проекта
            using (var connection = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                connection.Open();
                _currentProject = Project.GetAllProjects(connection).FirstOrDefault(); // Исправлено: Добавлен метод FirstOrDefault
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            var newDeviceForm = new NewDevice(_connectionString); // Изменено на использование строки подключения
            if (newDeviceForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления устройства
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    _currentProject.Devices = Device.GetDevicesForProject(connection, _currentProject.Id).ToList(); // Исправлено: Использование ToList()
                }
            }
        }

        private void buttonAddFuselage_Click(object sender, EventArgs e)
        {
            var newFuselageForm = new NewFuselage(_connectionString); // Изменено на использование строки подключения
            if (newFuselageForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления фюзеляжа
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    _currentProject.Fuselages = Fuselage.GetFuselages(connection).ToList();    // Исправлено: Использование ToList()
                }
            }
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            var newAntennaForm = new NewAntennaForm(_connectionString); // Изменено на использование строки подключения
            if (newAntennaForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления антенны
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    _currentProject.Antennas = Antenna.GetAllAntennas(connection)
                        .Select(a => new AntennaPosition(a.Id, a.CoordinateX, a.CoordinateY, a.CoordinateZ, a.CompartmentId)) // Добавляем координату Z
                        .ToList();
                }
            }
        }

        private void buttonOpenAlgorithmForm_Click(object sender, EventArgs e)
        {
            var algorithmForm = new AlgorithmSettingsForm();
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

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void buttonOpenProjectForm_Click(object sender, EventArgs e)
        {
            var projectForm = new ProjectForm(_connectionString); // Передача строки подключения в ProjectForm
            projectForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
