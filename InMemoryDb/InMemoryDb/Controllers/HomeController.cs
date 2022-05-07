using InMemoryDb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Threading.Tasks;

namespace InMemoryDb.Controllers
{
    // I don't recommend writing logic in controller
    public class HomeController : ControllerBase
    {
        private readonly IDbHelpers _dbHelpers;

        public HomeController(IDbHelpers dbHelpers)
        {
            _dbHelpers = dbHelpers;
        }
        [HttpPost(nameof(AddRow))]
        public async Task<bool> AddRow(int number)
        {
            try
            {
                var physicalDbConnection = _dbHelpers.GetPhysicalDbConnection();
                var inMemoryDbConnection = _dbHelpers.GetInMemoryDbConnection();
                // 1. Duplicate physical database to in-memory
                physicalDbConnection.BackupDatabase(inMemoryDbConnection, "main", "main");
                physicalDbConnection.Close();

                // 2. Operations on  the in-memory database
                var query = @$"Insert into TableOne(Id, Value) VALUES({number}, 'data_{number}')";
                using (SqliteCommand command = new())
                {
                    command.CommandText = query;
                    command.Connection = inMemoryDbConnection;
                    command.ExecuteNonQuery();
                }
                //3. Back up the in-memory DB to the physical DB.
                inMemoryDbConnection.BackupDatabase(physicalDbConnection);

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
