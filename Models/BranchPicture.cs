namespace Models
{
    public record BranchPicture : BaseDomain
    {
        public Guid BranchId { get; set; }
        public string BranchPictureURL { get; set; } = string.Empty;

        //Navigation Properties
        public virtual Branch? Branch { get; set; }     
    }
}
