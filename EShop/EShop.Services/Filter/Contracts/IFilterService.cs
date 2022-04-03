namespace EShop.Services.Filter.Contracts
{
    using Common.Result;

    //using static EShop.Common.Models.Filter.FilterRecords;
    using static EShop.Common.Models.Search.SearchRecords;

    public interface IFilterService
    {
        Task<Result<SearchModel>> GetSearchModel(int categoryId);

        //Task<Result<IEnumerable<FilterModel>>> GetFiltersByCategoryId(int categoryId);
    }
}
