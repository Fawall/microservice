using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using webapi.Repository;

namespace webapi.Controllers {
    [Route ("/api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ISpotifyRepository _spotify;
        private readonly IHttpClientFactory _httpclient;
        private readonly IConfiguration _config;

        public TemperatureController (ISpotifyRepository spotify, IHttpClientFactory httpclient, IConfiguration config) {
            _spotify = spotify;
            _httpclient = httpclient;
            _config = config;
 
        }

        [HttpGet ("{city}")]
        public async Task<ActionResult> Temperature (string city) {

            var client = _httpclient.CreateClient();

            string API = $"http://api.hgbrasil.com/weather?array_limit=2&fields=only_results,temp,city&key={_config.GetSection("AppSetting:key").Value}&city_name={city}";

            HttpResponseMessage ResponseTemperature = await client.GetAsync(API);            
            string responseBody = await ResponseTemperature.Content.ReadAsStringAsync();

            client.Dispose();
            ResponseTemperature.Dispose();
            
            Desearilize desearialize = JsonConvert.DeserializeObject<Desearilize>(responseBody);

            var musica = await _spotify.TrackName();

            if(desearialize.Temp > 5)
            {
                return Ok ($"Temperatura: {desearialize.Temp}\n Cidade: {desearialize.city} \n Spotify: {musica}");
            
            }
            else
            {
                return Ok("é pra funcionar");
            }



            // return Ok ($"Temperatura: {desearialize.Temp}\n Cidade: {desearialize.city}");
        }

    }
}