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
        public async Task<ApiResponse<ShoppingCartModel>> UpdateCartItems([FromBody] ShoppingCartItemRequest request)
        {
            var userId = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var userCart = await _cartService.GetShoppingCart(userId);

            await _cartService.AddProductToCart(userCart, request.ProductId);

            var shoppingCartResult = await _cartService.GetShoppingCart(user);

            if (shoppingCartResult.Failure)
            {
                return shoppingCartResult.ToErrorApiResponse();
            }

            return shoppingCartResult.ToApiResponse();
        }
    }
}
