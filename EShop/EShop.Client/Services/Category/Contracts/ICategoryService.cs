namespace EShop.Client.Services.Category.Contracts
{
    using Common.ApiResponse;

    using static EShop.Common.Models.Category.CategoryRecords;

    internal interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryOutputModel>>> GetCategories();
    }
}
