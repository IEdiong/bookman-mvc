using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookman.Migrations
{
    public partial class AddDbConstriant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 2, 8, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9630), new DateTime(2023, 2, 8, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 24, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9690), new DateTime(2023, 8, 24, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 17, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9690), new DateTime(2023, 8, 17, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 8, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9700), new DateTime(2023, 7, 8, 14, 34, 20, 97, DateTimeKind.Local).AddTicks(9710) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 2, 8, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(4970), new DateTime(2023, 2, 8, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 24, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5000), new DateTime(2023, 8, 24, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 17, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5010), new DateTime(2023, 8, 17, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 8, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5010), new DateTime(2023, 7, 8, 14, 16, 4, 569, DateTimeKind.Local).AddTicks(5030) });
        }
    }
}
