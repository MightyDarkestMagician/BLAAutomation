using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FuselageId { get; set; }
        public List<Compartment> Compartments { get; set; }
        public List<Position> Positions { get; set; }
        public List<AntennaPosition> Antennas { get; set; }
        public List<Device> Devices { get; set; }

        public Project()
        {
            Compartments = new List<Compartment>();
            Positions = new List<Position>();
            Antennas = new List<AntennaPosition>();
            Devices = new List<Device>();
        }

        public static void AddProject(SQLiteConnection connection, string name, int fuselageId)
        {
            string[] columns = { "Name", "FuselageId" };
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
                    Name = row["Name"].ToString(),
                    FuselageId = int.Parse(row["FuselageId"].ToString())
                };

                project.Compartments = Compartment.GetCompartmentsForProject(connection, project.Id);
                project.Positions = Position.GetPositionsForProject(connection, project.Id);
                project.Antennas = AntennaPosition.GetAntennasForProject(connection, project.Id);
                project.Devices = Device.GetDevicesForProject(connection, project.Id);

                projects.Add(project);
            }

            return projects;
        }
    }
}
