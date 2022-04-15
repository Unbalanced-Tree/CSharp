﻿using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceOne.Interfaces
{
    public interface IDaprClientHelper
    {
        Task<T> ResponseByDaprClient<T>(HttpMethod httpMethod, string appId, string endPoint);
    }
}
