using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class tableandtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalProduction = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionHistory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductionHistory",
                columns: new[] { "Id", "Price", "TotalProduction" },
                values: new object[,]
                {
                    { new Guid("37df7e04-9966-4466-95d5-7575312360b7"), 49.495678m, 72.879476m },
                    { new Guid("4165021b-6ea4-42af-95a0-c7f5c73d2a5a"), 49.495678m, 72.879476m },
                    { new Guid("5063a8a3-ccd0-4343-80ef-30bff16624d6"), 0.124333m, 34.555556m },
                    { new Guid("7a68206d-0ea7-4792-894e-79485d04b0b7"), 49.495678m, 72.879434m },
                    { new Guid("917e4e59-22e0-41b1-8b7f-7c4ee1db720c"), 98.343434m, 12.326547m },
                    { new Guid("a97a7106-be2e-451b-b81f-94d137bbc636"), 49.495673m, 72.879476m },
                    { new Guid("c7d3f097-7906-4683-85b7-7255f22f5f5c"), 49.495673m, 72.873435m },
                    { new Guid("ecb8ef4c-73c1-4018-a5fb-c9c2fe1091ee"), 49.495678m, 72.879435m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionHistory");
        }
    }
}
