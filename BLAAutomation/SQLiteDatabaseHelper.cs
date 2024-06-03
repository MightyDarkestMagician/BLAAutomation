using System.Data.SQLite;
using System.Data;
using System.IO;
using System;

namespace BLAAutomation
{
    public static class SQLiteDatabaseHelper
    {
        private static string _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\App_Data", "blaautomation.db");

        public static SQLiteConnection ConnectToDatabase()
        {
            SQLitePCL.Batteries.Init();
            string connectionString = $"Data Source={_databasePath};Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static string GetConnectionString()
        {
            return $"Data Source={_databasePath};Version=3;";
        }

        public static DataSet SQLiteCommandSelectAllFrom(SQLiteConnection sqliteConn, string tableName)
        {
            if (sqliteConn.State == ConnectionState.Closed || sqliteConn.State == ConnectionState.Broken)
            {
                sqliteConn.Open();
            }

            DataSet dataSet = new DataSet();
            string sqlCommand = "SELECT * FROM " + tableName;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommand, sqliteConn);
            adapter.Fill(dataSet);
            sqliteConn.Close();
            return dataSet;
        }

        public static DataSet SQLiteCommandSelectWithCustomCondition(SQLiteConnection sqliteConn, string tableName, string condition)
        {
            if (sqliteConn.State == ConnectionState.Closed || sqliteConn.State == ConnectionState.Broken)
            {
                sqliteConn.Open();
            }

            DataSet dataSet = new DataSet();
            string sqlCommand = $"SELECT * FROM {tableName} WHERE {condition}";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommand, sqliteConn);
            adapter.Fill(dataSet);
            sqliteConn.Close();
            return dataSet;
        }

        public static void SQLiteCommandInsertInto(SQLiteConnection sqliteConn, string tableName, string[] columnsName, string[] columnsValue)
        {
            if (sqliteConn.State == ConnectionState.Closed || sqliteConn.State == ConnectionState.Broken)
            {
                sqliteConn.Open();
            }

            string sqlCommand = $"INSERT INTO {tableName} ({string.Join(", ", columnsName)}) VALUES ('{string.Join("', '", columnsValue)}')";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, sqliteConn);
            command.ExecuteNonQuery();
            sqliteConn.Close();
        }

        public static void SQLiteCommandDeleteFrom(SQLiteConnection sqliteConn, string tableName, string where)
        {
            if (sqliteConn.State == ConnectionState.Closed || sqliteConn.State == ConnectionState.Broken)
            {
                sqliteConn.Open();
            }

            string sqlCommand = $"DELETE FROM {tableName} {where}";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, sqliteConn);
            command.ExecuteNonQuery();
            sqliteConn.Close();
        }
    }
}
