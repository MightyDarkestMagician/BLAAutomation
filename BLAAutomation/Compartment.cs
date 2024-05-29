using System;
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
        public double E { get; set; } // Добавлено свойство E

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
            E = 0; // Инициализация E
        }

        public static Compartment[] GetCompartmentsForFuselage(SQLiteConnection connection, int idFuselage)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "CompartmentsInFuselage", "Id_Fuselage = " + idFuselage.ToString() + ";");
            Compartment[] compartments = new Compartment[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                DataRow row = dataSetObjects.Tables[0].Rows[i];
                compartments[i] = new Compartment(
                    int.Parse(row["Id"].ToString()),
                    double.Parse(row["CoordinateX"].ToString()),
                    double.Parse(row["CoordinateY"].ToString()),
                    double.Parse(row["CoordinateZ"].ToString()),
                    double.Parse(row["Length"].ToString()),
                    double.Parse(row["Width"].ToString()),
                    double.Parse(row["Height"].ToString()),
                    double.Parse(row["Carrying"].ToString())
                );
            }
            return compartments;
        }

        public static void AddCompartmentToFuselage(SQLiteConnection connection, int idFuselage, double coordinateX, double coordinateY, double coordinateZ, double length, double width, double height, double carrying)
        {
            string[] columns = { "Id_Fuselage", "CoordinateX", "CoordinateY", "CoordinateZ", "Length", "Width", "Height", "Carrying" };
            string[] values = { idFuselage.ToString(), coordinateX.ToString(), coordinateY.ToString(), coordinateZ.ToString(), length.ToString(), width.ToString(), height.ToString(), carrying.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "CompartmentsInFuselage", columns, values);
        }

        public static void RemoveCompartmentFromFuselage(SQLiteConnection connection, int idFuselage, int idCompartment)
        {
            string whereClause = $"WHERE Id_Fuselage = {idFuselage} AND Id_Compartment = {idCompartment}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "CompartmentsInFuselage", whereClause);
        }
    }
}
