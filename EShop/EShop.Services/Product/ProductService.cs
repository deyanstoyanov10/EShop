namespace EShop.Services.Product
{
    using Data;
    using Contracts;
    using Common.Result;
    using Common.Helpers;
    using Common.Entities;

    using static Common.Models.Search.SearchRecords;
    using static Common.Models.Product.ProductRecords;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Linq.Expressions;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _data;

        public ProductService(ApplicationDbContext data) => _data = data;

        public async Task<Result<IEnumerable<ProductOutputModel>>> GetProducts(SearchModel search)
        {
            var predicate = BuildPredicate(search);

            var products = await _data
                                    .Products
                                    .Include(pic => pic.Pictures)
                                    .Include(po => po.ProductOptions)
                                    .Where(c => c.CategoryId == search.CategoryId)
                                    .Where(predicate)
                                    .Select(p => new ProductOutputModel()
                                    {
                                        ProductId = p.Id,
                                        Label = p.Label,
                                        Price = p.Price,
                                        Picture = p.Pictures
                                                        .OrderBy(x => x.Position)
                                                        .Select(x => x.FilePath)
                                                        .FirstOrDefault()
                                    })
                                    .ToListAsync();

            return products;
        }

        private Expression<Func<Product, bool>> BuildPredicate(SearchModel search)
        {
            var predicate = PredicateBuilder.True<Product>();

            foreach (var filter in search.Filters)
            {
                var filterPredicate = PredicateBuilder.False<Product>();
                int activeCount = 0;

                foreach (var option in filter.Options)
                {
                    if (option.Active)
                    {
                        filterPredicate = filterPredicate.Or(p => p.ProductOptions.Any(o => o.OptionId == option.OptionId));
                        ++activeCount;
                    }
                }

                if (activeCount > 0)
                {
                    predicate = predicate.And(filterPredicate);
                }
                
            }

            return predicate;
        }
    }
}
