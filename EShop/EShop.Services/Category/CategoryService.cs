namespace EShop.Services.Category
{
    using Data;
    using Common.Result;
    using Services.Category.Contracts;

    using Microsoft.EntityFrameworkCore;

    using static EShop.Common.Models.Category.CategoryRecords;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _data;

        public CategoryService(ApplicationDbContext data) => _data = data;

        public async Task<Result<IEnumerable<CategoryOutputModel>>> GetCategories()
            => await _data
                        .Categories
                        .Select(c => new CategoryOutputModel(c.Id, c.Name))
                        .ToListAsync();
    }
}
