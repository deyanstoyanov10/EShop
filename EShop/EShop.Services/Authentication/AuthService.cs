namespace EShop.Services.Authentication
{
    using Common.Result;
    using Common.Entities;
    using Providers.Contracts;
    using Authentication.Contracts;
    using Services.ShoppingCart.Contracts;
    using Validation.Authentication.LoginValidation;
    using Validation.Authentication.RegistrationValidation;

    using Microsoft.AspNetCore.Identity;

    using static Common.Authentication.AuthenticationRecords;

    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly ICartService _cartService;

        public AuthService(
            UserManager<AppUser> userManager,
            IJwtTokenProvider jwtTokenProvider,
            ICartService cartService)
        {
            _userManager = userManager;
            _jwtTokenProvider = jwtTokenProvider;
            _cartService = cartService;
        }

        public async Task<Result<AppUser>> Register(RegisterUserInputModel registerInput)
        {
            var handler = new EmailValidationHandler(_userManager);
            handler
                .SetNext(new UsernameValidationHandler(_userManager))
                .SetNext(new CreateUserValidationHandler(_userManager));

            var result = await handler.Execute(registerInput);

            if (result.Failure)
            {
                return result;
            }

            await _cartService.CreateShoppingCart(result.Data);

            return result;
        }

        public async Task<Result<AppUserOutputModel>> Login(LoginUserInputModel loginInput)
        {
            var appUser = await _userManager.FindByNameAsync(loginInput.Username);

            var handler = new LoginUsernameValidationHandler(_userManager);
            handler
                .SetNext(new LoginPasswordValidationHandler(_userManager));

            var result = await handler.Execute(loginInput);

            if (result.Failure)
                return result.Errors;

            var roles = await _userManager.GetRolesAsync(appUser);

            var token = _jwtTokenProvider.GenerateToken(appUser, roles);

            return new AppUserOutputModel(token);
        }
    }
}