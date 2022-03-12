namespace EShop.Validation.Authentication.RegistrationValidation
{
    using Common.Result;
    using Common.Entities;

    using Microsoft.AspNetCore.Identity;

    using static Common.Authentication.AuthenticationRecords;

    public class CreateUserValidationHandler : ResultHandler<RegisterUserInputModel, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result<AppUser>> Execute(RegisterUserInputModel model)
        {
            var appUser = new AppUser
            {
                Email = model.email,
                UserName = model.username,
                FirstName = model.firstName,
                LastName = model.lastName
            };

            var identityResult = await _userManager.CreateAsync(appUser, model.password);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(e => e.Description);
                return errors.ToList();
            }

            return appUser;
        }
    }
}
