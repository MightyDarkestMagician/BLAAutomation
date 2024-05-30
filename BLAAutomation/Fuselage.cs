using System;
using System.Data.SQLite;
using System.Linq;

namespace BLAAutomation
{
    public class Fuselage : BasicObject
    {
        public AntennaInFuselage[] AntennasForFuselage { get; private set; }
        public Compartment[] CompartmentsForFuselage { get; private set; }
        public Position[] PositionsForFuselage { get; private set; }

        public double[,] Distances { get; private set; }
        public double[,] E { get; private set; }

        public Fuselage(int id, SQLiteConnection connection) : base(id)
        {
            var dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Fuselage", "Id = " + id + ";");
            Name = dataSetObject.Tables[0].Rows[0]["Name"].ToString();
            AntennasForFuselage = AntennaInFuselage.GetAntennasForFuselage(connection, id);
            CompartmentsForFuselage = Compartment.GetCompartmentsForFuselage(connection, id).ToArray();
            PositionsForFuselage = Position.GetPositionsForFuselage(connection, id).ToArray();

            CalculateDistancesAndFields();
        }

        private void CalculateDistancesAndFields()
        {
            const double c = 299792458.0;
            const double eps = 1.0;

            Distances = new double[AntennasForFuselage.Length, CompartmentsForFuselage.Length];
            E = new double[AntennasForFuselage.Length, CompartmentsForFuselage.Length];

            for (int i = 0; i < AntennasForFuselage.Length; i++)
            {
                var ant = AntennasForFuselage[i];
                for (int j = 0; j < CompartmentsForFuselage.Length; j++)
                {
                    var cmp = CompartmentsForFuselage[j];
                    Distances[i, j] = Math.Sqrt(Math.Pow(cmp.CoordinateX - ant.CoordinateX, 2) +
                                                Math.Pow(cmp.CoordinateY - ant.CoordinateY, 2) +
                                                Math.Pow(cmp.CoordinateZ - ant.CoordinateZ, 2));
                    double toCheck = c / (2.0 * Math.PI * ant.Antenna.Frequency);
                    if (Distances[i, j] < toCheck)
                    {
                        E[i, j] = (ant.Antenna.Amperage * ant.Antenna.Length) / (4.0 * Math.PI * Math.PI * eps * ant.Antenna.Frequency * Math.Pow(Distances[i, j], 2));
                    }
                    else
                    {
                        E[i, j] = Math.Sqrt(30.0 * ant.Antenna.Power) / Distances[i, j];
                    }
                }
            }

            foreach (var cmp in CompartmentsForFuselage)
            {
                cmp.E = AntennasForFuselage.Sum(ant => E[Array.IndexOf(AntennasForFuselage, ant), Array.IndexOf(CompartmentsForFuselage, cmp)]);
            }
        }

        public static Fuselage[] GetFuselages(SQLiteConnection connection)
        {
            var dataSetObjects = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Fuselage");
            var fuselages = new Fuselage[dataSetObjects.Tables[0].Rows.Count];
            for (int i = 0; i < dataSetObjects.Tables[0].Rows.Count; i++)
            {
                fuselages[i] = new Fuselage(int.Parse(dataSetObjects.Tables[0].Rows[i]["Id"].ToString()), connection);
            }
            return fuselages;
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
