namespace EShop.Common.Models.Filter
{
    using static Option.OptionRecords;

    public class FilterRecords
    {
        public record FilterInputModel(int filterId, string label, IEnumerable<OptionInputModel> options);
    }
}
