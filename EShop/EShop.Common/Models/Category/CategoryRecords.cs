namespace EShop.Common.Models.Category
{
    public class CategoryRecords
    {
        public record CategoryOutputModel(int CategoryId, string Name);

        public record GetFiltersByCategoryMessage(int CategoryId);
    }
}
