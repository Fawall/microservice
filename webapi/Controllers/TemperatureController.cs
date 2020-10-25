using System.Net.Http;
using webapi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
        private readonly Services _webServices;
        public TemperatureController (ISpotifyRepository spotify, IHttpClientFactory httpclient, IConfiguration config,
        Services services) {
            _spotify = spotify;
            _httpclient = httpclient;
            _config = config;
            _webServices = services;
 
        }

        [EnableCors]
        [HttpGet ("{city}")]
        public async Task<ActionResult<Services>> Temperature(string city) {

            var client = _httpclient.CreateClient();
       
            string API = $"http://api.hgbrasil.com/weather?array_limit=2&fields=only_results,temp,city&key={_config.GetSection("AppSettings:key").Value}&city_name={city}";

            HttpResponseMessage ResponseTemperature = await client.GetAsync(API);            
            string responseBody = await ResponseTemperature.Content.ReadAsStringAsync();

            client.Dispose();
            ResponseTemperature.Dispose();
            
            Deserialize deserialize = JsonConvert.DeserializeObject<Deserialize>(responseBody);

            _webServices.Temp = deserialize.Temp;
            _webServices.City = deserialize.city;

            if(_webServices.Temp >= 30)
            {
                _webServices.Music = await _spotify.TrackName("PartyMusic");
                
                return _webServices;
                
            }
            else if (_webServices.Temp >= 15 && _webServices.Temp < 30)
            {
                _webServices.Music = await _spotify.TrackName("PopMusic");
                return _webServices;
            }

            else
            {   
                _webServices.Music = await _spotify.TrackName("RockMusic");    
                return _webServices;
            }

            // return Ok ($"Temperatura: {desearialize.Temp}\n Cidade: {desearialize.city}");
        }

    }
}