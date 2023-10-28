namespace Models
{
    public record Branch : BaseDomain
    {
        public string BranchLocation { get; set; } = string.Empty;
        public string BranchDescription { get; set; } = string.Empty;
        public string BranchPhoneNumber { get; set; } = string.Empty;
        public string BranchPictureURL { get; set; } = string.Empty;

        //Navigation Properties
        public virtual List<BranchPicture>? BranchPictures { get; set; }    
        public virtual List<Reservation>? Reservations { get; set; }    
        public virtual List<Room>? Rooms { get; set; }  
    }
}
