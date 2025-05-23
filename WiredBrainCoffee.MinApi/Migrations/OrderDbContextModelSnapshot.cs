﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

#nullable disable

namespace WiredBrainCoffee.MinApi.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WiredBrainCoffee.MinApi.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromoCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CustomerName = "John Doe",
                            Description = "A coffee order",
                            OrderNumber = 100,
                            PromoCode = "Wired123",
                            Total = 25m
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CustomerName = "Jane Smith",
                            Description = "A food order",
                            OrderNumber = 125,
                            PromoCode = "Wired123",
                            Total = 35m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
