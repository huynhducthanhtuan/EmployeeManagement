using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using AuthService.DTO;
using AuthService.Helpers;
using AuthService.Interfaces;
using Microsoft.Extensions.Options;

namespace AuthService.Services
{
    public class CognitoAuthService : ICognitoAuthService
    {
        private readonly IAmazonCognitoIdentityProvider _cognito;
        private readonly IAmazonCognitoIdentityProvider _cognitoAdmin;
        private readonly CognitoOptions _cognitoOptions;

        public CognitoAuthService(IAmazonCognitoIdentityProvider cognito, IAmazonCognitoIdentityProvider cognitoAdmin, IOptions<CognitoOptions> cognitoOptions)
        {
            _cognito = cognito;
            _cognitoOptions = cognitoOptions.Value;
            _cognitoAdmin = new AmazonCognitoIdentityProviderClient(
                new BasicAWSCredentials(_cognitoOptions.AccessKey, _cognitoOptions.SecretKey),
                RegionEndpoint.APSoutheast1
            );
        }

        public async Task<bool> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var secretHash = CognitoSecretHashHelper.GenerateSecretHash(request.Email, _cognitoOptions.ClientId, _cognitoOptions.ClientSecret);
            var signUp = new SignUpRequest
            {
                ClientId = _cognitoOptions.ClientId,
                Username = request.Email, // Use email for username
                Password = request.Password,
                SecretHash = secretHash,
                UserAttributes = [
                    new AttributeType { Name = "email", Value = request.Email },
                    new AttributeType { Name = "name", Value = request.Name },
                    new AttributeType { Name = "phone_number", Value = request.PhoneNumber },
                    new AttributeType { Name = "birthdate", Value = request.Birthdate },
                    new AttributeType { Name = "gender", Value = request.Gender }
                ]
            };

            try
            {
                var response = await _cognito.SignUpAsync(signUp, cancellationToken);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    // After register sucess -> Grant user to Employee group
                    var addUserReq = new AdminAddUserToGroupRequest
                    {
                        GroupName = "Employee",
                        Username = request.Email,
                        UserPoolId = _cognitoOptions.UserPoolId
                    };
                    await _cognitoAdmin.AdminAddUserToGroupAsync(addUserReq, cancellationToken);
                    return true;
                }
                else
                {
                    return false;
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

        public async Task<bool> ConfirmRegisterAsync(RegisterConfirmation request, CancellationToken cancellationToken = default)
        {
            var provider = new AmazonCognitoIdentityProviderClient();
            var secretHash = CognitoSecretHashHelper.GenerateSecretHash(request.Email, _cognitoOptions.ClientId, _cognitoOptions.ClientSecret);

            var confirmRequest = new ConfirmSignUpRequest
            {
                ClientId = _cognitoOptions.ClientId,
                Username = request.Email,
                ConfirmationCode = request.ConfirmationCode,
                SecretHash = secretHash
            };

            var response = await provider.ConfirmSignUpAsync(confirmRequest);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var secretHash = CognitoSecretHashHelper.GenerateSecretHash(request.Email, _cognitoOptions.ClientId, _cognitoOptions.ClientSecret);
            var authReq = new InitiateAuthRequest
            {
                AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                ClientId = _cognitoOptions.ClientId,
                AuthParameters = new Dictionary<string, string>
                {
                    { "USERNAME", request.Email },
                    { "PASSWORD", request.Password },
                    { "SECRET_HASH", secretHash }
                }
            };

            try
            {
                var authResp = await _cognito.InitiateAuthAsync(authReq, cancellationToken);
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
                throw new InvalidOperationException($"Login failed: {ex.Message}.");
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var result = new List<UserDTO>();
            string paginationToken = null;

            do
            {
                // Fetch each 60 users for each batch until PaginationToken = null then stop
                var response = await _cognitoAdmin.ListUsersAsync(new ListUsersRequest
                {
                    UserPoolId = _cognitoOptions.UserPoolId,
                    PaginationToken = paginationToken
                }, cancellationToken);

                foreach (var user in response.Users)
                {
                    result.Add(new UserDTO
                    {
                        Email = user.Attributes.FirstOrDefault(a => a.Name == "email")?.Value,
                        Name = user.Attributes.FirstOrDefault(a => a.Name == "name")?.Value,
                        PhoneNumber = user.Attributes.FirstOrDefault(a => a.Name == "phone_number")?.Value,
                        Birthdate = user.Attributes.FirstOrDefault(a => a.Name == "birthdate")?.Value,
                        Gender = user.Attributes.FirstOrDefault(a => a.Name == "gender")?.Value,
                    });
                }

                paginationToken = response.PaginationToken;
            }
            while (!string.IsNullOrEmpty(paginationToken));

            return result;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await _cognitoAdmin.AdminGetUserAsync(new AdminGetUserRequest
            {
                UserPoolId = _cognitoOptions.UserPoolId,
                Username = email
            }, cancellationToken);

            return new UserDTO
            {
                Email = user.UserAttributes.FirstOrDefault(a => a.Name == "email")?.Value,
                Name = user.UserAttributes.FirstOrDefault(a => a.Name == "name")?.Value,
                PhoneNumber = user.UserAttributes.FirstOrDefault(a => a.Name == "phone_number")?.Value,
                Birthdate = user.UserAttributes.FirstOrDefault(a => a.Name == "birthdate")?.Value,
                Gender = user.UserAttributes.FirstOrDefault(a => a.Name == "gender")?.Value,
            };
        }
    }
}
