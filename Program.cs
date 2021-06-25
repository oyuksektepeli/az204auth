using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204auth
{
    class Program
    {
        private const string _clientId = "5566e7bd-34de-4485-9b73-34f6d22eaeb5";
        private const string _tenantId = "e2383391-fd0f-4311-b08f-fef016e56cef";


        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder.Create(_clientId)
                      .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                      .WithRedirectUri("http://localhost")
                      .Build();

            string[] scopes = {"user.read"};

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
