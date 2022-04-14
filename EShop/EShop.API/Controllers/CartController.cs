namespace EShop.API.Controllers
{
    using API.Hubs;
    using Common.Entities;
    using Common.ApiResponse;
    using Infrastructure.Extensions;
    using Services.ShoppingCart.Contracts;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    using static EShop.Common.Models.ShoppingCart.ShoppingcartRecords;
    using System.Security.Claims;

    [Authorize]
    public class CartController : ApiController
    {
        private readonly ICartService _cartService;
        private readonly IHubContext<ProductsHub> _hub;
        private readonly UserManager<AppUser> _userManager;

        public CartController(
            ICartService cartService,
            IHubContext<ProductsHub> hub,
            UserManager<AppUser> userManager)
        {
            _cartService = cartService;
            _hub = hub;
            _userManager = userManager;
        }

        [HttpPost]
        [Route(nameof(AddProduct))]
        public async Task<ApiResponse<bool>> AddProduct([FromBody] ShoppingCartItemRequest request)
        {
            var userId = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var userCart = await _cartService.GetShoppingCartByUserId(userId);

            var result = await _cartService.AddProductToCart(userCart, request.ProductId);

            if (result.Failure)
            {
                return result.ToErrorApiResponse();
            }

            var shoppingCartResult = await _cartService.GetShoppingCart(user);

            await _hub.Clients.Client(request.ConnectionId).SendAsync("UpdateCartItems", shoppingCartResult.ToSocketResponse());

            return result.ToApiResponse();
        }
    }
}
