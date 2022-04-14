namespace EShop.Validation.Authentication.RegistrationValidation
{
    using Common.Result;
    using Common.Entities;

    using Microsoft.AspNetCore.Identity;

    using static EShop.Common.Authentication.AuthenticationRecords;

    public class EmailValidationHandler : ResultHandler<RegisterUserInputModel, AppUser>
    {
        private const string EMAIL_ALREADY_EXIST_MESSAGE = "Email already exists.";

        private readonly UserManager<AppUser> _userManager;

        public EmailValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result<AppUser>> Execute(RegisterUserInputModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            return user is not null ? EMAIL_ALREADY_EXIST_MESSAGE : await _next.Execute(model);
        }
    }
}
