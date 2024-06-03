using System;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class EquipmentPlacement
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int CompartmentId { get; set; }
        public string Description { get; set; }
        public DateTime PlacementDate { get; set; }

        public static void AddPlacement(SQLiteConnection connection, int deviceId, int compartmentId, string description, DateTime placementDate)
        {
            string[] columns = { "DeviceId", "CompartmentId", "Description", "PlacementDate" };
            string[] values = { deviceId.ToString(), compartmentId.ToString(), description, placementDate.ToString("yyyy-MM-dd") };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "DevicePlacement", columns, values);
        }
    }
}
