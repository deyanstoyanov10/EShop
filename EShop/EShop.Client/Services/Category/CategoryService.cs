namespace EShop.Client.Services.Category
{
    using Contracts;
    using Common.ApiResponse;
    using Blazored.LocalStorage;

    using System.Net.Http;

    using static EShop.Common.Models.Category.CategoryRecords;

    internal class CategoryService : ApiService, ICategoryService
    {
        public CategoryService(
            HttpClient httpClient,
            ILocalStorageService localStorage) 
            : base(httpClient, localStorage) {}

        public async Task<ApiResponse<IEnumerable<CategoryOutputModel>>> GetCategories()
            => await this.GetJson<IEnumerable<CategoryOutputModel>>("api/Category/GetCategories");
    }
}
