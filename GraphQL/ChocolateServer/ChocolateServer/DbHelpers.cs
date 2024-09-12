using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ChocolateServer
{
    public class DbHelpers
    {
        private readonly string _connectionString = "data source=DESKTOP-K9SMV5M\\SQLEXPRESS;initial catalog=LocalDb;trusted_connection=true;TrustServerCertificate=True;";

        public List<Employee> GetEmployees()
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            var data = dbConnection.Query<Employee>("Select EmployeeId, EmployeeName, DoB, Salary, DepartmentId From Employee").AsList();
            return data;
        }
    }
}
