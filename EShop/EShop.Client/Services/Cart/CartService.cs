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

        public async Task<ApiResponse<bool>> AddProductsToShoppingCart(ShoppingCartItemRequest request)
            => await this.PostJson<ShoppingCartItemRequest, bool>("api/Cart/AddProduct", request);
    }
}
