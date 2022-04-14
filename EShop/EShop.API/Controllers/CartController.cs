namespace EShop.API.Controllers
{
    using Common.Entities;
    using Common.ApiResponse;
    using Infrastructure.Extensions;
    using Services.ShoppingCart.Contracts;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    using System.Security.Claims;

    using static Common.Models.ShoppingCart.ShoppingcartRecords;

    [Authorize]
    public class CartController : ApiController
    {
        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;

        public CartController(
            ICartService cartService,
            UserManager<AppUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route(nameof(UpdateCartItems))]
        public async Task<ApiResponse<ShoppingCartModel>> UpdateCartItems([FromBody] int productId)
        {
            var userId = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var userCart = await _cartService.GetShoppingCart(userId);

            await _cartService.AddProductToCart(userCart, productId);

            var user = await _userManager.FindByIdAsync(userId);

            return await GetUserShoppingCart(user);
        }

        [HttpPost]
        [Route(nameof(RemoveCartItem))]
        public async Task<ApiResponse<ShoppingCartModel>> RemoveCartItem([FromBody] int productId)
        {
            var userId = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var userCart = await _cartService.GetShoppingCart(userId);

            await _cartService.RemoveCartItem(userCart, productId);

            var user = await _userManager.FindByIdAsync(userId);

            return await GetUserShoppingCart(user);
        }

        private async Task<ApiResponse<ShoppingCartModel>> GetUserShoppingCart(AppUser user)
        {
            var shoppingCartResult = await _cartService.GetShoppingCart(user);

            if (shoppingCartResult.Failure)
            {
                return shoppingCartResult.ToErrorApiResponse();
            }

            return shoppingCartResult.ToApiResponse();
        }
    }
}
