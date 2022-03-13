namespace EShop.Client.Services.Authentication
{
    using Common;
    using Contracts;
    using Common.ApiResponse;

    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;

    using System.Net.Http.Json;
    using System.Net.Http.Headers;

    using static EShop.Common.Authentication.AuthenticationRecords;

    internal class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<ApiResponse<AppUserOutputModel>> Login(LoginUserInputModel loginModel)
        {
            var result = await this.PostJson<LoginUserInputModel, AppUserOutputModel>("api/Auth/Login", loginModel);

            if (result.Failure)
            {
                return result;
            }

            await _localStorage.SetItemAsync("jwtToken_v1", result.Data.token);
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Username);

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("jwtToken_v1");
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        private async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
        {
            var token = await _localStorage.GetItemAsync<string>("jwtToken_v1");

            if (!string.IsNullOrEmpty(token) || !string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, request);
                var jsonObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
                return jsonObject;
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(new List<Error> { new Error(ex.Message) });
            }
        }
    }
}
