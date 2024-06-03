using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class Antenna
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Amperage { get; set; }
        public double Power { get; set; }
        public double Frequency { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public int CompartmentId { get; set; }

        public Antenna(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Antenna", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            Name = row["Name"].ToString();
            Length = double.Parse(row["Length"].ToString());
            Amperage = double.Parse(row["Amperage"].ToString());
            Power = double.Parse(row["Power"].ToString());
            Frequency = double.Parse(row["Frequency"].ToString());
            CoordinateX = double.Parse(row["CoordinateX"].ToString());
            CoordinateY = double.Parse(row["CoordinateY"].ToString());
            CoordinateZ = double.Parse(row["CoordinateZ"].ToString());
            CompartmentId = int.Parse(row["CompartmentId"].ToString());
        }

        public static void AddAntenna(SQLiteConnection connection, string name, double length, double amperage, double power, double frequency, double coordinateX, double coordinateY, double coordinateZ, int compartmentId)
        {
            string[] columns = { "Name", "Length", "Amperage", "Power", "Frequency", "CoordinateX", "CoordinateY", "CoordinateZ", "CompartmentId" };
            string[] values = { name, length.ToString(), amperage.ToString(), power.ToString(), frequency.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), compartmentId.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Antenna", columns, values);
        }

        public static List<Antenna> GetAllAntennas(SQLiteConnection connection)
        {
            var antennas = new List<Antenna>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Antenna");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                antennas.Add(new Antenna(int.Parse(row["Id"].ToString()), connection));
            }

            return antennas;
        }

        public static void RemoveAntenna(SQLiteConnection connection, int id)
        {
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Antenna", $"WHERE Id = {id}");
        }
    }
}
