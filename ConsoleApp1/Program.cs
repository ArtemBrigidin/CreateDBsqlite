using ConsoleApp1;
using Microsoft.Data.Sqlite;

File.Create(Costants.DatabaseFile).Close();
using (SqliteConnection databaseConnection = new SqliteConnection(Costants.DatabaseConnectionString))
{
    databaseConnection.Open();
    SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE Name (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT)");

    SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE Deposit (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Amount TEXT)");

    SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE Bondsman (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT)");

    void SendSqlCommandNonQuery(SqliteConnection sqliteConnection, string sqlCommand){
        using var command = sqliteConnection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = sqlCommand;
        command.ExecuteNonQuery();
    }
}
