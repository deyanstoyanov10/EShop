namespace EShop.Common.Entities
{
    public class Product
    {
        public Product() => this.ProductOptions = new HashSet<ProductOption>();

        public int Id { get; set; }

        public string Label { get; set; }

        public bool Status { get; set; }

        public DateTime Added { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
