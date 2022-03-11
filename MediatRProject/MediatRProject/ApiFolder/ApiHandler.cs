using MediatR;

namespace MediatRProject.ApiFolder
{
    public class ApiHandler : IRequestHandler<ApiRequestModel, ApiResponseModel>
    {
        public async Task<ApiResponseModel> Handle(ApiRequestModel request, CancellationToken cancellationToken)
        {
            var response = $"Number :- {request.Number}";
            // Logic Here 
            return new ApiResponseModel
            {
                Response = response
            };
        }
    }
}
