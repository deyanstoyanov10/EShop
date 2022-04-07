namespace EShop.Common.Models.Search
{
    using static Filter.FilterRecords;

    public class SearchRecords
    {
        public record SearchInputModel(IEnumerable<FilterInputModel> filters);

        public class SearchModel
        {
            public SearchModel() => this.Filters = new List<FilterModel>();

            public int CategoryId { get; set; }

            public IEnumerable<FilterModel> Filters { get; set; }
        }
    }
}
