using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.ApiDbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "US", "United States" },
                    { 2, "CA", "Canada" },
                    { 3, "UK", "United Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "CountryId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("08a46f84-2890-4919-b2c8-250d5b0faed4"), false, 3, "Bob Johnson", "Designer" },
                    { new Guid("09854b8b-35d4-4d0e-91d0-ecb28eab4114"), false, 3, "Bob Johnson", "Designer" },
                    { new Guid("b7d05a95-0833-4639-a8fb-8df9e907e3e4"), true, 2, "Jane Smith", "Project Manager" },
                    { new Guid("bb15db35-74c6-4310-9ea9-77ef7e8f2ee2"), true, 1, "John Doe", "Software Engineer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("08a46f84-2890-4919-b2c8-250d5b0faed4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("09854b8b-35d4-4d0e-91d0-ecb28eab4114"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b7d05a95-0833-4639-a8fb-8df9e907e3e4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("bb15db35-74c6-4310-9ea9-77ef7e8f2ee2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
