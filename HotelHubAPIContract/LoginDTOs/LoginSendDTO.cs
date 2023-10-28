namespace APIContract.LoginDTOs
{
    public record LoginSendDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
