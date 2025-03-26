﻿// <auto-generated />
using System;
using Catalog.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(SampleCatalogDbContext))]
    partial class SampleCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Domain.Category", b =>
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
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Accessories"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CampaignInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Iphone 12",
                            Price = 10000m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Samsung S21",
                            Price = 9000m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Xiaomi Mi 11",
                            Price = 8000m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "T-shirt",
                            Price = 100m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "Polo neck",
                            Price = 150m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Shirt",
                            Price = 200m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "Watch",
                            Price = 500m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Name = "Necklace",
                            Price = 300m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Name = "Earrings",
                            Price = 200m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Name = "Bracelet",
                            Price = 150m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Name = "Hat",
                            Price = 50m,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Product", b =>
                {
                    b.HasOne("Catalog.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Catalog.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
