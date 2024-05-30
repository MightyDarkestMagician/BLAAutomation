using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BLAAutomation
{
    public partial class MainForm : MaterialForm
    {
        private Project _currentProject;
        private SQLiteConnection _connection;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitializeDatabase(); // Инициализация базы данных
            _connection = SQLiteDatabaseHelper.ConnectToDatabase();
            _currentProject = new Project(); // Инициализация пустого проекта
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

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            var newAntennaForm = new NewAntenna(_connection);
            if (newAntennaForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления антенны
                _currentProject.Antennas = AntennaPosition.GetAntennasForProject(_connection, _currentProject.Id);
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            var newDeviceForm = new NewDevice(_connection);
            if (newDeviceForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления устройства
                _currentProject.Devices = new List<Device>(Device.GetDevicesForProject(_connection, _currentProject.Id));
            }
        }

        private void buttonAddFuselage_Click(object sender, EventArgs e)
        {
            var newFuselageForm = new NewFuselage(_connection);
            if (newFuselageForm.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных проекта после добавления фюзеляжа
                _currentProject.Fuselages = new List<Fuselage>(Fuselage.GetFuselages(_connection));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить код, который должен выполниться при загрузке MainForm
        }
    }
}
