using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_productCode",
                table: "ORDERDETAILS",
                column: "productCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_ORDERS_orderNumber",
                table: "ORDERDETAILS",
                column: "orderNumber",
                principalTable: "ORDERS",
                principalColumn: "orderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_productCode",
                table: "ORDERDETAILS",
                column: "productCode",
                principalTable: "PRODUCTS",
                principalColumn: "productCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_ORDERS_orderNumber",
                table: "ORDERDETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERDETAILS_PRODUCTS_productCode",
                table: "ORDERDETAILS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERDETAILS_productCode",
                table: "ORDERDETAILS");
        }
    }
}
