using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingOrders.Dto;
using ShoppingOrders.Services;

namespace ShoppingOrders.Controllers
{
    // API Controller for handling product-related requests
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Endpoint to get products grouped by their categories
        [HttpGet("by-categories")]
        public IActionResult GetProductsByCategories()
        {
            List<CategoryWithProductsDto> products = _productService.GetProductsByCategories();
            return Ok(products);
        }
    }
}
