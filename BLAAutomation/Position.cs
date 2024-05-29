using System;
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

        public static Position[] GetPositionsForFuselage(SQLiteConnection connection, int idFuselage)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "PositionsForPlacement", "Id_Fuselage = " + idFuselage + ";");
            Position[] positions = new Position[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                DataRow row = dataSetObjects.Tables[0].Rows[i];
                positions[i] = new Position(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    int.Parse(row["CompartmentId"].ToString())
                );
            }
            return positions;
        }

        public static void AddPositionToFuselage(SQLiteConnection connection, int idFuselage, double coordinateX, double coordinateY, double coordinateZ, int compartmentId)
        {
            string[] columns = { "Id_Fuselage", "CoordinateX", "CoordinateY", "CoordinateZ", "CompartmentId" };
            string[] values = { idFuselage.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), compartmentId.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "PositionsForPlacement", columns, values);
        }

        public static void RemovePositionFromFuselage(SQLiteConnection connection, int idFuselage, int idPosition)
        {
            string whereClause = $"WHERE Id_Fuselage = {idFuselage} AND Id = {idPosition}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "PositionsForPlacement", whereClause);
        }
    }
}
