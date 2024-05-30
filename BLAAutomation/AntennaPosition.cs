using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class AntennaPosition
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public int CompartmentId { get; set; }

        public AntennaPosition(int id, double coordinateX, double coordinateY, double coordinateZ, int compartmentId)
        {
            Id = id;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
            CompartmentId = compartmentId;
        }

        public static List<AntennaPosition> GetAntennasForProject(SQLiteConnection connection, int projectId)
        {
            var antennas = new List<AntennaPosition>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Antennas", $"ProjectId = {projectId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var antenna = new AntennaPosition(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    int.Parse(row["CompartmentId"].ToString())
                );
                antennas.Add(antenna);
            }

            return antennas;
        }
    }

}
