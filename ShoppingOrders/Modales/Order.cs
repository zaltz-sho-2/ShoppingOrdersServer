using System.ComponentModel.DataAnnotations;

namespace ShoppingOrders.Modales
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required, EmailAddress]
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }



        // קשר לטבלה המקשרת
        public ICollection<ProductToOrder> OrderProducts { get; set; } = new List<ProductToOrder>();

    }
}
