using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformsService.Dtos;

namespace PlatformsService.SyncDataServices.Http
{
    class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platformReadDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platformReadDto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"{_configuration["CommandsServiceUri"]}/api/c/platforms", httpContent);
            
            Console.WriteLine(response.IsSuccessStatusCode
                ? "--> Sync POST to CommandsService was ok"
                : "--> Sync POST to CommandsService was NOT ok");
        }
    }
}