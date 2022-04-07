namespace EShop.Common.Entities
{
    public class Product
    {
        public Product()
        {
            this.Pictures = new HashSet<Picture>();
            this.ProductOptions = new HashSet<ProductOption>();
            this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool Active { get; set; }

        public DateTime Added { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
