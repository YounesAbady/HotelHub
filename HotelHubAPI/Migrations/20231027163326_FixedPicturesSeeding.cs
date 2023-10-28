using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FixedPicturesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f1daf1ed-cab7-4e37-b655-86250f78619b"),
                column: "RoomPictureURL",
                value: "/pictures/room2-1.jpg");

            migrationBuilder.UpdateData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f676a55a-0c72-4b56-8c33-17bcbd44e085"),
                column: "RoomPictureURL",
                value: "/pictures/room3-1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f1daf1ed-cab7-4e37-b655-86250f78619b"),
                column: "RoomPictureURL",
                value: "/pictures/room2-2.jpg");

            migrationBuilder.UpdateData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f676a55a-0c72-4b56-8c33-17bcbd44e085"),
                column: "RoomPictureURL",
                value: "/pictures/room3-3.jpg");
        }
    }
}
