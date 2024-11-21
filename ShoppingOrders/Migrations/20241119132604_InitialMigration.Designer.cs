﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingOrders.Data;

#nullable disable

namespace ShoppingOrders.Migrations
{
    [DbContext(typeof(ShoppingOrdersContext))]
    [Migration("20241119132604_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingOrders.Modales.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Home Essentials"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dairy Products"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fruits and Vegetables"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Meat and Fish"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cosmetics"
                        });
                });

            modelBuilder.Entity("ShoppingOrders.Modales.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoppingOrders.Modales.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Laundry Detergent",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Paper Towels",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Dish Soap",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Name = "Trash Bags",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Name = "Light Bulbs",
                            Price = 12.00m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Milk",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Name = "Yogurt",
                            Price = 4.00m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Name = "Cheese (Cheddar)",
                            Price = 20.00m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Name = "Butter",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Name = "Cream",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Name = "Apples",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Name = "Bananas",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Name = "Tomatoes",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Name = "Carrots",
                            Price = 4.00m
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Name = "Potatoes",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Name = "Chicken Breast",
                            Price = 25.00m
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Name = "Ground Beef",
                            Price = 35.00m
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Name = "Salmon Fillet",
                            Price = 50.00m
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Name = "Lamb Chops",
                            Price = 60.00m
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Name = "Shrimp",
                            Price = 45.00m
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            Name = "White Bread",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            Name = "Whole Wheat Bread",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            Name = "Bagels",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 5,
                            Name = "Croissants",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 5,
                            Name = "Muffins",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 6,
                            Name = "Shampoo",
                            Price = 20.00m
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 6,
                            Name = "Conditioner",
                            Price = 22.00m
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 6,
                            Name = "Face Cream",
                            Price = 50.00m
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 6,
                            Name = "Lipstick",
                            Price = 30.00m
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 6,
                            Name = "Nail Polish",
                            Price = 15.00m
                        });
                });

            modelBuilder.Entity("ShoppingOrders.Modales.ProductToOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductToOrders");
                });

            modelBuilder.Entity("ShoppingOrders.Modales.Product", b =>
                {
                    b.HasOne("ShoppingOrders.Modales.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingOrders.Modales.ProductToOrder", b =>
                {
                    b.HasOne("ShoppingOrders.Modales.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingOrders.Modales.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingOrders.Modales.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingOrders.Modales.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}