using Microsoft.AspNetCore.Mvc;
using ShoppingOrders.Dto;
using ShoppingOrders.Services;

namespace ShoppingOrders.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        // Constructor to inject the IOrderService dependency
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Endpoint to create a new order
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            // If the model is invalid, return a BadRequest response
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Create order using the service method
                var orderDetails = _orderService.CreateOrder(
                    request.CustomerName,
                    request.CustomerAddress,
                    request.CustomerEmail,
                    request.Products);

                // Return the order details with a 200 OK status
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 Internal Server Error with the exception message
                return StatusCode(500, $"Error creating order: {ex.Message}");
            }
        }

        // Endpoint to get orders by customer email
        [HttpGet("by-email")]
        public IActionResult GetOrdersByCustomerEmail([FromQuery] string customerEmail)
        {
            try
            {
                var orders = _orderService.GetOrdersByCustomerEmail(customerEmail);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
