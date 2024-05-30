using System.Data.SQLite;
using System.Data;
using System.IO;
using System;

namespace BLAAutomation
{
    public static class SQLiteDatabaseHelper
    {
        private static string _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "blaautomation.db");

        public static SQLiteConnection ConnectToDatabase()
        {
            return new SQLiteConnection($"Data Source={_databasePath};Version=3;");
        }

        public static DataSet SQLiteCommandSelectAllFrom(SQLiteConnection sqliteConn, string TableName)
        {
            try
            {
                if (sqliteConn.State == ConnectionState.Closed || sqliteConn.State == ConnectionState.Broken)
                {
                    Console.WriteLine("Opening SQLite connection...");
                    sqliteConn.Open();
                }

                Console.WriteLine($"Executing SELECT * FROM {TableName}");
                DataSet dataSet = new DataSet();
                string SqlCommand = "SELECT * FROM " + TableName;
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SqlCommand, sqliteConn);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SQLiteCommandSelectAllFrom: {ex.Message}");
                throw;
            }
            finally
            {
                if (sqliteConn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Closing SQLite connection...");
                    sqliteConn.Close();
                }
            }
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
            string SqlCommand = "INSERT INTO " + TableName + " (";
            SqlCommand += string.Join(", ", ColumnsName) + ") VALUES ('";
            SqlCommand += string.Join("', '", ColumnsValue) + "')";
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
            string SqlCommand = "SELECT MAX(Id) FROM " + TableName + ";";
            using (var command = new SQLiteCommand(SqlCommand, sqliteConn))
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    id = Convert.ToInt32(result);
                }
            }
            sqliteConn.Close();
            return id;
        }
    }
}
