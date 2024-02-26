using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_PAYMENTS_CUSTOMERS_customerNumber",
                table: "PAYMENTS",
                column: "customerNumber",
                principalTable: "CUSTOMERS",
                principalColumn: "customerNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAYMENTS_CUSTOMERS_customerNumber",
                table: "PAYMENTS");
        }
    }
}
