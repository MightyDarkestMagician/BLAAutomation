// MainForm.cs
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
        private SQLiteConnection _connection;
        private Project _currentProject;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitializeDatabase(); // Инициализация базы данных
            LoadProject(); // Загрузка проекта
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
            using (_connection = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                _connection.Open();
                _currentProject = Project.GetAllProjects(_connection).FirstOrDefault(); // Исправлено: Добавлен метод FirstOrDefault
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            var newDeviceForm = new NewDevice(_connection);
            if (newDeviceForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления устройства
                _currentProject.Devices = Device.GetDevicesForProject(_connection, _currentProject.Id).ToList(); // Исправлено: Использование ToList()
            }
        }

        private void buttonAddFuselage_Click(object sender, EventArgs e)
        {
            var newFuselageForm = new NewFuselage(_connection);
            if (newFuselageForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления фюзеляжа
                _currentProject.Fuselages = Fuselage.GetFuselages(_connection).ToList(); // Исправлено: Использование ToList()
            }
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            var newAntennaForm = new NewAntennaForm(_connection); // Исправлено: Использование правильного конструктора
            if (newAntennaForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления антенны
                _currentProject.Antennas = Antenna.GetAllAntennas(_connection)
                    .Select(a => new AntennaPosition(a.Id, a.CoordinateX, a.CoordinateY, a.CoordinateZ, a.CompartmentId)) // Добавляем координату Z
                    .ToList();
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            // Реализация метода для обработки события
        }
    }
}
