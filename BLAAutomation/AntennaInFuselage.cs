using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class AntennaInFuselage
    {
        internal Antenna Antenna { get; set; }
        internal double CoordinateX { get; set; }
        internal double CoordinateY { get; set; }
        internal double CoordinateZ { get; set; }

        public AntennaInFuselage(int idAntenna, double coordinateX, double coordinateY, double coordinateZ, SQLiteConnection connection)
        {
            Antenna = new Antenna(idAntenna, connection);
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
        }

        public static AntennaInFuselage[] GetAntennasForFuselage(SQLiteConnection connection, int idFuselage)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "AntennaInFuselage", "Id_Fuselage = " + idFuselage.ToString() + ";");
            AntennaInFuselage[] antennasInFuselage = new AntennaInFuselage[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                DataRow row = dataSetObjects.Tables[0].Rows[i];
                antennasInFuselage[i] = new AntennaInFuselage(
                    int.Parse(row["Id_Antenna"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    connection
                );
            }
            return antennasInFuselage;
        }

        public static void AddAntennaToFuselage(SQLiteConnection connection, int idFuselage, int idAntenna, double coordinateX, double coordinateY, double coordinateZ)
        {
            string[] columns = { "Id_Antenna", "Id_Fuselage", "CoordinateX", "CoordinateY", "CoordinateZ" };
            string[] values = { idAntenna.ToString(), idFuselage.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "AntennaInFuselage", columns, values);
        }

        public static void RemoveAntennaFromFuselage(SQLiteConnection connection, int idFuselage, int idAntenna)
        {
            string whereClause = $"WHERE Id_Fuselage = {idFuselage} AND Id_Antenna = {idAntenna}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "AntennaInFuselage", whereClause);
        }
    }
}
