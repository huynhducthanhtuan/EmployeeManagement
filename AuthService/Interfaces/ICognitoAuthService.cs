using AuthService.DTO;

namespace AuthService.Interfaces
{
    public interface ICognitoAuthService
    {
        Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    }
}
