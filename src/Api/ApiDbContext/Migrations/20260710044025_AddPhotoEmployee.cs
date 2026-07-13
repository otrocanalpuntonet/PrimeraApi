using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.ApiDbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9741"),
                column: "FotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9742"),
                column: "FotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9743"),
                column: "FotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67f3b154-5ef9-4acd-ae15-6e04b6db9744"),
                column: "FotoUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Employees");
        }
    }
}
