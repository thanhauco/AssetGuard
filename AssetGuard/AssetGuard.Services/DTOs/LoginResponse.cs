namespace AssetGuard.Services.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
