using MediatR;

namespace MediatRProject.ApiFolder
{
    public class ApiRequestModel : IRequest<ApiResponseModel>
    {
        public int Number { get; set; }
    }
}
