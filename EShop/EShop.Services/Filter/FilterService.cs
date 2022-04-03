namespace EShop.Services.Filter
{
    using Data;
    using Contracts;
    using Common.Result;

    using Microsoft.EntityFrameworkCore;

    using static EShop.Common.Models.Filter.FilterRecords;
    using static EShop.Common.Models.Option.OptionRecords;
    using static EShop.Common.Models.Search.SearchRecords;

    public class FilterService : IFilterService
    {
        private readonly ApplicationDbContext _data;

        public FilterService(ApplicationDbContext data) => _data = data;

        public async Task<Result<SearchModel>> GetSearchModel(int categoryId)
        {
            var searchModel = new SearchModel();

            var filters = await this.GetFiltersByCategoryId(categoryId);

            if (filters.Failure)
            {
                return searchModel;
            }

            searchModel.Filters = filters.Data;

            return searchModel;
        }

        private async Task<Result<IEnumerable<FilterModel>>> GetFiltersByCategoryId(int categoryId)
        {
            var filters = await _data
                                    .Filters
                                    .Include(o => o.Options)
                                    .Where(c => c.CategoryId == categoryId)
                                    .Select(f => new FilterModel() 
                                    {
                                        FilterId = f.Id,
                                        Label = f.Label,
                                        Options = f.Options
                                                        .Select(o => new OptionModel()
                                                        {
                                                            OptionId = o.Id,
                                                            Name = o.Name,
                                                            Active = false
                                                        })
                                                        .ToList()
                                    })
                                    .ToListAsync();

            return filters;
        }
    }
}
