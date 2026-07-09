using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.ApiDbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddSeederss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "CountryId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9741"), true, 1, "John Doe", "Software Engineer" },
                    { new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9742"), true, 2, "Jane Smith", "Project Manager" },
                    { new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9743"), false, 3, "Bob Johnson", "Designer" },
                    { new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9744"), false, 3, "Bob Johnson", "Designer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9741"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9742"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9743"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9744"));

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
    }
}
