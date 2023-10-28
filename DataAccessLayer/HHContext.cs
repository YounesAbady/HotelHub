using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class HHContext : DbContext
    {
        public HHContext(DbContextOptions<HHContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branch>()
                .ToTable("branches")
                .HasKey(branch => branch.Id);

            modelBuilder.Entity<BranchPicture>()
                .ToTable("branch_pictures")
                .HasKey(branchPicture => branchPicture.Id);
            modelBuilder.Entity<BranchPicture>()
                .HasOne(branch => branch.Branch)
                .WithMany(pictures => pictures.BranchPictures)
                .HasForeignKey(fk => fk.BranchId);

            modelBuilder.Entity<Room>()
                .ToTable("rooms")
                .HasKey(room => room.Id);
            modelBuilder.Entity<Room>()
                .HasOne(room => room.RoomType)
                .WithMany(roomType => roomType.Rooms)
                .HasForeignKey(fk => fk.RoomTypeId);
            modelBuilder.Entity<Room>()
                .HasOne(room => room.Branch)
                .WithMany(branch => branch.Rooms)
                .HasForeignKey(fk => fk.BranchId);

            modelBuilder.Entity<RoomsType>()
                .ToTable("rooms_types")
                .HasKey(roomType => roomType.Id);

            modelBuilder.Entity<RoomPicture>()
                .ToTable("rooms_pictures")
                .HasKey(roomPicture => roomPicture.Id);
            modelBuilder.Entity<RoomPicture>()
                 .HasOne(roomPicture => roomPicture.Room)
                 .WithMany(room => room.RoomPictures)
                 .HasForeignKey(fk => fk.RoomId);

            modelBuilder.Entity<Admin>()
                .ToTable("admins")
                .HasKey(admin => admin.Id);

            modelBuilder.Entity<Reservation>()
                .ToTable("reservations")
                .HasKey(reservation => reservation.Id);
            modelBuilder.Entity<Reservation>()
                .HasOne(reservation => reservation.Branch)
                .WithMany(branch => branch.Reservations)
                .HasForeignKey(fk => fk.BranchId);

            modelBuilder.Entity<ReservedRoom>()
                .ToTable("reserved_rooms")
                .HasKey(reservedRoom => reservedRoom.Id);
            modelBuilder.Entity<ReservedRoom>()
                .HasOne(reservedRoom => reservedRoom.Reservation)
                .WithMany(rooms => rooms.ReservedRooms)
                .HasForeignKey(fk => fk.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ReservedRoom>()
                .HasOne(reservedRoom => reservedRoom.Room)
                .WithMany(rooms => rooms.ReservedRooms)
                .HasForeignKey(fk => fk.ReservedRoomId)
                .OnDelete(DeleteBehavior.NoAction);




            //Data Seeding => 
            modelBuilder.Entity<Branch>()
                .HasData(new Branch { Id = Guid.Parse("f0b3bf0f-a861-4f5a-b7cd-97304b0266a9"), BranchLocation = "Aswan", BranchDescription = "Nestled along the serene banks of the Nile River in Aswan, our hotel offers a tranquil escape in the heart of ancient Egypt. Enjoy breathtaking views of the river and nearby historic sites. Our comfortable rooms, attentive service, and fine dining options make your stay unforgettable.", BranchPhoneNumber = "456", BranchPictureURL = "/pictures/aswan-branch.jpg" }
                , new Branch { Id = Guid.Parse("d8ac55b9-4d71-4458-9db0-cebd03db554a"), BranchLocation = "Cairo", BranchDescription = "Discover the magic of Cairo from our centrally located hotel in the bustling capital of Egypt. With easy access to iconic attractions like the Giza Pyramids and Egyptian Museum, you're in the perfect spot for exploring this vibrant city. Our modern accommodations and world-class amenities ensure a memorable stay.", BranchPhoneNumber = "123", BranchPictureURL = "/pictures/cairo-branch.jpg" }
                , new Branch { Id = Guid.Parse("889ce330-e8cc-4ca0-ae88-424fe669eb50"), BranchLocation = "Luxor", BranchDescription = "Step into the timeless charm of Luxor, the world's greatest open-air museum. Our hotel in Luxor is a gateway to ancient wonders, including the Valley of the Kings and Karnak Temple. Relax in comfortable rooms, savor authentic cuisine, and experience the mystique of this historical city.", BranchPhoneNumber = "789", BranchPictureURL = "/pictures/luxor-branch.jpg" });

            modelBuilder.Entity<RoomsType>()
                .HasData(new RoomsType { Id = Guid.Parse("4206b6ad-8df2-447a-869b-6ad9bd2bab43"), RoomType = "Standard Room", Beds = "1 Queen or 2 Twins", Occupancy = "2 Adults and 1 Child", MaxCapacityAdults = 2, MaxCapacityChilds = 1, RoomDescription = "The Standard Room offers a comfortable and cozy stay with a choice of one queen bed or two twin beds. It's perfect for couples or small families looking for a relaxing retreat.", RoomSize = "Approximately 300 square feet (27.87 square meters)" }
                , new RoomsType { Id = Guid.Parse("a01ed692-9573-4cc4-973b-7cbafd1ce043"), RoomType = "Deluxe Suite", Beds = "1 King and 1 Sofa Bed", Occupancy = "3 Adults and 2 Children", MaxCapacityAdults = 3, MaxCapacityChilds = 2, RoomDescription = "The Deluxe Suite is a spacious and elegant room featuring a king-size bed and a sofa bed. It's an excellent choice for families or guests who desire extra space and comfort during their stay.", RoomSize = "Approximately 450 square feet (41.81 square meters)" }
                , new RoomsType { Id = Guid.Parse("862f14de-0333-4c25-ba3c-64586d53c2cb"), RoomType = "Ocean View Villa", Beds = "2 King Beds and 2 Twin Beds", Occupancy = "6 Adults and 2 Children", MaxCapacityAdults = 6, MaxCapacityChilds = 2, RoomDescription = "The Ocean View Villa is a luxurious and expansive accommodation with two king beds and two twin beds. It provides breathtaking views of the ocean and ample space for larger groups or families.", RoomSize = "Approximately 1,200 square feet (111.48 square meters)" });

            modelBuilder.Entity<Room>()
                .HasData(new Room { Id = Guid.Parse("2f92199d-eba5-45d2-a990-44156279707b"), RoomName = "Normal Room", Price = 400, RoomTypeId = Guid.Parse("4206b6ad-8df2-447a-869b-6ad9bd2bab43"), Quantity = 50, BranchId = Guid.Parse("d8ac55b9-4d71-4458-9db0-cebd03db554a") }
                , new Room { Id = Guid.Parse("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), RoomName = "Med Room", Price = 800, RoomTypeId = Guid.Parse("a01ed692-9573-4cc4-973b-7cbafd1ce043"), Quantity = 150, BranchId = Guid.Parse("d8ac55b9-4d71-4458-9db0-cebd03db554a") }
                , new Room { Id = Guid.Parse("032dc455-373f-4abe-a7ae-503f06ce6fad"), RoomName = "High Room", Price = 1200, RoomTypeId = Guid.Parse("862f14de-0333-4c25-ba3c-64586d53c2cb"), Quantity = 25, BranchId = Guid.Parse("d8ac55b9-4d71-4458-9db0-cebd03db554a") }
                , new Room { Id = Guid.Parse("50f6aa99-1f5d-4078-b373-79a895417df3"), RoomName = "High Room", Price = 1200, RoomTypeId = Guid.Parse("862f14de-0333-4c25-ba3c-64586d53c2cb"), Quantity = 25, BranchId = Guid.Parse("889ce330-e8cc-4ca0-ae88-424fe669eb50") });

            modelBuilder.Entity<Reservation>()
                .HasData(new Reservation { Id = Guid.Parse("9bf23105-ce1c-41ad-bf6c-b491d10986b1"), BranchId = Guid.Parse("d8ac55b9-4d71-4458-9db0-cebd03db554a"), StartDate = DateTime.Parse("2023-11-10 00:00:00.0000000"), EndDate = DateTime.Parse("2023-11-12 00:00:00.0000000"), TotalPrice = 1500 });

            modelBuilder.Entity<ReservedRoom>()
                .HasData(new ReservedRoom { Id = Guid.Parse("46936b6d-d806-4bf5-8d76-4918f33cb682"), ReservedRoomId = Guid.Parse("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), ReservationId = Guid.Parse("9bf23105-ce1c-41ad-bf6c-b491d10986b1") }
                , new ReservedRoom { Id = Guid.Parse("f00ac58f-b2e6-4cea-9534-401384a0809e"), ReservedRoomId = Guid.Parse("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), ReservationId = Guid.Parse("9bf23105-ce1c-41ad-bf6c-b491d10986b1") });

            modelBuilder.Entity<RoomPicture>()
                .HasData(new RoomPicture { Id = Guid.Parse("c1f69e3f-cbe5-46a0-84c3-31f9d60190ee"), RoomId = Guid.Parse("2f92199d-eba5-45d2-a990-44156279707b"), RoomPictureURL = "/pictures/room1.jpg" }
                , new RoomPicture { Id = Guid.Parse("e790ae12-6cf7-4fea-be89-3cbda1232467"), RoomId = Guid.Parse("2f92199d-eba5-45d2-a990-44156279707b"), RoomPictureURL = "/pictures/room1-1.jpg" }
                , new RoomPicture { Id = Guid.Parse("f7998109-db7e-463d-917e-250465fa0e9a"), RoomId = Guid.Parse("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), RoomPictureURL = "/pictures/room2.jpg" }
                , new RoomPicture { Id = Guid.Parse("f1daf1ed-cab7-4e37-b655-86250f78619b"), RoomId = Guid.Parse("707ebc09-bd74-4f3b-b10c-72e62d2ea247"), RoomPictureURL = "/pictures/room2-1.jpg" }
                , new RoomPicture { Id = Guid.Parse("9a95e2ca-23d0-4174-811c-07748a175c41"), RoomId = Guid.Parse("032dc455-373f-4abe-a7ae-503f06ce6fad"), RoomPictureURL = "/pictures/room3.jpg" }
                , new RoomPicture { Id = Guid.Parse("f676a55a-0c72-4b56-8c33-17bcbd44e085"), RoomId = Guid.Parse("032dc455-373f-4abe-a7ae-503f06ce6fad"), RoomPictureURL = "/pictures/room3-1.jpg" });

            modelBuilder.Entity<Admin>()
                .HasData(new Admin { Id = Guid.Parse("e0e0e0f8-3de6-40f7-a31b-c5793fb15875"), Username = "Admin", HashedPassword = "AQAAAAIAAYagAAAAELNvpov5kcsPLipcypnIJ1RaTf2mu3sLSt6jNzIYhzoIqghcYAUz5V9yF+AwILz/FA==" });
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchPicture> BranchPictures { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomsType> RoomsTypes { get; set; }
        public DbSet<RoomPicture> RoomPictures { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedRoom> ReservedRooms { get; set; }
    }
}
