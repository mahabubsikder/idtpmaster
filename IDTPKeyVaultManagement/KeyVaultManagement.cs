using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace IDTPKeyVaultManagement
{
    public static class KeyVaultManagement
    {
        private const string _vaultURI = "https://idtp-keyvault.vault.azure.net/";

        public static string GetKey(string keyName)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };
            var client = new SecretClient(new Uri(_vaultURI), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret(keyName);

            string secretValue = secret.Value;

            return secretValue;

        }
    }
}
