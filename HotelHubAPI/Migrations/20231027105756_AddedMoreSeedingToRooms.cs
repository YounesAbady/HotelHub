using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingToRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "BranchId", "IsActive", "Price", "Quantity", "RoomName", "RoomTypeId" },
                values: new object[] { new Guid("50f6aa99-1f5d-4078-b373-79a895417df3"), new Guid("889ce330-e8cc-4ca0-ae88-424fe669eb50"), true, 1200.0, 25, "High Room", new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: new Guid("50f6aa99-1f5d-4078-b373-79a895417df3"));
        }
    }
}
