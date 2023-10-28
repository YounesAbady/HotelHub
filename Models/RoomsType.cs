namespace Models
{
    public record RoomsType : BaseDomain
    {
        public string RoomType { get; set; } = string.Empty;
        public string RoomSize { get; set; } = string.Empty;
        public string Beds { get; set; } = string.Empty;
        public string Occupancy { get; set; } = string.Empty;
        public string RoomDescription { get; set; } = string.Empty;
        public int MaxCapacityAdults { get; set; }
        public int MaxCapacityChilds { get; set; }

        //Navigation Properties
        public virtual List<Room>? Rooms { get; set; }
    }
}
