namespace EShop.Services.Product.Contracts
{
    using Common.Result;

    using static Common.Models.Search.SearchRecords;
    using static Common.Models.Product.ProductRecords;

    public interface IProductService
    {
        Task<Result<IEnumerable<ProductOutputModel>>> GetProducts(SearchModel search);
    }
}
