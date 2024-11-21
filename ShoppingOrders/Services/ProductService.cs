using ShoppingOrders.Dto;
using ShoppingOrders.Repositories;

namespace ShoppingOrders.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<CategoryWithProductsDto> GetProductsByCategories()
        {
            var categories = _productRepository.GetCategoriesWithProducts();

            return categories.Select(c => new CategoryWithProductsDto
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                Products = c.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            }).ToList();
        }
    }
}
