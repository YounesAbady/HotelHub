using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingToReservationAndReservedToom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "Id", "BranchId", "EndDate", "IsActive", "StartDate", "TotalPrice" },
                values: new object[] { new Guid("9bf23105-ce1c-41ad-bf6c-b491d10986b1"), new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0 });

            migrationBuilder.InsertData(
                table: "reserved_rooms",
                columns: new[] { "Id", "IsActive", "ReservationId", "ReservedRoomId" },
                values: new object[,]
                {
                    { new Guid("46936b6d-d806-4bf5-8d76-4918f33cb682"), true, new Guid("9bf23105-ce1c-41ad-bf6c-b491d10986b1"), new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247") },
                    { new Guid("f00ac58f-b2e6-4cea-9534-401384a0809e"), true, new Guid("9bf23105-ce1c-41ad-bf6c-b491d10986b1"), new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reserved_rooms",
                keyColumn: "Id",
                keyValue: new Guid("46936b6d-d806-4bf5-8d76-4918f33cb682"));

            migrationBuilder.DeleteData(
                table: "reserved_rooms",
                keyColumn: "Id",
                keyValue: new Guid("f00ac58f-b2e6-4cea-9534-401384a0809e"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "Id",
                keyValue: new Guid("9bf23105-ce1c-41ad-bf6c-b491d10986b1"));
        }
    }
}
