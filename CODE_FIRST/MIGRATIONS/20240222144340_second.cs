using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    contactLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    salesRepEmployeeNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    creditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.customerNumber);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    officeCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    territory = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.officeCode);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    orderNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    productCode = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: false),
                    quantityOrdered = table.Column<int>(type: "INT(11)", nullable: false),
                    priceEach = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    orderLineNumber = table.Column<short>(type: "smallint(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => new { x.orderNumber, x.productCode });
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    checkNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    paymentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => new { x.customerNumber, x.checkNumber });
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    orderNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(type: "Date", nullable: false),
                    requiredDate = table.Column<DateTime>(type: "Date", nullable: false),
                    shippedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    comments = table.Column<string>(type: "text", nullable: false),
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.orderNumber);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "CUSTOMERS",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    employeeNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    officeCode = table.Column<string>(type: "varchar(10)", maxLength: 50, nullable: false),
                    reportsTo = table.Column<int>(type: "INT(11)", nullable: false),
                    jobTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OfficesofficeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.employeeNumber);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_Offices_OfficesofficeCode",
                        column: x => x.OfficesofficeCode,
                        principalTable: "Offices",
                        principalColumn: "officeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                        column: x => x.reportsTo,
                        principalTable: "EMPLOYEES",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_OfficesofficeCode",
                table: "EMPLOYEES",
                column: "OfficesofficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_reportsTo",
                table: "EMPLOYEES",
                column: "reportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_customerNumber",
                table: "ORDERS",
                column: "customerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");
        }
    }
}
