using System;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class AntennaInFuselage
    {
        public int Id { get; set; }
        public int AntennaId { get; set; }
        public int FuselageId { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }

        public AntennaInFuselage(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "AntennaInFuselage", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            AntennaId = int.Parse(row["AntennaId"].ToString());
            FuselageId = int.Parse(row["FuselageId"].ToString());
            CoordinateX = double.Parse(row["CoordinateX"].ToString());
            CoordinateY = double.Parse(row["CoordinateY"].ToString());
            CoordinateZ = double.Parse(row["CoordinateZ"].ToString());
        }

        public static void AddAntennaToFuselage(SQLiteConnection connection, int antennaId, int fuselageId, double coordinateX, double coordinateY, double coordinateZ)
        {
            string[] columns = { "AntennaId", "FuselageId", "CoordinateX", "CoordinateY", "CoordinateZ" };
            string[] values = { antennaId.ToString(), fuselageId.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "AntennaInFuselage", columns, values);
        }

        public static void RemoveAntennaFromFuselage(SQLiteConnection connection, int id)
        {
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "AntennaInFuselage", $"WHERE Id = {id}");
        }
    }
}
