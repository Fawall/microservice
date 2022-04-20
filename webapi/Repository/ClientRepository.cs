using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace webapi.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;
        public ClientRepository(IHttpClientFactory httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        
        public async Task<string> GetTemperature(string city)
        {
            string API = $"http://api.hgbrasil.com/weather?array_limit=2&fields=only_results,temp,city&key={_config.GetSection("AppSettings:KeyHG").Value}&city_name={city}";

            HttpClient client = _httpClient.CreateClient();

            HttpResponseMessage ResponseTemperature = await client.GetAsync(API);

            string responseBody = await ResponseTemperature.Content.ReadAsStringAsync();

            client.Dispose();
            ResponseTemperature.Dispose();

            return responseBody;
        }

    }
}