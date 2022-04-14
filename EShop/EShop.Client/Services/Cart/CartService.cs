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

        public async Task<ApiResponse<ShoppingCartModel>> GetShoppingCart()
            => await this.GetJson<ShoppingCartModel>("api/Cart/GetShoppingCart");

        public async Task<ApiResponse<ShoppingCartModel>> UpdateCartItems(int productId)
            => await this.PostJson<int, ShoppingCartModel>("api/Cart/UpdateCartItems", productId);

        public async Task<ApiResponse<ShoppingCartModel>> RemoveCartItem(int productId)
            => await this.PostJson<int, ShoppingCartModel>("api/Cart/RemoveCartItem", productId);
    }
}
