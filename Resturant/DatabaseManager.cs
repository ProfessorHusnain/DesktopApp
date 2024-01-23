using System;
using System.Data.SQLite;

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager()
    {
        // Set the connection string, database is created if it doesn't exist
        connectionString = $@"Data Source=..\..\Repository\Resturant.db;Version=3;";
    }

    public void InitializeDatabase()
    {
        // Create a new database connection
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            // Open the connection
            conn.Open();

            // Create tables
            CreateTable(conn, "SampleTable1", "Id INTEGER PRIMARY KEY, Name TEXT, Age INTEGER");
            CreateTable(conn, "SampleTable2", "Id INTEGER PRIMARY KEY, Product TEXT, Price REAL");
            // Add more tables as needed

            // Close the connection
            conn.Close();
        }
    }

    private void CreateTable(SQLiteConnection conn, string tableName, string columns)
    {
        try
        {
            // SQL command to create a table if it doesn't exist
            string sql = $"CREATE TABLE IF NOT EXISTS {tableName} ({columns})";

            // Execute the command
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Additional methods for inserting data, querying data, etc., can be added here
}

