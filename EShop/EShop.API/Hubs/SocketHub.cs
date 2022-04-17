namespace EShop.API.Hubs
{
    using Infrastructure.Extensions;
    using Services.Filter.Contracts;
    using Services.Product.Contracts;

    using Microsoft.AspNetCore.SignalR;

    using static EShop.Common.Models.Search.SearchRecords;

    public class SocketHub : Hub
    {
        private readonly IFilterService _filterService;
        private readonly IProductService _productService;

        public SocketHub(
            IFilterService filterService,
            IProductService productService)
        {
            _filterService = filterService;
            _productService = productService;
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

        public async Task GetTopProducts(int take = 10)
        {
            var result = await _productService.GetTopProducts(take);

            if (result.Failure)
            {
                await Clients.Caller.SendAsync("ReceiveTopProducts", result.ToErrorSocketResponse());
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveTopProducts", result.ToSocketResponse());
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
