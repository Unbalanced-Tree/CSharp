using Microsoft.Data.Sqlite;

namespace InMemoryDb.Interfaces
{
    public interface IDbHelpers
    {
        SqliteConnection GetPhysicalDbConnection();
        SqliteConnection GetInMemoryDbConnection();
    }
}
