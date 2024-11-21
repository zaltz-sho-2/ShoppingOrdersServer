using ShoppingOrders.Dto;
using ShoppingOrders.Modales;

namespace ShoppingOrders.Services
{
    public interface IProductService
    {
        List<CategoryWithProductsDto> GetProductsByCategories();

    }
}
