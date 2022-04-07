namespace EShop.Client.Services.Hub
{
    using Contracts;
    using EShop.Common.SocketResponse;
    using Microsoft.AspNetCore.SignalR.Client;

    using static EShop.Common.Models.Search.SearchRecords;
    using static EShop.Common.Models.Product.ProductRecords;

    internal class HubService : IHubService
    {
        private HubConnection? _hubConnection;

        private SearchModel searchModel = new SearchModel();
        private List<ProductOutputModel> productList = new List<ProductOutputModel>();

        public HubService()
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7030/productshub")
            .Build();

            _hubConnection.On<SocketResponse<SearchModel>>("TakeFilters", (response) =>
            {
                this.searchModel = response.Data;
            });

            _hubConnection.On<SocketResponse<IEnumerable<ProductOutputModel>>>("ReceiveProducts", (response) =>
            {
                this.productList = response.Data.ToList();
            });

            _hubConnection.StartAsync().Wait();
        }

        public SearchModel SearchModel
        {
            get
            {
                return this.searchModel;
            }
        }

        public List<ProductOutputModel> ProductList
        {
            get
            {
                return this.productList;
            }
        }

        public async Task GetFilters(int categoryId)
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.SendAsync("GetFilters", categoryId);
            }
        }

        public async Task UpdateProducts(int categoryId)
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.SendAsync("GetProducts", categoryId, this.searchModel);
            }
        }
    }
}
