namespace APIContract.RoomTypeDTOs
{
    public record RoomTypeTinyDTO : RoomTypeBaseDTO
    {
        public string RoomType { get; set; } = string.Empty;
        public string RoomSize { get; set; } = string.Empty;
        public string Beds { get; set; } = string.Empty;
        public string Occupancy { get; set; } = string.Empty;
        public string RoomDescription { get; set; } = string.Empty;
    }
}
