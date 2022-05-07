using InMemoryDb.Interfaces;
using Microsoft.Data.Sqlite;
using System;

namespace InMemoryDb.Helpers
{
    public class DbHelpers : IDbHelpers
    {
        public readonly string dbFilePath = @$"{Environment.CurrentDirectory}\localDB.db";
        private SqliteConnection inMemoryDbConnection = null;
        public DbHelpers()
        {

        }
        public SqliteConnection GetPhysicalDbConnection()
        {
            var dbConnection = new SqliteConnection("Data Source =" + dbFilePath + ";Mode=ReadWrite");
            dbConnection.Open();
            return dbConnection;
        }

        public SqliteConnection GetInMemoryDbConnection()
        {
            if (inMemoryDbConnection == null)
            {
                inMemoryDbConnection = new SqliteConnection("Data Source=:memory:");
                inMemoryDbConnection.Open();
                return inMemoryDbConnection;
            }
            return inMemoryDbConnection;
        }
    }
}
