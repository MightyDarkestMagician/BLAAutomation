using System;
using System.Data;
using System.Data.SQLite;

namespace BLAAutomation
{
    public static class SQLiteDatabaseHelper
    {
        public const string SQLiteConnString = @"Data Source=ProjectDB; Version=3;";
        private static string _databasePath = "Data Source=BLAAutomation.db";

        public static SQLiteConnection ConnectToDatabase()
        {
            return new SQLiteConnection(_databasePath);
        }

        public static void InitializeDatabase()
        {
            using (var conn = ConnectToDatabase())
            {
                conn.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS Projects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Compartments (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId INTEGER,
                    CoordinateX REAL,
                    CoordinateY REAL,
                    Length REAL,
                    Width REAL,
                    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
                );

                CREATE TABLE IF NOT EXISTS Positions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId INTEGER,
                    CoordinateX REAL,
                    CoordinateY REAL,
                    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
                );

                CREATE TABLE IF NOT EXISTS Antennas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId INTEGER,
                    CoordinateX REAL,
                    CoordinateY REAL,
                    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
                );";

                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
        }


        public static DataSet SQLiteCommandSelectAllFrom(SQLiteConnection sqliteConn, string TableName)
        {
            sqliteConn.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT * FROM " + TableName;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SqlCommand, sqliteConn);
            adapter.Fill(dataSet);
            sqliteConn.Close();
            return dataSet;
        }

        public static DataSet SQLiteCustomCommandSelect(SQLiteConnection sqliteConn, string query)
        {
            sqliteConn.Open();
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, sqliteConn);
            adapter.Fill(dataSet);
            sqliteConn.Close();
            return dataSet;
        }

        public static DataSet SQLiteCommandSelectWithCustomCondition(SQLiteConnection sqliteConn, string TableName, string Condition)
        {
            sqliteConn.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT * FROM " + TableName + " WHERE " + Condition;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SqlCommand, sqliteConn);
            adapter.Fill(dataSet);
            sqliteConn.Close();
            return dataSet;
        }

        public static void SQLiteCommandInsertInto(SQLiteConnection sqliteConn, string TableName, string[] ColumnsName, string[] ColumnsValue)
        {
            sqliteConn.Open();
            string SqlCommand = "INSERT INTO " + TableName + "(";
            for (int i = 0; i < ColumnsName.Length - 1; i++)
            {
                SqlCommand += "'" + ColumnsName[i] + "', ";
            }
            SqlCommand += "'" + ColumnsName[ColumnsName.Length - 1] + "') VALUES (";
            for (int i = 0; i < ColumnsValue.Length - 1; i++)
            {
                SqlCommand += "'" + ColumnsValue[i] + "', ";
            }
            SqlCommand += "'" + ColumnsValue[ColumnsValue.Length - 1] + "')";
            SQLiteCommand command = new SQLiteCommand(SqlCommand, sqliteConn);
            command.ExecuteNonQuery();
            sqliteConn.Close();
        }

        public static void SQLiteCommandDeleteFrom(SQLiteConnection sqliteConn, string TableName, string Where)
        {
            sqliteConn.Open();
            string SqlCommand = "DELETE FROM " + TableName + " " + Where;
            SQLiteCommand command = new SQLiteCommand(SqlCommand, sqliteConn);
            command.ExecuteNonQuery();
            sqliteConn.Close();
        }

        public static int GetLastId(SQLiteConnection sqliteConn, string TableName)
        {
            sqliteConn.Open();
            int id = 0;
            string SqlCommand = "SELECT Max(Id) FROM " + TableName + ";";
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SqlCommand, sqliteConn);
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows[0][0] != null)
            {
                if (dataSet.Tables[0].Rows[0][0].ToString() != "" && dataSet.Tables[0].Rows[0][0].ToString() != "0" && dataSet.Tables[0].Rows[0][0].ToString() != "NULL")
                {
                    id = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                }
            }
            sqliteConn.Close();
            return id;
        }
    }
}
