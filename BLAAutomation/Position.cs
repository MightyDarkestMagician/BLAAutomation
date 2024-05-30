using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Position
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public int CompartmentId { get; set; }

        public Position(int id, double coordinateX, double coordinateY, double coordinateZ, int compartmentId)
        {
            Id = id;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
            CompartmentId = compartmentId;
        }

        public static List<Position> GetPositionsForFuselage(SQLiteConnection connection, int fuselageId)
        {
            var positions = new List<Position>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "PositionsForPlacement", $"Id_Fuselage = {fuselageId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var position = new Position(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    int.Parse(row["CompartmentId"].ToString())
                );
                positions.Add(position);
            }

            return positions;
        }

        public static List<Position> GetPositionsForProject(SQLiteConnection connection, int projectId)
        {
            var positions = new List<Position>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "PositionsForProject", $"ProjectId = {projectId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var position = new Position(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    int.Parse(row["CompartmentId"].ToString())
                );
                positions.Add(position);
            }

            return positions;
        }
    }
}
