using ShoppingOrders.Dto;
using ShoppingOrders.Modales;

namespace ShoppingOrders.Services
{
    public interface IOrderService
    {
        List<OrderDetailsDto> GetOrdersByCustomerEmail(string customerEmail);

        OrderDetailsDto CreateOrder(string customerName, string customerAddress, string customerEmail, List<ProductInOrderDto> products);

    }
}
