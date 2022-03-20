namespace EShop.Services.Category.Contracts
{
    using Common.Result;

    using static Common.Models.Category.CategoryRecords;

    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryOutputModel>>> GetCategories();
    }
}
