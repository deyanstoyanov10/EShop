namespace EShop.Services.Filter.Contracts
{
    using Common.Result;

    using static EShop.Common.Models.Filter.FilterRecords;

    public interface IFilterService
    {
        Task<Result<IEnumerable<FilterModel>>> GetFiltersByCategoryId(int categoryId);
    }
}
