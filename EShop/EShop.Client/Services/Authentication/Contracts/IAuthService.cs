namespace EShop.Client.Services.Authentication.Contracts
{
    using Common.ApiResponse;

    using static EShop.Common.Authentication.AuthenticationRecords;

    internal interface IAuthService
    {
        Task<ApiResponse<AppUserOutputModel>> Login(LoginUserInputModel loginModel);

        Task Logout();
    }
}
