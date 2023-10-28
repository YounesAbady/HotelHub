namespace Models
{
    public record RoomPicture : BaseDomain
    {
        public Guid RoomId { get; set; }
        public string RoomPictureURL { get; set; } = string.Empty;

        //Navigation Properties
        public virtual Room? Room { get; set; }
    }
}
