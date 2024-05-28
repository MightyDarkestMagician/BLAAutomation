using System.Data.SQLite;

public static class SQLiteDatabaseHelper
{
    private static string dbFileName = "ProjectDatabase.db";

    public static SQLiteConnection ConnectToDatabase()
    {
        var connectionString = $"Data Source={dbFileName}; Version=3;";
        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Open();
        return connection;
    }

    public static void InitializeDatabase()
    {
        using (var conn = ConnectToDatabase())
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Projects (
                             ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                             Name TEXT NOT NULL
                           );";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }
}