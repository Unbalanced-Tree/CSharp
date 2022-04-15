using Dapr.Client;
using ServiceOne.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceOne.Helpers
{
    public class DaprClientHelper : IDaprClientHelper
    {
        public async Task<T> ResponseByDaprClient<T>(HttpMethod httpMethod, string appId, string endPoint)
        {
            var daprClient = new DaprClientBuilder().Build();
            HttpRequestMessage daprRequest = daprClient.CreateInvokeMethodRequest(httpMethod, appId, endPoint);
            var result = await daprClient.InvokeMethodAsync<T>(daprRequest);
            return result;

        }
    }
}
