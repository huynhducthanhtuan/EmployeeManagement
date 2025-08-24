using AuthService.DTO;

namespace AuthService.Interfaces
{
    public interface ICognitoAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<bool> ConfirmRegisterAsync(RegisterConfirmation request, CancellationToken cancellationToken = default);
        Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    }
}
