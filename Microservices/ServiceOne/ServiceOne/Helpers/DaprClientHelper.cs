using Dapr.Client;
using ServiceOne.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceOne.Helpers
{
    public class DaprClientHelper : IDaprClientHelper
    {
        public async Task<bool> PublishToTopicWithDaprClient<T>(string pubsubName, string topicName, T data)
        {
            var daprClient = new DaprClientBuilder().Build();
            await daprClient.PublishEventAsync<T>(pubsubName, topicName, data);
            return true;
        }

        public async Task<T> ResponseByDaprClient<T>(HttpMethod httpMethod, string appId, string endPoint)
        {
            var daprClient = new DaprClientBuilder().Build();
            HttpRequestMessage daprRequest = daprClient.CreateInvokeMethodRequest(httpMethod, appId, endPoint);
            var result = await daprClient.InvokeMethodAsync<T>(daprRequest);
            return result;

        }
    }
}
