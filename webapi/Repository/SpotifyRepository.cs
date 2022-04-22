using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace webapi.Repository
{  
    public class SpotifyRepository : ISpotifyRepository
    {
        private readonly IRandomMusics _randomMusics;
        private readonly IConfiguration _config;
        public SpotifyRepository(IRandomMusics randomMusics, IConfiguration config)
        {
            _randomMusics = randomMusics;
            _config = config;
        }
        public async Task<string> TrackName(string styleMusic)
        {            
            string clientId =  "";
            string clientSecret = "";

            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));
            FullAlbum album = await spotify.Albums.Get(_randomMusics.GetTypeMusic(styleMusic));

            return album.Name;

        }


    }
}