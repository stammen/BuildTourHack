using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.Knowzy.Domain.Data.Migrations
{
    [DbContext(typeof(KnowzyContext))]
    class KnowzyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("ContactPerson")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Order", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Address");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("OrderType")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PostalCarrierId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("StatusUpdated");

                    b.Property<DateTime?>("TimeStamp");

                    b.Property<string>("Tracking")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PostalCarrierId");

                    b.ToTable("Order");

                    b.HasDiscriminator<string>("OrderType").HasValue("Order");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.PostalCarrier", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PostalCarriers");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Product", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("QuantityInStock")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Receiving", b =>
                {
                    b.HasBaseType("Microsoft.Knowzy.Domain.Order");


                    b.ToTable("Receiving");

                    b.HasDiscriminator().HasValue("Receiving");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Shipping", b =>
                {
                    b.HasBaseType("Microsoft.Knowzy.Domain.Order");


                    b.ToTable("Shipping");

                    b.HasDiscriminator().HasValue("Shipping");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Order", b =>
                {
                    b.HasOne("Microsoft.Knowzy.Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Microsoft.Knowzy.Domain.PostalCarrier", "PostalCarrier")
                        .WithMany("Orders")
                        .HasForeignKey("PostalCarrierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.OrderLine", b =>
                {
                    b.HasOne("Microsoft.Knowzy.Domain.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("Microsoft.Knowzy.Domain.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId");
                });
        }
    }
}
