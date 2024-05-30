using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double NoiseImmunity { get; set; }

        public Device(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Device", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            Name = row["Name"].ToString();
            Weight = double.Parse(row["Weight"].ToString());
            NoiseImmunity = double.Parse(row["NoiseImmunity"].ToString());
        }

        public static Device[] GetDevicesForProject(SQLiteConnection connection, int projectId)
        {
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "DevicesForPlacement", "Id_Project = " + projectId);
            var devices = new Device[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                var row = dataSetObjects.Tables[0].Rows[i];
                devices[i] = new Device(int.Parse(row["Id_Device"].ToString()), connection);
            }
            return devices;
        }

        public static Device[] GetAllDevices(SQLiteConnection connection)
        {
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Device");
            var devices = new Device[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                devices[i] = new Device(int.Parse(dataSetObjects.Tables[0].Rows[i]["Id"].ToString()), connection);
            }
            return devices;
        }

        public static void AddDevice(SQLiteConnection connection, string name, double weight, double noiseImmunity)
        {
            string[] columns = { "Name", "Weight", "NoiseImmunity" };
            string[] values = { name, weight.ToString(), noiseImmunity.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Device", columns, values);
        }

        public static void RemoveDevice(SQLiteConnection connection, int deviceId)
        {
            string whereClause = $"WHERE Id = {deviceId}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Device", whereClause);
        }
    }
}
