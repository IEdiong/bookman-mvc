using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookman.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name", "Price", "Year" },
                values: new object[,]
                {
                    { 1, "Vnicom Hub", "This book covers the basics of C#.", "Basics of C# Language", 5000m, 2021 },
                    { 2, "Ade Ogunsanya", "Want to learn how to sing fuji jazz, then this book is for you.", "Fuji Music", 2000m, 1998 },
                    { 3, "Ediong Joseph", "This book helps you master the basics of backend development with the C# language.", "Introduction to Backend development in C#", 10000m, 2023 },
                    { 4, "Ediong Joseph", "This book helps you master the basics of frontend developement with Angular.", "Introduction to Frontend development with Angular", 10500m, 2023 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
