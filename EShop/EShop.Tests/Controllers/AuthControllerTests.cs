namespace EShop.Tests.Controllers
{
    using EShop.API.Controllers;
    using EShop.Services.Authentication.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using static Common.Authentication.AuthenticationRecords;
    using EShop.Common.Entities;

    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authService;
        private readonly Mock<ControllerContext> _controllerContext;

        public AuthControllerTests()
        {
            _authService = new Mock<IAuthService>();
            _controllerContext = new Mock<ControllerContext>();
        }

        //[Fact]
        //public async Task Login_ReturnsFailedApiResponse()
        //{
        //    _authService.Setup(x => x.Login(new LoginUserInputModel("test", "test"))).ReturnsAsync(new Common.Result.Result<AppUserOutputModel>("Error"));
        //    _authService.Setup(x => x.Register(new RegisterUserInputModel("test", "test", "test", "test", "test"))).ReturnsAsync("error");
        //    var authController = new AuthController(_authService.Object);
        //    authController.ModelState.AddModelError("Username", "Username is required!");

        //    var result = await authController.Login(new LoginUserInputModel("test", "test"));

        //    Assert.False(result.Succeeded);
        //}
    }
}
