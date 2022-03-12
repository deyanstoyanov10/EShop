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

        public async Task<Result<IEnumerable<ProductOutputModel>>> GetProducts(SearchInputModel search)
        {
            var predicate = BuildPredicate(search);

            var products = await _data
                                    .Products
                                    .Include(po => po.ProductOptions)
                                    .Where(predicate)
                                    .Select(p => new ProductOutputModel(p.Id, p.Label))
                                    .ToListAsync();

            return products;
        }

        private Expression<Func<Product, bool>> BuildPredicate(SearchInputModel search)
        {
            var predicate = PredicateBuilder.True<Product>();

            foreach (var filter in search.filters)
            {
                var filterPredicate = PredicateBuilder.False<Product>();
                int activeCount = 0;

                foreach (var option in filter.options)
                {
                    if (option.active)
                    {
                        filterPredicate = filterPredicate.Or(p => p.ProductOptions.Any(o => o.OptionId == option.optionId));
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
