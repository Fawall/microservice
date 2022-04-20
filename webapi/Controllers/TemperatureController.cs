using System.Net.Http;
using webapi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using webapi.Repository;
using System;

namespace webapi.Controllers {
    [Route ("/api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ISpotifyRepository _spotify;
        private readonly IClientRepository _client;
        private readonly Services _webServices;
        
        public TemperatureController (ISpotifyRepository spotify, Services services, IClientRepository client) {
            _spotify = spotify;
            _webServices = services;
            _client = client;
 
        }

        [EnableCors]
        [HttpGet ("{city}")]
        public async Task<ActionResult<Services>> Temperature(string city) {
            
            string responseBody = await _client.GetTemperature(city);
            
            Deserialize deserialize = JsonConvert.DeserializeObject<Deserialize>(responseBody);

            Services serviceModel = new Services();

            (serviceModel.City, serviceModel.Temp) = (deserialize.city, deserialize.Temp);

            if(serviceModel.Temp >= 30)
            {
                serviceModel.Music = await _spotify.TrackName("PartyMusic");                
                return serviceModel;     
            }

            else if (serviceModel.Temp >= 15 && _webServices.Temp < 30)
            {
                serviceModel.Music = await _spotify.TrackName("PopMusic");
                return serviceModel;
            }

            serviceModel.Music = await _spotify.TrackName("RockMusic");    
            return serviceModel;

        }

    }
}