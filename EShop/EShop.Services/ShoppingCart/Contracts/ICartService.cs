namespace EShop.Services.ShoppingCart.Contracts
{
    using Common.Entities;

    public interface ICartService
    {
        Task CreateShoppingCart(AppUser user);
    }
}
