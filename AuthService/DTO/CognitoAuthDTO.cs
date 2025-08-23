namespace AuthService.DTO
{
    public class RegisterRequest
    {
        public required string Username { get; set; } // can be email
        public required string Password { get; set; }
        public required string Email { get; set; }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class AuthResponse
    {
        public string? AccessToken { get; set; }
        public string? IdToken { get; set; }
        public string? RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; } = "Bearer";
    }
}
