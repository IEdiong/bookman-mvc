using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookman.Migrations
{
    public partial class RemoveBookFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 13, 16, 30, 3, 10, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 29, 16, 30, 3, 10, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 22, 16, 30, 3, 10, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 12, 16, 30, 3, 10, DateTimeKind.Local).AddTicks(2450));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 13, 14, 28, 12, 822, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 29, 14, 28, 12, 822, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 22, 14, 28, 12, 822, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 12, 14, 28, 12, 822, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
