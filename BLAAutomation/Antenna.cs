using System;
using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;

namespace BLAAutomation
{
    public class Antenna : BasicObject
    {
        internal double Length { get; set; }
        internal double Amperage { get; set; }
        internal double Power { get; set; }
        internal double Frequency { get; set; }

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
    }
}