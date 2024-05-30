// Project.cs
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;

namespace BLAAutomation
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Compartment> Compartments { get; set; }
        public List<Position> Positions { get; set; }
        public List<AntennaPosition> Antennas { get; set; }
        public List<Device> Devices { get; set; } // Add Devices to Project
        public List<Fuselage> Fuselages { get; set; } // Add Fuselages to Project

        public Project()
        {
            Compartments = new List<Compartment>();
            Positions = new List<Position>();
            Antennas = new List<AntennaPosition>();
            Devices = new List<Device>(); // Initialize Devices
            Fuselages = new List<Fuselage>(); // Initialize Fuselages
        }

        public static void AddProject(SQLiteConnection connection, string name, int fuselageId)
        {
            string[] columns = { "Name", "Id_Fuselage" };
            string[] values = { name, fuselageId.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Project", columns, values);
        }

        public static List<Project> GetAllProjects(SQLiteConnection connection)
        {
            var projects = new List<Project>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Project");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var project = new Project
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString()
                };

                // Загрузка отсеков, позиций, антенн, устройств и фюзеляжей для проекта
                project.Compartments = Compartment.GetCompartmentsForProject(connection, project.Id);
                project.Positions = Position.GetPositionsForProject(connection, project.Id);
                project.Antennas = AntennaPosition.GetAntennasForProject(connection, project.Id);
                project.Devices = Device.GetDevicesForProject(connection, project.Id).ToList(); // Load devices
                project.Fuselages = Fuselage.GetFuselages(connection).ToList(); // Load fuselages

                projects.Add(project);
            }

            return projects;
        }
    }
}
