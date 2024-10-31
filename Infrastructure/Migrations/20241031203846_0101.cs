using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _0101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oziq-ovqat" },
                    { 2, "Transport" },
                    { 3, "Mobil aloqa" },
                    { 4, "Internet" },
                    { 5, "O'yin-kulgi" }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Cost", "Description", "ExpenseCategoryId", "ExpenseDate" },
                values: new object[,]
                {
                    { 1, 10000m, "Fast food sotib olishga", 1, new DateTime(2024, 10, 31, 20, 38, 45, 978, DateTimeKind.Utc).AddTicks(8970) },
                    { 2, 5000m, "Metroda chipta sotib olish", 2, new DateTime(2024, 10, 31, 20, 38, 45, 978, DateTimeKind.Utc).AddTicks(9030) },
                    { 3, 1000m, "Telegram uchun to'lov", 3, new DateTime(2024, 10, 31, 20, 38, 45, 978, DateTimeKind.Utc).AddTicks(9040) },
                    { 4, 2000m, "PUBG o'ynash uchun", 4, new DateTime(2024, 10, 31, 20, 38, 45, 978, DateTimeKind.Utc).AddTicks(9040) },
                    { 5, 1000m, "Konsertga bilet sotib olish", 5, new DateTime(2024, 10, 31, 20, 38, 45, 978, DateTimeKind.Utc).AddTicks(9050) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Expenses",
                type: "text",
                nullable: true);
        }
    }
}
