using System;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class PlacementPosition
    {
        public int Id { get; set; }
        public int FuselageId { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public double MaxWeight { get; set; }

        public PlacementPosition(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "PlacementPosition", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            FuselageId = int.Parse(row["FuselageId"].ToString());
            CoordinateX = double.Parse(row["CoordinateX"].ToString());
            CoordinateY = double.Parse(row["CoordinateY"].ToString());
            CoordinateZ = double.Parse(row["CoordinateZ"].ToString());
            MaxWeight = double.Parse(row["MaxWeight"].ToString());
        }

        public static void AddPosition(SQLiteConnection connection, int fuselageId, double coordinateX, double coordinateY, double coordinateZ, double maxWeight)
        {
            string[] columns = { "FuselageId", "CoordinateX", "CoordinateY", "CoordinateZ", "MaxWeight" };
            string[] values = { fuselageId.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), maxWeight.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "PlacementPosition", columns, values);
        }

        public static void RemovePosition(SQLiteConnection connection, int id)
        {
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "PlacementPosition", $"WHERE Id = {id}");
        }
    }
}
