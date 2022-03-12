namespace EShop.Common.Models.Option
{
    public class OptionRecords
    {
        public record OptionInputModel(int optionId, string name, bool active);
    }
}
