namespace EShop.API.Controllers
{
    using Common.ApiResponse;
    using Infrastructure.Extensions;
    using Services.Authentication.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using static EShop.Common.Authentication.AuthenticationRecords;

    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ApiResponse<AppUserOutputModel>> Register([FromBody] RegisterUserInputModel registerInput)
        {
            var result = await _authService.Register(registerInput);

            if (result.Failure)
            {
                return new ApiResponse<AppUserOutputModel>(result.Errors);
            }

            return await Login(new LoginUserInputModel(registerInput.Username, registerInput.Password));
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ApiResponse<AppUserOutputModel>> Login([FromBody] LoginUserInputModel loginInput)
        {
            var result = await _authService.Login(loginInput);

            if (result.Failure)
            {
                return result.ToErrorApiResponse();
            }

            return result.ToApiResponse();
        }
    }
}
