using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;

namespace AuthService.Helpers
{
    public static class AwsSecretHelper
    {
        public static async Task<string?> GetSecretAsync(string secretName, string region)
        {
            var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            var request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT"
            };

            var response = await client.GetSecretValueAsync(request);
            return response.SecretString;
        }
    }
}
