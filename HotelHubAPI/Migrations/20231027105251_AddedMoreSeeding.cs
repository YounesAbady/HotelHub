using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "BranchId", "IsActive", "Price", "Quantity", "RoomName", "RoomTypeId" },
                values: new object[,]
                {
                    { new Guid("032dc455-373f-4abe-a7ae-503f06ce6fad"), new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"), true, 1200.0, 25, "High Room", new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb") },
                    { new Guid("2f92199d-eba5-45d2-a990-44156279707b"), new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"), true, 400.0, 50, "Normal Room", new Guid("4206b6ad-8df2-447a-869b-6ad9bd2bab43") },
                    { new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"), true, 800.0, 150, "Med Room", new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: new Guid("032dc455-373f-4abe-a7ae-503f06ce6fad"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: new Guid("2f92199d-eba5-45d2-a990-44156279707b"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247"));
        }
    }
}
