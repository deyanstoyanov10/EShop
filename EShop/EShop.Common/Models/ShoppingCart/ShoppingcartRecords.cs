namespace EShop.Common.Models.ShoppingCart
{
    public class ShoppingcartRecords
    {
        public class ShoppingCartItemModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public double Price { get; set; }

            public uint Quantity { get; set; }

            public double Amount
            {
                get
                {
                    return (double)Price * Quantity;
                }
                set
                {
                    this.Amount = value;
                }
            }

            public string ThumbnailPath { get; set; }
        }

        public class ShoppingCartModel
        {
            public int ShoppingCartId { get; set; }

            public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }

            public double Sum
            {
                get
                {
                    return this.ShoppingCartItems.Sum(x => x.Amount);
                }
                set
                {
                    this.Sum = value;
                }
            }
        }
    }
}
