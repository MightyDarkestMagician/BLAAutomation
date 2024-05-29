using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Antenna : BasicObject
    {
        public double Length { get; set; }
        public double Amperage { get; set; }
        public double Power { get; set; }
        public double Frequency { get; set; }

        public Antenna(int id, SQLiteConnection connection) : base(id)
        {
            DataSet dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Antenna", "Id = " + id.ToString() + ";");
            Name = dataSetObject.Tables[0].Rows[0]["Name"].ToString();
            Length = double.Parse(dataSetObject.Tables[0].Rows[0]["Length"].ToString());
            Amperage = double.Parse(dataSetObject.Tables[0].Rows[0]["Amperage"].ToString());
            Power = double.Parse(dataSetObject.Tables[0].Rows[0]["Power"].ToString());
            Frequency = double.Parse(dataSetObject.Tables[0].Rows[0]["Frequency"].ToString());
        }

        public static Antenna[] GetAntennas(SQLiteConnection connection)
        {
            DataSet dataSet = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Antenna");
            Antenna[] antennas = new Antenna[dataSet.Tables[0].Rows.Count];
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                var row = dataSet.Tables[0].Rows[i];
                antennas[i] = new Antenna(int.Parse(row["Id"].ToString()), connection);
            }
            return antennas;
        }

        public static void AddAntenna(SQLiteConnection connection, string name, double length, double amperage, double power, double frequency)
        {
            string[] columns = { "Name", "Length", "Amperage", "Power", "Frequency" };
            string[] values = { name, length.ToString(), amperage.ToString(), power.ToString(), frequency.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Antenna", columns, values);
        }

        public static void RemoveAntenna(SQLiteConnection connection, int idAntenna)
        {
            string whereClause = $"WHERE Id = {idAntenna}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Antenna", whereClause);
        }
    }
}