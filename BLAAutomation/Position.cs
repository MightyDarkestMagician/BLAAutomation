using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation.Objects
{
    public class Position
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }

        public Position(int id, double coordinateX, double coordinateY, double coordinateZ)
        {
            Id = id;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
        }

        public static Position[] GetPositionsForFuselage(SQLiteConnection connection, int idFuselage)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "PositionsForPlacement", "Id_Fuselage = " + idFuselage.ToString() + ";");
            Position[] positions = new Position[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                DataRow row = dataSetObjects.Tables[0].Rows[i];
                positions[i] = new Position(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString())
                );
            }
            return positions;
        }

        public static void AddPositionToFuselage(SQLiteConnection connection, int idFuselage, double coordinateX, double coordinateY, double coordinateZ)
        {
            string[] columns = { "Id_Fuselage", "CoordinateX", "CoordinateY", "CoordinateZ" };
            string[] values = { idFuselage.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "PositionsForPlacement", columns, values);
        }

        public static void RemovePositionFromFuselage(SQLiteConnection connection, int idFuselage, int idPosition)
        {
            string whereClause = $"WHERE Id_Fuselage = {idFuselage} AND Id_Position = {idPosition}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "PositionsForPlacement", whereClause);
        }

        public static bool IsPositionInCompartment(Compartment compartment, Position position)
        {
            return position.CoordinateX <= (compartment.CoordinateX + compartment.Length / 2.0) &&
                   position.CoordinateX >= (compartment.CoordinateX - compartment.Length / 2.0) &&
                   position.CoordinateY <= (compartment.CoordinateY + compartment.Width / 2.0) &&
                   position.CoordinateY >= (compartment.CoordinateY - compartment.Width / 2.0) &&
                   position.CoordinateZ <= (compartment.CoordinateZ + compartment.Height / 2.0) &&
                   position.CoordinateZ >= (compartment.CoordinateZ - compartment.Height / 2.0);
        }
    }
}
