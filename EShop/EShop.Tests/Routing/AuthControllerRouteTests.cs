namespace EShop.Tests.Routing
{
    using EShop.API.Controllers;
    using MyTested.AspNetCore.Mvc;
    using MyTested.WebApi;
    using Xunit;
    using static Common.Authentication.AuthenticationRecords;

    public class AuthControllerRouteTests
    {
        private readonly RegisterUserInputModel model = new RegisterUserInputModel("testFirstName", "testLastName", "testUsername", "testEmail", "testPassword");

        [Fact]
        public void PostLoginShouldBeMappedCorrectly()
            => MyWebApi
                    .Routes()
                    .ShouldMap("api/Auth/Register")
                    .WithHttpMethod(HttpMethod.Post)
                    .To<AuthController>(c => c.Register(model));
    }
}
