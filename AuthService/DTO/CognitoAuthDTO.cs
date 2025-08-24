namespace AuthService.DTO
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; } // Ex: +84999999999
        public required string Birthdate { get; set; } // yyyy-MM-dd format
        public required string Gender { get; set; } // "male" or "female"
    }

    public class RegisterConfirmation
    {
        public required string Email { get; set; }
        public required string ConfirmationCode { get; set; }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
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
