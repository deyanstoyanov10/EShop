namespace EShop.Client.Services.Cart.Contracts
{
    using Common.ApiResponse;

    using static EShop.Common.Models.ShoppingCart.ShoppingcartRecords;

    internal interface ICartService
    {
        Task<ApiResponse<bool>> AddProductsToShoppingCart(ShoppingCartItemRequest request);
    }
}
