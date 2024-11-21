using System.ComponentModel.DataAnnotations;

namespace ShoppingOrders.Modales
{
    public class ProductToOrder
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }


    }
}
