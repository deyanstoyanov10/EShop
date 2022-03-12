namespace EShop.Validation.Authentication.RegistrationValidation
{
    using Common.Result;
    using Common.Entities;

    using Microsoft.AspNetCore.Identity;

    using static EShop.Common.Authentication.AuthenticationRecords;

    public class UsernameValidationHandler : ResultHandler<RegisterUserInputModel, AppUser>
    {
        private const string USERNAME_ALREADY_EXIST_MESSAGE = "Username already exists.";

        private readonly UserManager<AppUser> _userManager;

        public UsernameValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result<AppUser>> Execute(RegisterUserInputModel model)
        {
            var user = await _userManager.FindByNameAsync(model.username);

            return user is not null ? USERNAME_ALREADY_EXIST_MESSAGE : await _next.Execute(model);
        }
    }
}
