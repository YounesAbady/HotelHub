namespace Models
{
    public record Room : BaseDomain
    {
        public string RoomName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid BranchId { get; set; }
        //Navigation Properties
        public virtual Branch? Branch { get; set; } 
        public virtual RoomsType? RoomType { get; set; } 
        public virtual List<RoomPicture>? RoomPictures { get; set; }
        public virtual List<ReservedRoom>? ReservedRooms { get; set; }
    }
}
