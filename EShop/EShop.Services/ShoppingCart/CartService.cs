namespace EShop.Services.ShoppingCart
{
    using Data;
    using Contracts;
    using Common.Result;
    using Common.Entities;
    using Product.Contracts;

    using Microsoft.EntityFrameworkCore;

    using static Common.Models.ShoppingCart.ShoppingcartRecords;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _data;
        private readonly IProductService _productService;

        public CartService(
            ApplicationDbContext data,
            IProductService productService)
        {
            _data = data;
            _productService = productService;
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            var shoppingCart = await _data
                                        .ShoppingCarts
                                        .FirstOrDefaultAsync(x => x.AppUserId == userId);

            return shoppingCart;
        }

        public async Task<Result<ShoppingCartModel>> GetShoppingCart(AppUser user)
        {
            var userCart = await this.GetShoppingCart(user.Id);

            var items = await this.GetShoppingCartItems(userCart.Id);

            var shoppingCart = await _data
                                        .ShoppingCarts
                                        .Where(x => x.AppUserId == user.Id)
                                        .Select(x => new ShoppingCartModel()
                                        {
                                            ShoppingCartItems = items.ToList()
                                        })
                                        .FirstOrDefaultAsync();

            return shoppingCart;
        }

        public async Task CreateShoppingCart(AppUser user)
        {
            var shoppingCart = new ShoppingCart()
            {
                AppUser = user
            };

            await _data.AddAsync(shoppingCart);
            await _data.SaveChangesAsync();
        }

        public async Task<Result<bool>> AddProductToCart(ShoppingCart cart, int productId)
        {
            var result = await _productService.GetProductById(productId);

            if (result.Failure)
            {
                return result.Errors;
            }

            var item = await _data
                                .ShoppingCartItems
                                .Where(x => x.ShoppingCartId == cart.Id && x.ProductId == productId)
                                .FirstOrDefaultAsync();

            if (item is not null)
            {
                item.Quantity += 1;

                await _data.SaveChangesAsync();

                return true;
            }
            else
            {
                var shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCart = cart,
                    Product = result.Data,
                    Quantity = 1
                };

                await _data.AddAsync(shoppingCartItem);
                await _data.SaveChangesAsync();

                return true;
            }
        }

        public async Task RemoveCartItem(ShoppingCart cart, int productId)
        {
            var shoppingCartItem = await _data
                                            .ShoppingCartItems
                                            .Where(x => x.ShoppingCartId == cart.Id && x.ProductId == productId)
                                            .FirstOrDefaultAsync();

            if (shoppingCartItem is not null)
            {
                _data.ShoppingCartItems.Remove(shoppingCartItem);

                await _data.SaveChangesAsync();
            }
        }

        private async Task<IEnumerable<ShoppingCartItemModel>> GetShoppingCartItems(int shoppingCartId)
            => await _data
                        .ShoppingCartItems
                        .Include(x => x.Product)
                        .Include(x => x.Product.Pictures)
                        .Where(x => x.ShoppingCartId == shoppingCartId)
                        .Select(x => new ShoppingCartItemModel()
                        {
                            ProductId = x.ProductId,
                            ProductName = x.Product.Label,
                            Price = x.Product.Price,
                            Quantity = x.Quantity,
                            ThumbnailPath = x.Product
                                                    .Pictures
                                                    .OrderBy(x => x.Position)
                                                    .FirstOrDefault().FilePath ?? "https://user-images.githubusercontent.com/101482/29592647-40da86ca-875a-11e7-8bc3-941700b0a323.png"
                        })
                        .ToListAsync();
    }                   
}
