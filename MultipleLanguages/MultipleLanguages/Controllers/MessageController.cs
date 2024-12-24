using Microsoft.AspNetCore.Mvc;

namespace MultipleLanguages.Controllers
{
    public class MessageController : ControllerBase
    {
        [HttpGet(nameof(GetMessage))]
        public ActionResult<string> GetMessage()
        {
            return Messages.Resources.SimpleMessage;
        }
    }
}
