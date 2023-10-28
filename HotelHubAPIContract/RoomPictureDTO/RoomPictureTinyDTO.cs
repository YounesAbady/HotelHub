namespace APIContract.RoomPictureDTO
{
    public record RoomPictureTinyDTO
    {
        public Guid RoomId { get; set; }
        public string RoomPictureURL { get; set; } = string.Empty;
    }
}
