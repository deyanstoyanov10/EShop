namespace EShop.API.Controllers
{
    using Common.ApiResponse;
    using Infrastructure.Extensions;
    using Services.Category.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using static EShop.Common.Models.Category.CategoryRecords;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet]
        [Route(nameof(GetCategories))]
        public async Task<ApiResponse<IEnumerable<CategoryOutputModel>>> GetCategories()
        {
            var result = await _categoryService.GetCategories();

            if (result.Failure)
            {
                return result.ToErrorApiResponse();
            }

            return result.ToApiResponse();
        }
    }
}
