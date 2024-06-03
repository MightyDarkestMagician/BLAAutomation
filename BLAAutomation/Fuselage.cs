using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class Fuselage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }

        public Fuselage(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Fuselage", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            Name = row["Name"].ToString();
            Length = double.Parse(row["Length"].ToString());
            Weight = double.Parse(row["Weight"].ToString());
        }

        public static List<Fuselage> GetAllFuselages(SQLiteConnection connection)
        {
            var fuselages = new List<Fuselage>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Fuselage");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                fuselages.Add(new Fuselage(int.Parse(row["Id"].ToString()), connection));
            }

            return fuselages;
        }

        public static void AddFuselage(SQLiteConnection connection, string name, double length, double weight)
        {
            string[] columns = { "Name", "Length", "Weight" };
            string[] values = { name, length.ToString(), weight.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Fuselage", columns, values);
        }

        public static void RemoveFuselage(SQLiteConnection connection, int id)
        {
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Fuselage", $"WHERE Id = {id}");
        }
    }
}
