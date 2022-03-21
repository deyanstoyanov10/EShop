namespace EShop.API.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class ProductsHub : Hub
    {
        public async Task GetFilters(int categoryId)
        {
            await Clients.Caller.SendAsync("TakeFilters", "");
        }
    }
}
