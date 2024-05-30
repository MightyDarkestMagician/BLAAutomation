using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public class Compartment
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Carrying { get; set; }
        public double E { get; set; } // Adding the missing property

        public Compartment(int id, double coordinateX, double coordinateY, double coordinateZ, double length, double width, double height, double carrying)
        {
            Id = id;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
            Length = length;
            Width = width;
            Height = height;
            Carrying = carrying;
            E = 0; // Initializing the missing property
        }

        public static List<Compartment> GetCompartmentsForFuselage(SQLiteConnection connection, int fuselageId)
        {
            var compartments = new List<Compartment>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "CompartmentsInFuselage", $"Id_Fuselage = {fuselageId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var compartment = new Compartment(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    double.Parse(row["Length"].ToString()),
                    double.Parse(row["Width"].ToString()),
                    double.Parse(row["Height"].ToString()),
                    double.Parse(row["Carrying"].ToString())
                );
                compartments.Add(compartment);
            }

            return compartments;
        }

        public static List<Compartment> GetCompartmentsForProject(SQLiteConnection connection, int projectId)
        {
            var compartments = new List<Compartment>();
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "CompartmentsInProject", $"ProjectId = {projectId}");

            foreach (DataRow row in dataSetObjects.Tables[0].Rows)
            {
                var compartment = new Compartment(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    double.Parse(row["Length"].ToString()),
                    double.Parse(row["Width"].ToString()),
                    double.Parse(row["Height"].ToString()),
                    double.Parse(row["Carrying"].ToString())
                );
                compartments.Add(compartment);
            }

            return compartments;
        }

        public static void AddCompartmentToFuselage(SQLiteConnection connection, int fuselageId, double coordinateX, double coordinateY, double coordinateZ, double length, double width, double height, double carrying)
        {
            string[] columns = { "Id_Fuselage", "CoordinateX", "CoordinateY", "CoordinateZ", "Length", "Width", "Height", "Carrying" };
            string[] values = { fuselageId.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), length.ToString(), width.ToString(), height.ToString(), carrying.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "CompartmentsInFuselage", columns, values);
        }

        public static void RemoveCompartmentFromFuselage(SQLiteConnection connection, int fuselageId, int compartmentId)
        {
            string whereClause = $"WHERE Id_Fuselage = {fuselageId} AND Id = {compartmentId}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "CompartmentsInFuselage", whereClause);
        }
    }
}
