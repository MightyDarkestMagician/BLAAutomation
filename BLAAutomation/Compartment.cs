using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Compartment
    {
        public int Id { get; set; }
        public int FuselageId { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Carrying { get; set; }

        public Compartment(int id, SQLiteConnection connection)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Compartment", "Id = " + id);
            var row = dataSetObject.Tables[0].Rows[0];
            Id = id;
            FuselageId = int.Parse(row["FuselageId"].ToString());
            CoordinateX = double.Parse(row["CoordinateX"].ToString());
            CoordinateY = double.Parse(row["CoordinateY"].ToString());
            CoordinateZ = double.Parse(row["CoordinateZ"].ToString());
            Length = double.Parse(row["Length"].ToString());
            Width = double.Parse(row["Width"].ToString());
            Height = double.Parse(row["Height"].ToString());
            Carrying = double.Parse(row["Carrying"].ToString());
        }

        public static List<Compartment> GetCompartmentsForFuselage(SQLiteConnection connection, int fuselageId)
        {
            var compartments = new List<Compartment>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Compartment", $"FuselageId = {fuselageId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                compartments.Add(new Compartment(int.Parse(row["Id"].ToString()), connection));
            }

            return compartments;
        }

        public static List<Compartment> GetCompartmentsForProject(SQLiteConnection connection, int projectId)
        {
            var compartments = new List<Compartment>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Compartment", $"ProjectId = {projectId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                compartments.Add(new Compartment(int.Parse(row["Id"].ToString()), connection));
            }

            return compartments;
        }

        public static void AddCompartment(SQLiteConnection connection, int fuselageId, double coordinateX, double coordinateY, double coordinateZ, double length, double width, double height, double carrying)
        {
            string[] columns = { "FuselageId", "CoordinateX", "CoordinateY", "CoordinateZ", "Length", "Width", "Height", "Carrying" };
            string[] values = { fuselageId.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), length.ToString(), width.ToString(), height.ToString(), carrying.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Compartment", columns, values);
        }
    }
}
