using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "HashedPassword", "IsActive", "Username" },
                values: new object[] { new Guid("e0e0e0f8-3de6-40f7-a31b-c5793fb15875"), "AQAAAAIAAYagAAAAELNvpov5kcsPLipcypnIJ1RaTf2mu3sLSt6jNzIYhzoIqghcYAUz5V9yF+AwILz/FA==", true, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("e0e0e0f8-3de6-40f7-a31b-c5793fb15875"));
        }
    }
}
