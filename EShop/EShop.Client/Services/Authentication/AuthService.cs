namespace EShop.Client.Services.Authentication
{
    using Contracts;
    using Common.ApiResponse;

    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;

    using static EShop.Common.Authentication.AuthenticationRecords;

    internal class AuthService : ApiService, IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(httpClient, localStorage) => _authenticationStateProvider = authenticationStateProvider;

        public async Task<ApiResponse<AppUserOutputModel>> Login(LoginUserInputModel loginModel)
        {
            var result = await this.PostJson<LoginUserInputModel, AppUserOutputModel>("api/Auth/Login", loginModel);

            if (result.Failure)
            {
                return result;
            }

            await this.SetJwtToken(result.Data.token);
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Username);

            return result;
        }

        public async Task<ApiResponse<AppUserOutputModel>> Register(RegisterUserInputModel registerModel)
        {
            var result = await this.PostJson<RegisterUserInputModel, AppUserOutputModel>("api/Auth/Register", registerModel);

            if (result.Failure)
            {
                return result;
            }

            await this.SetJwtToken(result.Data.token);
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(registerModel.Username);

            return result;
        }

        public async Task<bool> IsAuthenticated()
        {
            var authState = await ((AuthStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();

            if (authState.User.Identity == null)
            {
                return false;
            }

            return authState.User.Identity.IsAuthenticated;
        }

        public async Task Logout()
        {
            await this.RemoveJwtToken();
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        }
    }
}
