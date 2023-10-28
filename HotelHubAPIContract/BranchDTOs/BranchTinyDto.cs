namespace APIContract.BranchDTOs
{
    public record BranchTinyDto : BranchBaseDto
    {
        public string BranchLocation { get; set; } = string.Empty;
        public string BranchDescription { get; set; } = string.Empty;
        public string BranchPictureURL { get; set; } = string.Empty;
    }
}
