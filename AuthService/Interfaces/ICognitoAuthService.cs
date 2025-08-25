using AuthService.DTO;

namespace AuthService.Interfaces
{
    public interface ICognitoAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<bool> ConfirmRegisterAsync(RegisterConfirmation request, CancellationToken cancellationToken = default);
        Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
        Task<UserDTO> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<List<UserDTO>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}
