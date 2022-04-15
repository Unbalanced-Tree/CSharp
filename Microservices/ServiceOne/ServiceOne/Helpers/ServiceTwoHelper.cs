using ServiceOne.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceOne.Helpers
{
    public class ServiceTwoHelper : IServiceTwoHelper
    {
        private readonly IDaprClientHelper _daprClientHelper;

        public ServiceTwoHelper(IDaprClientHelper daprClientHelper)
        {
            _daprClientHelper = daprClientHelper;
        }
        public async Task<string> GetMessage()
        {
            var response = await _daprClientHelper.ResponseByDaprClient<string>(HttpMethod.Get, "servicetwoapp", "/Home/GetMessage");
            return response;
        }
    }
}
