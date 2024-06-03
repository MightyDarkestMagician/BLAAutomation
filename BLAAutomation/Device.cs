using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BLAAutomation
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public double Weight { get; set; }
        public double NoiseImmunity { get; set; }

        public Device(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Device", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            Name = row["Name"].ToString();
            Power = double.Parse(row["Power"].ToString());
            Weight = double.Parse(row["Weight"].ToString());
            NoiseImmunity = double.Parse(row["NoiseImmunity"].ToString());
        }

        public static List<Device> GetDevicesForProject(SQLiteConnection connection, int projectId)
        {
            var devices = new List<Device>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Device", $"ProjectId = {projectId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                devices.Add(new Device(int.Parse(row["Id"].ToString()), connection));
            }

            return devices;
        }

        public static void AddDevice(SQLiteConnection connection, string name, double power, double weight, double noiseImmunity)
        {
            string[] columns = { "Name", "Power", "Weight", "NoiseImmunity" };
            string[] values = { name, power.ToString(), weight.ToString(), noiseImmunity.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Device", columns, values);
        }

        public static void RemoveDevice(SQLiteConnection connection, int id)
        {
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Device", $"WHERE Id = {id}");
        }
    }
}