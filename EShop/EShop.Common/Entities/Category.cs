namespace EShop.Common.Entities
{
    public class Category
    {
        public Category()
        {
            this.Filters = new HashSet<Filter>();
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Filter> Filters { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
