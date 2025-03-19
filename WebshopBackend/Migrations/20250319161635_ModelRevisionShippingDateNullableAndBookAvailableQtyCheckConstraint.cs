using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebshopBackend.Migrations
{
    /// <inheritdoc />
    public partial class ModelRevisionShippingDateNullableAndBookAvailableQtyCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Book_AvailableQty",
                table: "Books",
                sql: "AvailableQty >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Book_AvailableQty",
                table: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
