namespace EShop.Validation.Authentication.LoginValidation
{
    using Common.Result;
    using Common.Entities;

    using Microsoft.AspNetCore.Identity;

    using static Common.Authentication.AuthenticationRecords;

    public class LoginUsernameValidationHandler : Handler<LoginUserInputModel>
    {
        private const string INVALID_CREDENTIALS_MESSAGE = "Invalid username or password.";

        private readonly UserManager<AppUser> _userManager;

        public LoginUsernameValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result> Execute(LoginUserInputModel model)
        {
            var user = await _userManager.FindByNameAsync(model.username);

            return user is null ? INVALID_CREDENTIALS_MESSAGE : await _next.Execute(model);
        }
    }
}
