namespace EShop.Tests.Services
{
    using EShop.Common.Entities;
    using EShop.Services.Authentication;
    using EShop.Services.Providers.Contracts;
    using EShop.Services.ShoppingCart.Contracts;

    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using static EShop.Tests.ObjectFactory;
    using static EShop.Common.Authentication.AuthenticationRecords;

    public class AuthServiceTests
    {
        private readonly MockedLoginUserManager _loginUserManager;
        private readonly MockedRegistrationUserManager _registrationUserManager;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly ICartService _cartService;

        public AuthServiceTests()
        {
            var store = new Mock<IUserStore<AppUser>>();
            _loginUserManager = new MockedLoginUserManager(store.Object, null, null, null, null, null, null, null, null);
            _registrationUserManager = new MockedRegistrationUserManager(store.Object, null, null, null, null, null, null, null, null);
            _jwtTokenProvider = GetMockedJwtTokenProvider();
            _cartService = new Mock<ICartService>().Object;
        }

        [Fact]
        public async Task Registration_ReturnsSuccess_WithValidCredentialsInput()
        {
            var input = new RegisterUserInputModel()
            {
                FirstName = "First",
                LastName = "Last",
                Username = MockedRegistrationUserManager.ValidRegistrationUsername,
                Email = MockedRegistrationUserManager.ValidRegistrationEmail,
                Password = MockedRegistrationUserManager.ValidRegistrationPassword,
                ConfirmPassword = MockedRegistrationUserManager.ValidRegistrationPassword
            };

            var authService = new AuthService(_registrationUserManager, _jwtTokenProvider, _cartService);

            var result = await authService.Register(input);

            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData(" ", " ", " ")]
        [InlineData("Test", "Test", "Test")]
        [InlineData(MockedRegistrationUserManager.ValidRegistrationUsername, "", "")]
        [InlineData(MockedRegistrationUserManager.ValidRegistrationUsername, " ", "")]
        [InlineData("Test", "", MockedRegistrationUserManager.ValidRegistrationPassword)]
        [InlineData(MockedRegistrationUserManager.ValidRegistrationUsername, MockedRegistrationUserManager.ValidRegistrationEmail, "")]
        [InlineData("Test", MockedRegistrationUserManager.ValidRegistrationEmail, MockedRegistrationUserManager.ValidRegistrationPassword)]
        public async Task Registration_ReturnsError_WithNotValidCredentials(string username, string email, string password)
        {
            var input = new RegisterUserInputModel()
            {
                FirstName = "First",
                LastName = "Last",
                Username = username,
                Email = email,
                Password = password,
                ConfirmPassword = password
            };
            var authService = new AuthService(_registrationUserManager, _jwtTokenProvider, _cartService);

            var result = await authService.Register(input);

            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task Login_ReturnsSuccess_WithValidCredentialsInput()
        {
            var input = new LoginUserInputModel(MockedLoginUserManager.ValidLoginUsername, MockedLoginUserManager.ValidLoginPassword);
            var authService = new AuthService(_loginUserManager, _jwtTokenProvider, _cartService);

            var result = await authService.Login(input);

            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("Test", "Test")]
        [InlineData(MockedLoginUserManager.ValidLoginUsername, "Test")]
        [InlineData("Test", MockedLoginUserManager.ValidLoginPassword)]
        public async Task Login_ReturnsError_WithNotValidCredentials(string username, string password)
        {
            var input = new LoginUserInputModel(username, password);
            var authService = new AuthService(_loginUserManager, _jwtTokenProvider, _cartService);

            var result = await authService.Login(input);

            Assert.False(result.Succeeded);
        }
    }
}
