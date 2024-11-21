using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingOrders.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToOrders", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductToOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Home Essentials" },
                    { 2, "Dairy Products" },
                    { 3, "Fruits and Vegetables" },
                    { 4, "Meat and Fish" },
                    { 5, "Bakery" },
                    { 6, "Cosmetics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Laundry Detergent", 15.00m },
                    { 2, 1, "Paper Towels", 5.00m },
                    { 3, 1, "Dish Soap", 10.00m },
                    { 4, 1, "Trash Bags", 8.00m },
                    { 5, 1, "Light Bulbs", 12.00m },
                    { 6, 2, "Milk", 6.00m },
                    { 7, 2, "Yogurt", 4.00m },
                    { 8, 2, "Cheese (Cheddar)", 20.00m },
                    { 9, 2, "Butter", 7.00m },
                    { 10, 2, "Cream", 8.00m },
                    { 11, 3, "Apples", 3.00m },
                    { 12, 3, "Bananas", 2.00m },
                    { 13, 3, "Tomatoes", 5.00m },
                    { 14, 3, "Carrots", 4.00m },
                    { 15, 3, "Potatoes", 6.00m },
                    { 16, 4, "Chicken Breast", 25.00m },
                    { 17, 4, "Ground Beef", 35.00m },
                    { 18, 4, "Salmon Fillet", 50.00m },
                    { 19, 4, "Lamb Chops", 60.00m },
                    { 20, 4, "Shrimp", 45.00m },
                    { 21, 5, "White Bread", 5.00m },
                    { 22, 5, "Whole Wheat Bread", 6.00m },
                    { 23, 5, "Bagels", 7.00m },
                    { 24, 5, "Croissants", 10.00m },
                    { 25, 5, "Muffins", 8.00m },
                    { 26, 6, "Shampoo", 20.00m },
                    { 27, 6, "Conditioner", 22.00m },
                    { 28, 6, "Face Cream", 50.00m },
                    { 29, 6, "Lipstick", 30.00m },
                    { 30, 6, "Nail Polish", 15.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToOrders_ProductId",
                table: "ProductToOrders",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductToOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
