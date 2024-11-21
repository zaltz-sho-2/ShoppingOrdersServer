namespace ShoppingOrders.Dto
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public List<ProductInOrderDto> Products { get; set; }

    }
    public class ProductInOrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}


