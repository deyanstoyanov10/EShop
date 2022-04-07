namespace EShop.API.Hubs
{
    using Infrastructure.Extensions;
    using Services.Filter.Contracts;
    using Services.Product.Contracts;

    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Caching.Memory;

    using static EShop.Common.Models.Search.SearchRecords;

    public class ProductsHub : Hub
    {
        private readonly IMemoryCache _cache;
        private readonly IFilterService _filterService;
        private readonly IProductService _productService;

        public ProductsHub(
            IMemoryCache cache,
            IFilterService filterService,
            IProductService productService)
        {
            _cache = cache;
            _filterService = filterService;
            _productService = productService;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task GetFilters(int categoryId)
        {
            var result = await _filterService.GetSearchModel(categoryId);

            if (result.Failure)
            {
                await Clients.Caller.SendAsync("ReceiveFilters", result.ToErrorSocketResponse());
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveFilters", result.ToSocketResponse());
            }
        }

        public async Task GetProducts(SearchModel searchModel)
        {
            var result = await _productService.GetProducts(searchModel);

            if (result.Failure)
            {
                await Clients.Caller.SendAsync("ReceiveProducts", result.ToErrorSocketResponse());
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveProducts", result.ToSocketResponse());
            }
        }
    }
}
