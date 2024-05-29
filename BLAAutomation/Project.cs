using System.Collections.Generic;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Project
    {
        public List<Compartment> Compartments { get; set; }
        public List<Position> Positions { get; set; }
        public List<AntennaPosition> Antennas { get; set; }

        public Project()
        {
            Compartments = new List<Compartment>();
            Positions = new List<Position>();
            Antennas = new List<AntennaPosition>();
        }

        public static void AddProject(SQLiteConnection connection, string name, int fuselageId)
        {
            string[] columns = { "Name", "Id_Fuselage" };
            string[] values = { name, fuselageId.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Project", columns, values);
        }
    }

    public class AntennaPosition
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
    }
}
