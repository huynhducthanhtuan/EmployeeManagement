using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using AuthService.DTO;
using AuthService.Interfaces;
using Microsoft.Extensions.Options;

namespace AuthService.Services
{
    public class CognitoAuthService : ICognitoAuthService
    {
        private readonly IAmazonCognitoIdentityProvider _cognito;
        private readonly CognitoOptions _cognitoOptions;

        public CognitoAuthService(IAmazonCognitoIdentityProvider cognito, IOptions<CognitoOptions> cognitoOptions)
        {
            _cognito = cognito;
            _cognitoOptions = cognitoOptions.Value;
        }

        public async Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            // Username may be same as email if you configured it that way
            var signUp = new SignUpRequest
            {
                ClientId = _cognitoOptions.ClientId,
                Username = request.Username,
                Password = request.Password,
                UserAttributes = [
                    new AttributeType { Name = "email", Value = request.Email }
                ]
            };

            try
            {
                var resp = await _cognito.SignUpAsync(signUp, cancellationToken);

                // If your pool requires confirmation, client must call ConfirmSignUp separately.
                // You can also auto-confirm via admin if your business rules allow.
                if ((bool)!resp.UserConfirmed)
                {
                    // no-op here; client should confirm via code sent to email
                }
            }
            catch (UsernameExistsException)
            {
                throw new InvalidOperationException("Username already exists.");
            }
            catch (InvalidPasswordException ex)
            {
                throw new InvalidOperationException($"Invalid password policy: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Register failed: {ex.Message}");
            }
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var authReq = new AdminInitiateAuthRequest
            {
                AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH,
                UserPoolId = _cognitoOptions.UserPoolId,
                ClientId = _cognitoOptions.ClientId,
                AuthParameters =
                {
                    ["USERNAME"] = request.Username,
                    ["PASSWORD"] = request.Password
                }
            };

            try
            {
                var authResp = await _cognito.AdminInitiateAuthAsync(authReq, cancellationToken);
                if (authResp.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
                {
                    throw new InvalidOperationException("User must set a new password before login (NEW_PASSWORD_REQUIRED).");
                }

                var result = authResp.AuthenticationResult;
                return new AuthResponse
                {
                    AccessToken = result.AccessToken,
                    IdToken = result.IdToken,
                    RefreshToken = result.RefreshToken,
                    ExpiresIn = (int)result.ExpiresIn,
                    TokenType = result.TokenType
                };
            }
            catch (NotAuthorizedException)
            {
                throw new InvalidOperationException("Incorrect username or password.");
            }
            catch (UserNotConfirmedException)
            {
                throw new InvalidOperationException("User not confirmed. Please verify your email.");
            }
            catch (UserNotFoundException)
            {
                throw new InvalidOperationException("User not found.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Login failed: {ex.Message}");
            }
        }
    }
}
