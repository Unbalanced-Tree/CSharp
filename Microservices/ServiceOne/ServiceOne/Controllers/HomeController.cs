using Microsoft.AspNetCore.Mvc;
using ServiceOne.Interfaces;
using System.Threading.Tasks;

namespace ServiceOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IServiceTwoHelper _serviceTwoHelper;

        public HomeController(IServiceTwoHelper serviceTwoHelper) 
        {
            _serviceTwoHelper = serviceTwoHelper;
        }
        [HttpGet(nameof(GetMessage))]
        public async Task<ActionResult<string>> GetMessage()
        {
            var serviceTwoResponse = await _serviceTwoHelper.GetMessage();    
            return new JsonResult($"Contact with ServiceOne   {serviceTwoResponse}");
        }

        [HttpGet]
        [Route("PublishMessage/{number}")]
        public async Task<ActionResult<string>> PublishMessage(int number)
        {
            var isPublished = await _serviceTwoHelper.PublishMessageTopic(number);
            if(isPublished)
            {
                return new JsonResult("Message published");
            }
            return new JsonResult("Failed");
        }
    }
}
