namespace EShop.Services.Authentication.Contracts
{
    using Common.Result;
    using Common.Entities;

    using static EShop.Common.Authentication.AuthenticationRecords;

    public interface IAuthService
    {
        Task<Result<AppUser>> Register(RegisterUserInputModel registerInput);

        Task<Result<AppUserOutputModel>> Login(LoginUserInputModel loginInput);
    }
}
