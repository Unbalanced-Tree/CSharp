using HotChocolate;
using System.Collections.Generic;

namespace ChocolateServer
{
    public class Query
    {
        public List<Employee> GetEmployees([Service] DbHelpers dbHelpers)
        {
            return dbHelpers.GetEmployees();
        }
    }
}
