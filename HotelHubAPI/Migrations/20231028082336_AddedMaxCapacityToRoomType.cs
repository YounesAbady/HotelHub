using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaxCapacityToRoomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxCapacityAdults",
                table: "rooms_types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacityChilds",
                table: "rooms_types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "rooms_types",
                keyColumn: "Id",
                keyValue: new Guid("4206b6ad-8df2-447a-869b-6ad9bd2bab43"),
                columns: new[] { "MaxCapacityAdults", "MaxCapacityChilds" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "rooms_types",
                keyColumn: "Id",
                keyValue: new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb"),
                columns: new[] { "MaxCapacityAdults", "MaxCapacityChilds", "Occupancy" },
                values: new object[] { 6, 2, "6 Adults and 2 Children" });

            migrationBuilder.UpdateData(
                table: "rooms_types",
                keyColumn: "Id",
                keyValue: new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043"),
                columns: new[] { "MaxCapacityAdults", "MaxCapacityChilds", "Occupancy" },
                values: new object[] { 3, 2, "3 Adults and 2 Children" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCapacityAdults",
                table: "rooms_types");

            migrationBuilder.DropColumn(
                name: "MaxCapacityChilds",
                table: "rooms_types");

            migrationBuilder.UpdateData(
                table: "rooms_types",
                keyColumn: "Id",
                keyValue: new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb"),
                column: "Occupancy",
                value: "6 Adults or 4 Adults and 2 Children");

            migrationBuilder.UpdateData(
                table: "rooms_types",
                keyColumn: "Id",
                keyValue: new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043"),
                column: "Occupancy",
                value: "3 Adults or 2 Adults and 2 Children");
        }
    }
}
