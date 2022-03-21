namespace EShop.Common.Models.Option
{
    public class OptionRecords
    {
        public record OptionInputModel(int optionId, string name, bool active);

        public class OptionModel
        {
            public int OptionId { get; set; }

            public string Name { get; set; }

            public bool Active { get; set; }
        }
    }
}
