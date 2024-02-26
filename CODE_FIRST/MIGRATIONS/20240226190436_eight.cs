using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_Offices_OfficesofficeCode",
                table: "EMPLOYEES");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                table: "EMPLOYEES");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerNumber",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEES_OfficesofficeCode",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "OfficesofficeCode",
                table: "EMPLOYEES");

            migrationBuilder.AlterColumn<int>(
                name: "customerNumber",
                table: "ORDERS",
                type: "INT(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT(11)");

            migrationBuilder.AlterColumn<string>(
                name: "comments",
                table: "ORDERS",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "reportsTo",
                table: "EMPLOYEES",
                type: "INT(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT(11)");

            migrationBuilder.AlterColumn<int>(
                name: "salesRepEmployeeNumber",
                table: "CUSTOMERS",
                type: "INT(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT(11)");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_officeCode",
                table: "EMPLOYEES",
                column: "officeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "salesRepEmployeeNumber",
                principalTable: "EMPLOYEES",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_Offices_officeCode",
                table: "EMPLOYEES",
                column: "officeCode",
                principalTable: "Offices",
                principalColumn: "officeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                table: "EMPLOYEES",
                column: "reportsTo",
                principalTable: "EMPLOYEES",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerNumber",
                table: "ORDERS",
                column: "customerNumber",
                principalTable: "CUSTOMERS",
                principalColumn: "customerNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_Offices_officeCode",
                table: "EMPLOYEES");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                table: "EMPLOYEES");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerNumber",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEES_officeCode",
                table: "EMPLOYEES");

            migrationBuilder.AlterColumn<int>(
                name: "customerNumber",
                table: "ORDERS",
                type: "INT(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comments",
                table: "ORDERS",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "reportsTo",
                table: "EMPLOYEES",
                type: "INT(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT(11)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficesofficeCode",
                table: "EMPLOYEES",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "salesRepEmployeeNumber",
                table: "CUSTOMERS",
                type: "INT(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT(11)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_OfficesofficeCode",
                table: "EMPLOYEES",
                column: "OfficesofficeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "salesRepEmployeeNumber",
                principalTable: "EMPLOYEES",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_Offices_OfficesofficeCode",
                table: "EMPLOYEES",
                column: "OfficesofficeCode",
                principalTable: "Offices",
                principalColumn: "officeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                table: "EMPLOYEES",
                column: "reportsTo",
                principalTable: "EMPLOYEES",
                principalColumn: "employeeNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_CUSTOMERS_customerNumber",
                table: "ORDERS",
                column: "customerNumber",
                principalTable: "CUSTOMERS",
                principalColumn: "customerNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
