using Microsoft.EntityFrameworkCore;
using ShoppingOrders.Data;
using ShoppingOrders.Modales;

namespace ShoppingOrders.Repositories
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        List<Order> GetOrdersByCustomerEmail(string customerEmail);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingOrdersContext _context;

        public OrderRepository(ShoppingOrdersContext context)
        {
            _context = context;
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public List<Order> GetOrdersByCustomerEmail(string customerEmail)
        {
            return _context.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Where(o => o.CustomerEmail == customerEmail)
                .ToList();
        }
    }
}
