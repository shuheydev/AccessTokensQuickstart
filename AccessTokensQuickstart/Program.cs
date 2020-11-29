using System;
using System.Threading.Tasks;
using Azure.Communication.Administration;
using Microsoft.Extensions.Configuration;

namespace AccessTokensQuickstart
{
    class Program
    {
        string ConnectionString = string.Empty;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>(optional: true);

            var configuration = builder.Build();

            //Console.WriteLine(configuration["CommunicationService:ConnectionString"]);

            string connectionString = configuration["CommunicationService:ConnectionString"];
            var client = new CommunicationIdentityClient(connectionString);

            //IDの作成
            var identityResponse = await client.CreateUserAsync();
            var identity = identityResponse.Value;
            Console.WriteLine($"Created an identity with ID: {identity.Id}");
        }
    }
}
