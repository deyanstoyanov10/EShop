namespace EShop.Client.Services
{
    using Common;
    using Common.ApiResponse;

    using Blazored.LocalStorage;

    using System.Net.Http.Json;
    using System.Net.Http.Headers;

    internal abstract class ApiService
    {
        protected readonly string JWT_STORAGE_KEY = "jwtToken_v1";
        protected readonly HttpClient _httpClient;
        protected readonly ILocalStorageService _localStorage;

        private readonly string INTERNAL_ERROR_MESSAGE = "Internal Error";

        protected ApiService(
            HttpClient httpClient,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        protected async Task<ApiResponse<T>> GetJson<T>(string url)
        {
            var jwtToken = await this.GetJwtToken();

            if (isValidToken(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            try
            {
                var jsonObject = await _httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
                return jsonObject ?? new ApiResponse<T>(new List<Error> { new Error(INTERNAL_ERROR_MESSAGE) });
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(new List<Error> { new Error(ex.Message) });
            }
        }

        protected async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
        {
            var jwtToken = await this.GetJwtToken();

            if (isValidToken(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, request);
                var jsonObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
                return jsonObject ?? new ApiResponse<TResponse>(new List<Error> { new Error(INTERNAL_ERROR_MESSAGE) });
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(new List<Error> { new Error(ex.Message) });
            }
        }

        protected async Task<ApiResponse<TResponse>> PutJson<TRequest, TResponse>(string url, TRequest request)
        {
            var jwtToken = await this.GetJwtToken();

            if (isValidToken(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, request);
                var jsonObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
                return jsonObject ?? new ApiResponse<TResponse>(new List<Error> { new Error(INTERNAL_ERROR_MESSAGE) });
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(new List<Error> { new Error(ex.Message) });
            }
        }

        protected async Task<string> GetJwtToken()
            => await _localStorage.GetItemAsync<string>(JWT_STORAGE_KEY);

        protected async Task SetJwtToken(string jwtToken)
            => await _localStorage.SetItemAsync(JWT_STORAGE_KEY, jwtToken);

        protected async Task RemoveJwtToken()
            => await _localStorage.RemoveItemAsync(JWT_STORAGE_KEY);

        private bool isValidToken(string jwtToken)
            => !string.IsNullOrEmpty(jwtToken) || !string.IsNullOrWhiteSpace(jwtToken);
    }
}
