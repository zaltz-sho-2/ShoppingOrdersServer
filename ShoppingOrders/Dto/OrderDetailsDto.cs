namespace ShoppingOrders.Dto
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductDetailsDto> Products { get; set; } = new List<ProductDetailsDto>();

    }
}
