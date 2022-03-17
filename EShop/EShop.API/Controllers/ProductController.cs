﻿namespace EShop.API.Controllers
{
    using Common.ApiResponse;
    using Infrastructure.Extensions;
    using Services.Product.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using static Common.Models.Product.ProductRecords;
    using static Common.Models.Search.SearchRecords;

    public class ProductController : EShopController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        [Route(nameof(GetProducts))]
        public async Task<ApiResponse<IEnumerable<ProductOutputModel>>> GetProducts([FromBody] SearchInputModel search)
        {
            var result = await _productService.GetProducts(search);

            if (result.Failure)
            {
                return result.ToErrorApiResponse();
            }

            return result.ToApiResponse();
        }
    }
}
