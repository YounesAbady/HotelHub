namespace Models
{
    public record BaseDomain
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
    }
}
