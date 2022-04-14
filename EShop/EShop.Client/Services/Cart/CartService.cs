namespace EShop.Client.Services.Cart
{
    using Contracts;
    using Common.ApiResponse;
    using Blazored.LocalStorage;

    using static EShop.Common.Models.ShoppingCart.ShoppingcartRecords;

    internal class CartService : ApiService, ICartService
    {
        public CartService(
            HttpClient httpClient,
            ILocalStorageService localStorage) 
            : base(httpClient, localStorage) {}

        public async Task<ApiResponse<ShoppingCartModel>> UpdateCartItems(ShoppingCartItemRequest request)
            => await this.PostJson<ShoppingCartItemRequest, ShoppingCartModel>("api/Cart/UpdateCartItems", request);
    }
}
