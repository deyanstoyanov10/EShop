namespace EShop.Common.Models.Search
{
    using static Filter.FilterRecords;

    public class SearchRecords
    {
        public record SearchInputModel(IEnumerable<FilterInputModel> filters);
    }
}
