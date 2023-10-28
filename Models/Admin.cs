namespace Models
{
    public record Admin : BaseDomain
    {
        public string Username { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
    }
}
