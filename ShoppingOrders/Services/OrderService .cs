using ShoppingOrders.Dto;
using ShoppingOrders.Modales;
using ShoppingOrders.Repositories;
using ShoppingOrders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public OrderDetailsDto CreateOrder(string customerName, string customerAddress, string customerEmail, List<ProductInOrderDto> products)
    {
        var order = new Order
        {
            CustomerName = customerName,
            CustomerAddress = customerAddress,
            CustomerEmail = customerEmail,
            OrderDate = DateTime.Now,
            OrderProducts = products.Select(p => new ProductToOrder
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        };

        decimal totalPrice = 0;

        foreach (var product in order.OrderProducts)
        {
            var productFromDb = _productRepository.GetProductById(product.ProductId);
            if (productFromDb == null)
            {
                throw new Exception($"Product with ID {product.ProductId} not found.");
            }
            totalPrice += productFromDb.Price * product.Quantity;
        }

        order.TotalPrice = totalPrice;

        var savedOrder = _orderRepository.AddOrder(order);

        return new OrderDetailsDto
        {
            Id = savedOrder.Id,
            CustomerName = savedOrder.CustomerName,
            CustomerAddress = savedOrder.CustomerAddress,
            CustomerEmail = savedOrder.CustomerEmail,
            OrderDate = savedOrder.OrderDate,
            TotalPrice = savedOrder.TotalPrice,
            Products = savedOrder.OrderProducts.Select(op => new ProductDetailsDto
            {
                ProductId = op.ProductId,
                ProductName = op.Product.Name,
                Price = op.Product.Price,
                Quantity = op.Quantity
            }).ToList()
        };
    }

    public List<OrderDetailsDto> GetOrdersByCustomerEmail(string customerEmail)
    {
        var orders = _orderRepository.GetOrdersByCustomerEmail(customerEmail);

        return orders.Select(order => new OrderDetailsDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            CustomerAddress = order.CustomerAddress,
            CustomerEmail = order.CustomerEmail,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Products = order.OrderProducts.Select(op => new ProductDetailsDto
            {
                ProductId = op.ProductId,
                ProductName = op.Product.Name,
                Price = op.Product.Price,
                Quantity = op.Quantity
            }).ToList()
        }).ToList();
    }
}
