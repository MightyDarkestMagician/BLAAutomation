using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Device : BasicObject
    {
        public double Weight { get; set; }
        public double NoiseImmunity { get; set; }

        public Device(int id, SQLiteConnection connection) : base(id)
        {
            DataSet dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Device", "Id = " + id.ToString() + ";");
            Name = dataSetObject.Tables[0].Rows[0]["Name"].ToString();
            Weight = double.Parse(dataSetObject.Tables[0].Rows[0]["Weight"].ToString());
            NoiseImmunity = double.Parse(dataSetObject.Tables[0].Rows[0]["NoiseImmunity"].ToString());
        }

        public static Device[] GetDevicesForProject(SQLiteConnection connection, int projectId)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "DevicesForPlacement", "Id_Project = " + projectId.ToString() + ";");
            Device[] devices = new Device[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                devices[i] = new Device(int.Parse(dataSetObjects.Tables[0].Rows[i]["Id_Device"].ToString()), connection);
            }
            return devices;
        }

        public static Device[] GetAllDevices(SQLiteConnection connection)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Device");
            Device[] devices = new Device[dataSetObjects.Tables[0].Rows.Count];
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
