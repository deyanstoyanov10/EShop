namespace EShop.Services.ShoppingCart.Contracts
{
    using Common.Result;
    using Common.Entities;

    using static Common.Models.ShoppingCart.ShoppingcartRecords;

    public interface ICartService
    {
        Task<ShoppingCartModel> GetShoppingCart(AppUser user);

        Task CreateShoppingCart(AppUser user);

        Task<Result<bool>> AddProductToCart(ShoppingCart cart, int productId);
    }
}
