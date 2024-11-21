using Microsoft.EntityFrameworkCore;
using ShoppingOrders.Data;
using ShoppingOrders.Modales;

namespace ShoppingOrders.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
        List<Category> GetCategoriesWithProducts();

    }

    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingOrdersContext _context;

        public ProductRepository(ShoppingOrdersContext context)
        {
            _context = context;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Category) // זה מאפשר לך גם גישה לקטגוריה של המוצר
                .FirstOrDefault(p => p.Id == productId);
        }
        public List<Category> GetCategoriesWithProducts()
        {
            return _context.Categories
                .Include(c => c.Products)
                .ToList();
        }

    }
}

