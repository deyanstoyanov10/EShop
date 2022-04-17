namespace EShop.Services.Product.Contracts
{
    using Common.Result;
    using Common.Entities;

    using static Common.Models.Search.SearchRecords;
    using static Common.Models.Product.ProductRecords;

    public interface IProductService
    {
        Task<Result<Product>> GetProductById(int productId);

        Task<Result<IEnumerable<ProductOutputModel>>> GetTopProducts(int take = 10);

        Task<Result<IEnumerable<ProductOutputModel>>> GetProducts(SearchModel search);
    }
}
