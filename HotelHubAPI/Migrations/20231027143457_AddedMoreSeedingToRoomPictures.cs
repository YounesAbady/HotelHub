using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingToRoomPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "rooms_pictures",
                columns: new[] { "Id", "IsActive", "RoomId", "RoomPictureURL" },
                values: new object[,]
                {
                    { new Guid("9a95e2ca-23d0-4174-811c-07748a175c41"), true, new Guid("032dc455-373f-4abe-a7ae-503f06ce6fad"), "/pictures/room3.jpg" },
                    { new Guid("c1f69e3f-cbe5-46a0-84c3-31f9d60190ee"), true, new Guid("2f92199d-eba5-45d2-a990-44156279707b"), "/pictures/room1.jpg" },
                    { new Guid("e790ae12-6cf7-4fea-be89-3cbda1232467"), true, new Guid("2f92199d-eba5-45d2-a990-44156279707b"), "/pictures/room1-1.jpg" },
                    { new Guid("f1daf1ed-cab7-4e37-b655-86250f78619b"), true, new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), "/pictures/room2-2.jpg" },
                    { new Guid("f676a55a-0c72-4b56-8c33-17bcbd44e085"), true, new Guid("032dc455-373f-4abe-a7ae-503f06ce6fad"), "/pictures/room3-3.jpg" },
                    { new Guid("f7998109-db7e-463d-917e-250465fa0e9a"), true, new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), "/pictures/room2.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("9a95e2ca-23d0-4174-811c-07748a175c41"));

            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("c1f69e3f-cbe5-46a0-84c3-31f9d60190ee"));

            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("e790ae12-6cf7-4fea-be89-3cbda1232467"));

            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f1daf1ed-cab7-4e37-b655-86250f78619b"));

            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f676a55a-0c72-4b56-8c33-17bcbd44e085"));

            migrationBuilder.DeleteData(
                table: "rooms_pictures",
                keyColumn: "Id",
                keyValue: new Guid("f7998109-db7e-463d-917e-250465fa0e9a"));
        }
    }
}
