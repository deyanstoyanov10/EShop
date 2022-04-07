namespace EShop.Common.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart() => this.ShoppingCartItems = new HashSet<ShoppingCartItem>();

        public int Id { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
