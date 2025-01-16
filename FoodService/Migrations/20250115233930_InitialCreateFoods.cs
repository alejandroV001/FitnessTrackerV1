using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<double>(type: "double precision", nullable: false),
                    Proteins = table.Column<double>(type: "double precision", nullable: false),
                    Carbs = table.Column<double>(type: "double precision", nullable: false),
                    Fats = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFoods_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Carbs", "Fats", "Name", "Proteins" },
                values: new object[,]
                {
                    { 1, 165.0, 0.0, 3.6000000000000001, "Chicken Breast", 31.0 },
                    { 2, 130.0, 28.0, 0.29999999999999999, "Rice", 2.7000000000000002 },
                    { 3, 55.0, 11.199999999999999, 0.59999999999999998, "Broccoli", 3.7000000000000002 },
                    { 4, 155.0, 1.1000000000000001, 10.6, "Eggs", 13.0 },
                    { 5, 86.0, 20.100000000000001, 0.10000000000000001, "Sweet Potato", 1.6000000000000001 },
                    { 6, 579.0, 21.600000000000001, 49.899999999999999, "Almonds", 21.199999999999999 },
                    { 7, 59.0, 3.6000000000000001, 0.40000000000000002, "Greek Yogurt", 10.0 },
                    { 8, 160.0, 8.5, 14.699999999999999, "Avocado", 2.0 },
                    { 9, 208.0, 0.0, 13.0, "Salmon", 20.0 },
                    { 10, 23.0, 3.6000000000000001, 0.40000000000000002, "Spinach", 2.8999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Date", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Breakfast", 1 },
                    { 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Lunch", 1 },
                    { 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Dinner", 1 },
                    { 4, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Breakfast", 2 },
                    { 5, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Lunch", 2 },
                    { 6, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Dinner", 2 },
                    { 7, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Breakfast", 3 },
                    { 8, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Lunch", 3 },
                    { 9, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Dinner", 3 },
                    { 10, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Breakfast", 1 }
                });

            migrationBuilder.InsertData(
                table: "MealFoods",
                columns: new[] { "Id", "FoodId", "MealId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 4, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 2 },
                    { 5, 9, 3 },
                    { 6, 5, 3 },
                    { 7, 7, 4 },
                    { 8, 6, 4 },
                    { 9, 8, 5 },
                    { 10, 9, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFoods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
