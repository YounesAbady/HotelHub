﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(HHContext))]
    [Migration("20231027105756_AddedMoreSeedingToRooms")]
    partial class AddedMoreSeedingToRooms
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admins", (string)null);
                });

            modelBuilder.Entity("Models.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BranchDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchPictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("branches", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0b3bf0f-a861-4f5a-b7cd-97304b0266a9"),
                            BranchDescription = "Nestled along the serene banks of the Nile River in Aswan, our hotel offers a tranquil escape in the heart of ancient Egypt. Enjoy breathtaking views of the river and nearby historic sites. Our comfortable rooms, attentive service, and fine dining options make your stay unforgettable.",
                            BranchLocation = "Aswan",
                            BranchPhoneNumber = "456",
                            BranchPictureURL = "/pictures/aswan-branch.jpg",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"),
                            BranchDescription = "Discover the magic of Cairo from our centrally located hotel in the bustling capital of Egypt. With easy access to iconic attractions like the Giza Pyramids and Egyptian Museum, you're in the perfect spot for exploring this vibrant city. Our modern accommodations and world-class amenities ensure a memorable stay.",
                            BranchLocation = "Cairo",
                            BranchPhoneNumber = "123",
                            BranchPictureURL = "/pictures/cairo-branch.jpg",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("889ce330-e8cc-4ca0-ae88-424fe669eb50"),
                            BranchDescription = "Step into the timeless charm of Luxor, the world's greatest open-air museum. Our hotel in Luxor is a gateway to ancient wonders, including the Valley of the Kings and Karnak Temple. Relax in comfortable rooms, savor authentic cuisine, and experience the mystique of this historical city.",
                            BranchLocation = "Luxor",
                            BranchPhoneNumber = "789",
                            BranchPictureURL = "/pictures/luxor-branch.jpg",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Models.BranchPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BranchPictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("branch_pictures", (string)null);
                });

            modelBuilder.Entity("Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("Models.ReservedRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservedRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ReservedRoomId");

                    b.ToTable("reserved_rooms", (string)null);
                });

            modelBuilder.Entity("Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("rooms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f92199d-eba5-45d2-a990-44156279707b"),
                            BranchId = new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"),
                            IsActive = true,
                            Price = 400.0,
                            Quantity = 50,
                            RoomName = "Normal Room",
                            RoomTypeId = new Guid("4206b6ad-8df2-447a-869b-6ad9bd2bab43")
                        },
                        new
                        {
                            Id = new Guid("707ebc09-bd74-4f3b-b10c-72e62d2ea247"),
                            BranchId = new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"),
                            IsActive = true,
                            Price = 800.0,
                            Quantity = 150,
                            RoomName = "Med Room",
                            RoomTypeId = new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043")
                        },
                        new
                        {
                            Id = new Guid("032dc455-373f-4abe-a7ae-503f06ce6fad"),
                            BranchId = new Guid("d8ac55b9-4d71-4458-9db0-cebd03db554a"),
                            IsActive = true,
                            Price = 1200.0,
                            Quantity = 25,
                            RoomName = "High Room",
                            RoomTypeId = new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb")
                        },
                        new
                        {
                            Id = new Guid("50f6aa99-1f5d-4078-b373-79a895417df3"),
                            BranchId = new Guid("889ce330-e8cc-4ca0-ae88-424fe669eb50"),
                            IsActive = true,
                            Price = 1200.0,
                            Quantity = 25,
                            RoomName = "High Room",
                            RoomTypeId = new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb")
                        });
                });

            modelBuilder.Entity("Models.RoomPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomPictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("rooms_pictures", (string)null);
                });

            modelBuilder.Entity("Models.RoomsType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Occupancy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("rooms_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4206b6ad-8df2-447a-869b-6ad9bd2bab43"),
                            Beds = "1 Queen or 2 Twins",
                            IsActive = true,
                            Occupancy = "2 Adults and 1 Child",
                            RoomDescription = "The Standard Room offers a comfortable and cozy stay with a choice of one queen bed or two twin beds. It's perfect for couples or small families looking for a relaxing retreat.",
                            RoomSize = "Approximately 300 square feet (27.87 square meters)",
                            RoomType = "Standard Room"
                        },
                        new
                        {
                            Id = new Guid("a01ed692-9573-4cc4-973b-7cbafd1ce043"),
                            Beds = "1 King and 1 Sofa Bed",
                            IsActive = true,
                            Occupancy = "3 Adults or 2 Adults and 2 Children",
                            RoomDescription = "The Deluxe Suite is a spacious and elegant room featuring a king-size bed and a sofa bed. It's an excellent choice for families or guests who desire extra space and comfort during their stay.",
                            RoomSize = "Approximately 450 square feet (41.81 square meters)",
                            RoomType = "Deluxe Suite"
                        },
                        new
                        {
                            Id = new Guid("862f14de-0333-4c25-ba3c-64586d53c2cb"),
                            Beds = "2 King Beds and 2 Twin Beds",
                            IsActive = true,
                            Occupancy = "6 Adults or 4 Adults and 2 Children",
                            RoomDescription = "The Ocean View Villa is a luxurious and expansive accommodation with two king beds and two twin beds. It provides breathtaking views of the ocean and ample space for larger groups or families.",
                            RoomSize = "Approximately 1,200 square feet (111.48 square meters)",
                            RoomType = "Ocean View Villa"
                        });
                });

            modelBuilder.Entity("Models.BranchPicture", b =>
                {
                    b.HasOne("Models.Branch", "Branch")
                        .WithMany("BranchPictures")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Models.Reservation", b =>
                {
                    b.HasOne("Models.Branch", "Branch")
                        .WithMany("Reservations")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Models.ReservedRoom", b =>
                {
                    b.HasOne("Models.Reservation", "Reservation")
                        .WithMany("ReservedRooms")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Room", "Room")
                        .WithMany("ReservedRooms")
                        .HasForeignKey("ReservedRoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Models.Room", b =>
                {
                    b.HasOne("Models.Branch", "Branch")
                        .WithMany("Rooms")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.RoomsType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Models.RoomPicture", b =>
                {
                    b.HasOne("Models.Room", "Room")
                        .WithMany("RoomPictures")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Models.Branch", b =>
                {
                    b.Navigation("BranchPictures");

                    b.Navigation("Reservations");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Models.Reservation", b =>
                {
                    b.Navigation("ReservedRooms");
                });

            modelBuilder.Entity("Models.Room", b =>
                {
                    b.Navigation("ReservedRooms");

                    b.Navigation("RoomPictures");
                });

            modelBuilder.Entity("Models.RoomsType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
