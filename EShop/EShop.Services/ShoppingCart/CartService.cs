namespace EShop.Services.ShoppingCart
{
    using Data;
    using Contracts;
    using Common.Entities;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _data;

        public CartService(ApplicationDbContext data) => _data = data;

        public async Task CreateShoppingCart(AppUser user)
        {
            var shoppingCart = new ShoppingCart()
            {
                AppUser = user
            };

            await _data.AddAsync(shoppingCart);
            await _data.SaveChangesAsync();
        }
    }
}
