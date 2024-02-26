using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_salesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "salesRepEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "salesRepEmployeeNumber",
                principalTable: "EMPLOYEES",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_salesRepEmployeeNumber",
                table: "CUSTOMERS");
        }
    }
}
