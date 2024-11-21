using Microsoft.EntityFrameworkCore;
using ShoppingOrders.Modales;

namespace ShoppingOrders.Data
{
    // DbContext for the shopping orders application
    public class ShoppingOrdersContext : DbContext
    {
        public ShoppingOrdersContext(DbContextOptions<ShoppingOrdersContext> options) : base(options)
        {
        }

        // DbSets for each entity representing tables in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductToOrder> ProductToOrders { get; set; }

        // Configures entity relationships and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining primary keys for entities
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);

            // Defining composite key for ProductToOrder
            modelBuilder.Entity<ProductToOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId }); // Composite primary key

            // Defining relationships between ProductToOrder and Order
            modelBuilder.Entity<ProductToOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(po => po.OrderId);

            // Defining relationships between ProductToOrder and Product
            modelBuilder.Entity<ProductToOrder>()
                .HasOne(po => po.Product)
                .WithMany()
                .HasForeignKey(po => po.ProductId);

            // Defining relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Seed data for Categories (initial data to populate the database)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Home Essentials" },
                new Category { Id = 2, Name = "Dairy Products" },
                new Category { Id = 3, Name = "Fruits and Vegetables" },
                new Category { Id = 4, Name = "Meat and Fish" },
                new Category { Id = 5, Name = "Bakery" },
                new Category { Id = 6, Name = "Cosmetics" }
            );

            // Seed data for Products, assigning them to categories
            modelBuilder.Entity<Product>().HasData(
                // Products in Home Essentials category
                new Product { Id = 1, Name = "Laundry Detergent", Price = 15.00m, CategoryId = 1 },
                new Product { Id = 2, Name = "Paper Towels", Price = 5.00m, CategoryId = 1 },
                new Product { Id = 3, Name = "Dish Soap", Price = 10.00m, CategoryId = 1 },
                new Product { Id = 4, Name = "Trash Bags", Price = 8.00m, CategoryId = 1 },
                new Product { Id = 5, Name = "Light Bulbs", Price = 12.00m, CategoryId = 1 },

                // Products in Dairy Products category
                new Product { Id = 6, Name = "Milk", Price = 6.00m, CategoryId = 2 },
                new Product { Id = 7, Name = "Yogurt", Price = 4.00m, CategoryId = 2 },
                new Product { Id = 8, Name = "Cheese (Cheddar)", Price = 20.00m, CategoryId = 2 },
                new Product { Id = 9, Name = "Butter", Price = 7.00m, CategoryId = 2 },
                new Product { Id = 10, Name = "Cream", Price = 8.00m, CategoryId = 2 },

                // Products in Fruits and Vegetables category
                new Product { Id = 11, Name = "Apples", Price = 3.00m, CategoryId = 3 },
                new Product { Id = 12, Name = "Bananas", Price = 2.00m, CategoryId = 3 },
                new Product { Id = 13, Name = "Tomatoes", Price = 5.00m, CategoryId = 3 },
                new Product { Id = 14, Name = "Carrots", Price = 4.00m, CategoryId = 3 },
                new Product { Id = 15, Name = "Potatoes", Price = 6.00m, CategoryId = 3 },

                // Products in Meat and Fish category
                new Product { Id = 16, Name = "Chicken Breast", Price = 25.00m, CategoryId = 4 },
                new Product { Id = 17, Name = "Ground Beef", Price = 35.00m, CategoryId = 4 },
                new Product { Id = 18, Name = "Salmon Fillet", Price = 50.00m, CategoryId = 4 },
                new Product { Id = 19, Name = "Lamb Chops", Price = 60.00m, CategoryId = 4 },
                new Product { Id = 20, Name = "Shrimp", Price = 45.00m, CategoryId = 4 },

                // Products in Bakery category
                new Product { Id = 21, Name = "White Bread", Price = 5.00m, CategoryId = 5 },
                new Product { Id = 22, Name = "Whole Wheat Bread", Price = 6.00m, CategoryId = 5 },
                new Product { Id = 23, Name = "Bagels", Price = 7.00m, CategoryId = 5 },
                new Product { Id = 24, Name = "Croissants", Price = 10.00m, CategoryId = 5 },
                new Product { Id = 25, Name = "Muffins", Price = 8.00m, CategoryId = 5 },

                // Products in Cosmetics category
                new Product { Id = 26, Name = "Shampoo", Price = 20.00m, CategoryId = 6 },
                new Product { Id = 27, Name = "Conditioner", Price = 22.00m, CategoryId = 6 },
                new Product { Id = 28, Name = "Face Cream", Price = 50.00m, CategoryId = 6 },
                new Product { Id = 29, Name = "Lipstick", Price = 30.00m, CategoryId = 6 },
                new Product { Id = 30, Name = "Nail Polish", Price = 15.00m, CategoryId = 6 }
            );
        }
    }
}
