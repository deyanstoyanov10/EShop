namespace EShop.Tests.Routing
{
    using EShop.API.Controllers;
    using MyTested.AspNetCore.Mvc;
    using MyTested.WebApi;
    using Xunit;
    using static Common.Authentication.AuthenticationRecords;

    public class AuthControllerRouteTests
    {
        private readonly string LoginModelJson = "{\"username\": \"validUsername\",\"password\": \"validPassword\"}";

        //[Fact]
        //public void PostLoginShouldBeMappedCorrectly()
        //    => MyWebApi
        //            .Routes()
        //            .ShouldMap("api/Books/Get")
        //            .WithHttpMethod(HttpMethod.Get)
        //            .To<AuthController>(c => c.Get());
    }
}
