using System;
using System.Data.SQLite;
using System.IO;

public class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        string databaseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\App_Data");
        string databasePath = Path.Combine(databaseDirectory, "blaautomation.db");

        if (!Directory.Exists(databaseDirectory))
        {
            Directory.CreateDirectory(databaseDirectory);
        }

        string connectionString = $"Data Source={databasePath};Version=3;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string[] tableCreationQueries = {
                @"
                CREATE TABLE IF NOT EXISTS Project (
                    ProjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectName TEXT NOT NULL,
                    FuselageModel TEXT NOT NULL,
                    FOREIGN KEY (FuselageModel) REFERENCES Fuselage(FuselageModel)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Fuselage (
                    FuselageModel TEXT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    TotalCompartments INTEGER,
                    Weight INTEGER
                );",
                @"
                CREATE TABLE IF NOT EXISTS Compartment (
                    CompartmentId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FuselageModel TEXT NOT NULL,
                    CoordinateX INTEGER,
                    CoordinateY INTEGER,
                    CoordinateZ INTEGER,
                    Carrying INTEGER,
                    Length INTEGER,
                    Width INTEGER,
                    Height INTEGER,
                    FOREIGN KEY (FuselageModel) REFERENCES Fuselage(FuselageModel)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Device (
                    DeviceModel TEXT PRIMARY KEY,
                    Power INTEGER,
                    NoiseImmunity INTEGER,
                    Weight INTEGER
                );",
                @"
                CREATE TABLE IF NOT EXISTS EquipmentPlacement (
                    PlacementId INTEGER PRIMARY KEY AUTOINCREMENT,
                    DeviceModel TEXT NOT NULL,
                    CompartmentId INTEGER NOT NULL,
                    Description TEXT,
                    CreationDate DATE,
                    FuselageModel TEXT NOT NULL,
                    FOREIGN KEY (DeviceModel) REFERENCES Device(DeviceModel),
                    FOREIGN KEY (CompartmentId) REFERENCES Compartment(CompartmentId),
                    FOREIGN KEY (FuselageModel) REFERENCES Fuselage(FuselageModel)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Antenna (
                    AntennaId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FrequencyRange INTEGER,
                    Gain INTEGER,
                    Power INTEGER,
                    Impedance INTEGER
                );",
                @"
                CREATE TABLE IF NOT EXISTS AntennaInFuselage (
                    AntennaId INTEGER NOT NULL,
                    FuselageModel TEXT NOT NULL,
                    AntennaModel TEXT,
                    Name TEXT,
                    CoordinateX INTEGER,
                    CoordinateY INTEGER,
                    CoordinateZ INTEGER,
                    PRIMARY KEY (AntennaId, FuselageModel),
                    FOREIGN KEY (FuselageModel) REFERENCES Fuselage(FuselageModel)
                );",
                @"
                CREATE TABLE IF NOT EXISTS PlacementPosition (
                    PositionId INTEGER PRIMARY KEY AUTOINCREMENT,
                    FuselageModel TEXT NOT NULL,
                    CoordinateX INTEGER,
                    CoordinateY INTEGER,
                    CoordinateZ INTEGER,
                    WeightLimit INTEGER,
                    FOREIGN KEY (FuselageModel) REFERENCES Fuselage(FuselageModel)
                );"
            };

            foreach (string query in tableCreationQueries)
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            // Проверка создания таблиц
            using (var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table';", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Table: " + reader["name"]);
                    }
                }
            }
        }
    }
}
