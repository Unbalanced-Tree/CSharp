using Microsoft.AspNetCore.Mvc;

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
    }
}
