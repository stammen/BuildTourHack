using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.Knowzy.Domain.Data.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Customers",
                table => new
                {
                    Id = table.Column<string>(),
                    Address = table.Column<string>(),
                    CompanyName = table.Column<string>(),
                    ContactPerson = table.Column<string>(),
                    Email = table.Column<string>(),
                    PhoneNumber = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "PostalCarriers",
                table => new
                {
                    Id = table.Column<int>(),
                    Name = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCarriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<string>(),
                    Category = table.Column<string>(),
                    Description = table.Column<string>(),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(),
                    Price = table.Column<decimal>(),
                    QuantityInStock = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Order",
                table => new
                {
                    Id = table.Column<string>(),
                    Address = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OrderType = table.Column<string>(),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostalCarrierId = table.Column<int>(),
                    Status = table.Column<int>(),
                    StatusUpdated = table.Column<DateTime>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: true),
                    Tracking = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        "FK_Order_Customers_CustomerId",
                        x => x.CustomerId,
                        "Customers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Order_PostalCarriers_PostalCarrierId",
                        x => x.PostalCarrierId,
                        "PostalCarriers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "OrderLines",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(),
                    ProductId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderLines_Order_OrderId",
                        x => x.OrderId,
                        "Order",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_OrderLines_Products_ProductId",
                        x => x.ProductId,
                        "Products",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Order_CustomerId",
                "Order",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Order_PostalCarrierId",
                "Order",
                "PostalCarrierId");

            migrationBuilder.CreateIndex(
                "IX_OrderLines_OrderId",
                "OrderLines",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_OrderLines_ProductId",
                "OrderLines",
                "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "OrderLines");

            migrationBuilder.DropTable(
                "Order");

            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "Customers");

            migrationBuilder.DropTable(
                "PostalCarriers");
        }
    }
}
