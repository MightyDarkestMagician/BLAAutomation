using BLAAutomation.Objects;
using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace BLAAutomation
{
    public class Fuselage : BasicObject
    {
        public AntennaInFuselage[] AntennasForFuselage { get; set; }
        public Compartment[] CompartmentsForFuselage { get; set; }
        public Position[] PositionsForFuselage { get; set; }

        public double[,] Distances { get; set; }
        public double[,] E { get; set; }

        public Fuselage(int id, SQLiteConnection connection) : base(id)
        {
            DataSet dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Fuselage", "Id = " + id.ToString() + ";");
            Name = dataSetObject.Tables[0].Rows[0]["Name"].ToString();
            AntennasForFuselage = AntennaInFuselage.GetAntennasForFuselage(connection, id);
            CompartmentsForFuselage = Compartment.GetCompartmentsForFuselage(connection, id);
            PositionsForFuselage = Position.GetPositionsForFuselage(connection, id);

            CalculateDistancesAndEFields();
        }

        public static Fuselage[] GetFuselages(SQLiteConnection connection)
        {
            DataSet dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Fuselage");
            Fuselage[] fuselages = new Fuselage[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                fuselages[i] = new Fuselage(int.Parse(dataSetObjects.Tables[0].Rows[i]["Id"].ToString()), connection);
            }
            return fuselages;
        }

        private void CalculateDistancesAndEFields()
        {
            double c = 299792458.0;
            double eps = 1.0;

            Distances = new double[AntennasForFuselage.Length, CompartmentsForFuselage.Length];
            E = new double[AntennasForFuselage.Length, CompartmentsForFuselage.Length];
            for (int i = 0; i < AntennasForFuselage.Length; i++)
            {
                AntennaInFuselage ant = AntennasForFuselage[i];
                for (int j = 0; j < CompartmentsForFuselage.Length; j++)
                {
                    Compartment cmp = CompartmentsForFuselage[j];
                    Distances[i, j] = Math.Sqrt(
                        Math.Pow(cmp.CoordinateX - ant.CoordinateX, 2) +
                        Math.Pow(cmp.CoordinateY - ant.CoordinateY, 2) +
                        Math.Pow(cmp.CoordinateZ - ant.CoordinateZ, 2)
                    );
                    double toCheck = c / (2.0 * Math.PI * ant.Antenna.Frequency);
                    if (Distances[i, j] < toCheck)
                    {
                        E[i, j] = (ant.Antenna.Amperage * ant.Antenna.Length) /
                                  (4.0 * Math.PI * Math.PI * eps * ant.Antenna.Frequency * Distances[i, j] * Distances[i, j]);
                    }
                    else
                    {
                        E[i, j] = Math.Sqrt(30.0 * ant.Antenna.Power) / Distances[i, j];
                    }
                }
            }

            foreach (var compartment in CompartmentsForFuselage)
            {
                compartment.E = 0;
                for (int j = 0; j < AntennasForFuselage.Length; j++)
                {
                    compartment.E += E[j, CompartmentsForFuselage.ToList().IndexOf(compartment)];
                }
            }
        }

        public static void AddFuselage(SQLiteConnection connection, string name)
        {
            string[] columns = { "Name" };
            string[] values = { name };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Fuselage", columns, values);
        }

        public static void RemoveFuselage(SQLiteConnection connection, int idFuselage)
        {
            string whereClause = $"WHERE Id = {idFuselage}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Fuselage", whereClause);
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "CompartmentsInFuselage", $"WHERE Id_Fuselage = {idFuselage}");
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "AntennaInFuselage", $"WHERE Id_Fuselage = {idFuselage}");
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "PositionsForPlacement", $"WHERE Id_Fuselage = {idFuselage}");
        }
    }
}
