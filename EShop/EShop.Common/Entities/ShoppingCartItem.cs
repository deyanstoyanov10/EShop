namespace EShop.Common.Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public uint Quantity { get; set; }
    }
}
