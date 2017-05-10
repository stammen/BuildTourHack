using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.Knowzy.Domain.Data.Migrations
{
    public partial class BasicModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    Number = table.Column<string>(),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Number);
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
                "Order",
                table => new
                {
                    OrderNumber = table.Column<string>(),
                    Address = table.Column<string>(),
                    CompanyName = table.Column<string>(),
                    ContactPerson = table.Column<string>(),
                    Email = table.Column<string>(),
                    OrderType = table.Column<string>(),
                    PhoneNumber = table.Column<string>(),
                    PostalCarrierId = table.Column<int>(),
                    Status = table.Column<int>(),
                    Tracking = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderNumber);
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
                    ItemNumber = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(),
                    Quantity = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderLines_Items_ItemNumber",
                        x => x.ItemNumber,
                        "Items",
                        "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_OrderLines_Order_OrderNumber",
                        x => x.OrderNumber,
                        "Order",
                        "OrderNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Order_PostalCarrierId",
                "Order",
                "PostalCarrierId");

            migrationBuilder.CreateIndex(
                "IX_OrderLines_ItemNumber",
                "OrderLines",
                "ItemNumber");

            migrationBuilder.CreateIndex(
                "IX_OrderLines_OrderNumber",
                "OrderLines",
                "OrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "OrderLines");

            migrationBuilder.DropTable(
                "Items");

            migrationBuilder.DropTable(
                "Order");

            migrationBuilder.DropTable(
                "PostalCarriers");
        }
    }
}
