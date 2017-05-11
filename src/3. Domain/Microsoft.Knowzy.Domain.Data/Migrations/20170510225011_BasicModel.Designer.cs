using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.Knowzy.Domain.Data.Migrations
{
    [DbContext(typeof(KnowzyContext))]
    [Migration("20170510225011_BasicModel")]
    partial class BasicModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Item", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<decimal>("Price");

                    b.HasKey("Number");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.Order", b =>
                {
                    b.Property<string>("OrderNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("ContactPerson")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("OrderType")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("PostalCarrierId");

                    b.Property<int>("Status");

                    b.Property<string>("Tracking")
                        .IsRequired();

                    b.HasKey("OrderNumber");

                    b.HasIndex("PostalCarrierId");

                    b.ToTable("Order");

                    b.HasDiscriminator<string>("OrderType").HasValue("Order");
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemNumber");

                    b.Property<string>("OrderNumber");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemNumber");

                    b.HasIndex("OrderNumber");

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
                    b.HasOne("Microsoft.Knowzy.Domain.PostalCarrier", "PostalCarrier")
                        .WithMany("Orders")
                        .HasForeignKey("PostalCarrierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.Knowzy.Domain.OrderLine", b =>
                {
                    b.HasOne("Microsoft.Knowzy.Domain.Item", "Item")
                        .WithMany("OrderLines")
                        .HasForeignKey("ItemNumber");

                    b.HasOne("Microsoft.Knowzy.Domain.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderNumber");
                });
        }
    }
}
