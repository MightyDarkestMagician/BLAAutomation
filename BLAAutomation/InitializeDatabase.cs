using System;
using System.Data.SQLite;
using System.IO;

public class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        string databaseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        string databasePath = Path.Combine(databaseDirectory, "blaautomation.db");

        // Создаем директорию, если она не существует
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
                CREATE TABLE IF NOT EXISTS Fuselage (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );",
                @"
                CREATE TABLE IF NOT EXISTS Project (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Id_Fuselage INTEGER,
                    FOREIGN KEY (Id_Fuselage) REFERENCES Fuselage(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS Projects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );",
                @"
                CREATE TABLE IF NOT EXISTS CompartmentsInFuselage (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Fuselage INTEGER NOT NULL,
                    CoordinateX FLOAT,
                    CoordinateY FLOAT,
                    CoordinateZ FLOAT,
                    Length FLOAT,
                    Width FLOAT,
                    Height FLOAT,
                    Carrying FLOAT,
                    FOREIGN KEY (Id_Fuselage) REFERENCES Fuselage(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS AntennaInFuselage (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Fuselage INTEGER NOT NULL,
                    CoordinateX FLOAT,
                    CoordinateY FLOAT,
                    CoordinateZ FLOAT,
                    Amperage FLOAT,
                    Length FLOAT,
                    Frequency FLOAT,
                    Power FLOAT,
                    FOREIGN KEY (Id_Fuselage) REFERENCES Fuselage(Id)
                );",
                @"
                CREATE TABLE IF NOT EXISTS PositionsForPlacement (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Fuselage INTEGER NOT NULL,
                    CoordinateX FLOAT,
                    CoordinateY FLOAT,
                    CoordinateZ FLOAT,
                    CompartmentId INTEGER,
                    FOREIGN KEY (Id_Fuselage) REFERENCES Fuselage(Id),
                    FOREIGN KEY (CompartmentId) REFERENCES CompartmentsInFuselage(Id)
                );"
            };

            foreach (string query in tableCreationQueries)
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
