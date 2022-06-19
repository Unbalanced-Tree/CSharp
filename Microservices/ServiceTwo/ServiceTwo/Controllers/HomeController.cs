using Dapr;
using Microsoft.AspNetCore.Mvc;
using ServiceTwo.Models;
using System;

namespace ServiceTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(nameof(GetMessage))]
        public ActionResult<string> GetMessage()
        {
            return new JsonResult("Contact with ServiceTwo");
        }

        [Topic("pubsub", "publishmessage")]
        [HttpPost(nameof(PublishedMessage))]
        public ActionResult<bool> PublishedMessage(PublishedMessageRequestModel requestModel)
        {
            Console.WriteLine($"Published Number:- {requestModel.Number}, DateTime: - {DateTime.Now}");
            return true;
        }
    }
}
