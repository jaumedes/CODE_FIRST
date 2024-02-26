using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST.Migrations
{
    public partial class nineth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "image",
                table: "PRODUCTLINES",
                type: "mediumblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "mediumblob");

            migrationBuilder.AlterColumn<string>(
                name: "htmlDescription",
                table: "PRODUCTLINES",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "image",
                table: "PRODUCTLINES",
                type: "mediumblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "mediumblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "htmlDescription",
                table: "PRODUCTLINES",
                type: "mediumtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true);
        }
    }
}
