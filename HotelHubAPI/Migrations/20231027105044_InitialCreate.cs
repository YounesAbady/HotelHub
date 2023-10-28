using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rooms_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "branch_pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_branch_pictures_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rooms_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rooms_rooms_types_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "rooms_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserved_rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservedRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserved_rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reserved_rooms_reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reserved_rooms_rooms_ReservedRoomId",
                        column: x => x.ReservedRoomId,
                        principalTable: "rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "rooms_pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms_pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rooms_pictures_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "Id", "BranchDescription", "BranchLocation", "BranchPhoneNumber", "BranchPictureURL", "IsActive" },
                values: new object[,]
                {
                    { new Guid("889ce330-e8cc-4ca0-ae88-424fe669eb50"), "Step into the timeless charm of Luxor, the world's greatest open-air museum. Our hotel in Luxor is a gateway to ancient wonders, including the Valley of the Kings and Karnak Temple. Relax in comfortable rooms, savor authentic cuisine, and experience the mystique of this historical city.", "Luxor", "789", "/pictures/luxor-branch.jpg", true },
                    { new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"), "Discover the magic of Cairo from our centrally located hotel in the bustling capital of Egypt. With easy access to iconic attractions like the Giza Pyramids and Egyptian Museum, you're in the perfect spot for exploring this vibrant city. Our modern accommodations and world-class amenities ensure a memorable stay.", "Cairo", "123", "/pictures/cairo-branch.jpg", true },
                    { new Guid("f0b3bf0f-a861-4f5a-b7cd-97304b0266a9"), "Nestled along the serene banks of the Nile River in Aswan, our hotel offers a tranquil escape in the heart of ancient Egypt. Enjoy breathtaking views of the river and nearby historic sites. Our comfortable rooms, attentive service, and fine dining options make your stay unforgettable.", "Aswan", "456", "/pictures/aswan-branch.jpg", true }
                });

            migrationBuilder.InsertData(
                table: "rooms_types",
                columns: new[] { "Id", "Beds", "IsActive", "Occupancy", "RoomDescription", "RoomSize", "RoomType" },
                values: new object[,]
                {
                    { new Guid("4206b6ad-8df2-447a-869b-6ad9bd2bab43"), "1 Queen or 2 Twins", true, "2 Adults and 1 Child", "The Standard Room offers a comfortable and cozy stay with a choice of one queen bed or two twin beds. It's perfect for couples or small families looking for a relaxing retreat.", "Approximately 300 square feet (27.87 square meters)", "Standard Room" },
                    { new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb"), "2 King Beds and 2 Twin Beds", true, "6 Adults or 4 Adults and 2 Children", "The Ocean View Villa is a luxurious and expansive accommodation with two king beds and two twin beds. It provides breathtaking views of the ocean and ample space for larger groups or families.", "Approximately 1,200 square feet (111.48 square meters)", "Ocean View Villa" },
                    { new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043"), "1 King and 1 Sofa Bed", true, "3 Adults or 2 Adults and 2 Children", "The Deluxe Suite is a spacious and elegant room featuring a king-size bed and a sofa bed. It's an excellent choice for families or guests who desire extra space and comfort during their stay.", "Approximately 450 square feet (41.81 square meters)", "Deluxe Suite" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_branch_pictures_BranchId",
                table: "branch_pictures",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_BranchId",
                table: "reservations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_reserved_rooms_ReservationId",
                table: "reserved_rooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_reserved_rooms_ReservedRoomId",
                table: "reserved_rooms",
                column: "ReservedRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_BranchId",
                table: "rooms",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomTypeId",
                table: "rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_pictures_RoomId",
                table: "rooms_pictures",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "branch_pictures");

            migrationBuilder.DropTable(
                name: "reserved_rooms");

            migrationBuilder.DropTable(
                name: "rooms_pictures");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "rooms_types");
        }
    }
}
