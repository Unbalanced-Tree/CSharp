using MediatRProject.ApiFolder;
using Microsoft.AspNetCore.Mvc;

namespace MediatRProject.Controllers
{
    public class HomeController : ApiControllerBase
    {
        public HomeController()
        {

        }
        [HttpGet(nameof(ApiController))]
        public async Task<ActionResult<ApiResponseModel>> ApiController(int number)
        {
            try
            {
                var request = new ApiRequestModel { Number = number };
                return await Mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
