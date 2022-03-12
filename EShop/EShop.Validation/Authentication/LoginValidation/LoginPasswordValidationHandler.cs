namespace EShop.Validation.Authentication.LoginValidation
{
    using Common.Result;
    using Common.Entities;

    using Microsoft.AspNetCore.Identity;

    using static Common.Authentication.AuthenticationRecords;

    public class LoginPasswordValidationHandler : Handler<LoginUserInputModel>
    {
        private const string INVALID_CREDENTIALS_MESSAGE = "Invalid username or password.";

        private readonly UserManager<AppUser> _userManager;

        public LoginPasswordValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result> Execute(LoginUserInputModel model)
        {
            var user = await _userManager.FindByNameAsync(model.username);
            var passwordResult = await _userManager.CheckPasswordAsync(user, model.password);

            return passwordResult == false ? INVALID_CREDENTIALS_MESSAGE : true;
        }
    }
}
