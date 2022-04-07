namespace EShop.Client.Services.Hub.Contracts
{
    internal interface IHubService
    {
        Task GetFilters(int categoryId);

        Task UpdateProducts(int categoryId);
    }
}
