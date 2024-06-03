using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace BLAAutomation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Инициализация базы данных
            DatabaseInitializer.InitializeDatabase();

            using (var connection = SQLiteDatabaseHelper.ConnectToDatabase())
            {
                // Добавление фюзеляжа
                Fuselage.AddFuselage(connection, "Fuselage1", 5, 1000);
                Fuselage.AddFuselage(connection, "Fuselage2", 6, 1200);
                Fuselage.AddFuselage(connection, "Fuselage3", 7, 1300);

                // Добавление проектов
                Project.AddProject(connection, "Проект 1", 1);
                Project.AddProject(connection, "Проект 2", 2);
                Project.AddProject(connection, "Проект 3", 3);

                // Добавление отсеков
                Compartment.AddCompartment(connection, 1, 10, 20, 30, 5, 4, 3, 200);
                Compartment.AddCompartment(connection, 2, 15, 25, 35, 6, 5, 4, 250);
                Compartment.AddCompartment(connection, 3, 20, 30, 40, 7, 6, 5, 300);

                // Добавление антенн
                Antenna.AddAntenna(connection, "Antenna1", 1.5, 0.2, 10, 2.4e9, 10, 20, 30, 1);
                Antenna.AddAntenna(connection, "Antenna2", 1.8, 0.25, 12, 2.5e9, 15, 25, 35, 2);
                Antenna.AddAntenna(connection, "Antenna3", 2.0, 0.3, 15, 2.6e9, 20, 30, 40, 3);

                // Добавление устройств
                Device.AddDevice(connection, "Device1", 500, 40, 300);
                Device.AddDevice(connection, "Device2", 550, 45, 350);
                Device.AddDevice(connection, "Device3", 600, 50, 400);

                // Добавление схемы размещения оборудования
                EquipmentPlacement.AddPlacement(connection, 1, 1, "Описание схемы 1", DateTime.Now);
                EquipmentPlacement.AddPlacement(connection, 2, 2, "Описание схемы 2", DateTime.Now);
                EquipmentPlacement.AddPlacement(connection, 3, 3, "Описание схемы 3", DateTime.Now);

                // Добавление посадочных мест
                PlacementPosition.AddPosition(connection, 1, 15, 25, 35, 400);
                PlacementPosition.AddPosition(connection, 2, 20, 30, 40, 500);
                PlacementPosition.AddPosition(connection, 3, 25, 35, 45, 600);

                // Получаем строку подключения
                string connectionString = SQLiteDatabaseHelper.GetConnectionString();

                // Запуск основного окна с передачей строки подключения
                Application.Run(new MainForm(connectionString));
            }

            Console.WriteLine("Database initialized and data added successfully.");
        }
    }
}
