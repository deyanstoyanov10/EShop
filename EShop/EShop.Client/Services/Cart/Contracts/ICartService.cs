namespace EShop.Client.Services.Cart.Contracts
{
    using Common.ApiResponse;

    using static EShop.Common.Models.ShoppingCart.ShoppingcartRecords;

    internal interface ICartService
    {
        Task<ApiResponse<ShoppingCartModel>> UpdateCartItems(int productId);

        Task<ApiResponse<ShoppingCartModel>> RemoveCartItem(int productId);
    }
}
