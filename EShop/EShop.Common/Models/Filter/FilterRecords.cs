namespace EShop.Common.Models.Filter
{
    using static Option.OptionRecords;

    public class FilterRecords
    {
        public record FilterInputModel(int filterId, string label, IEnumerable<OptionInputModel> options);

        public class FilterModel
        {
            public int FilterId { get; set; }

            public string Label { get; set; }

            public IEnumerable<OptionModel> Options { get; set; }
        }
    }
}
