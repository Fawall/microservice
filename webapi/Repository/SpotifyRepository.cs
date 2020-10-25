using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;
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
        SpotifyWebAPI spotify;

        public async Task<string> TrackName(string styleMusic)
        {            
            CredentialsAuth auth = new CredentialsAuth(_config.GetSection("AppSettings:clientId").Value,
            _config.GetSection("AppSettings:clientSecret").Value);

            Token token = await auth.GetToken();
            
            spotify = new SpotifyWebAPI()
            {
            AccessToken = token.AccessToken,
            TokenType = token.TokenType
            };

            
            FullAlbum album = await spotify.GetAlbumAsync(_randomMusics.GetTypeMusic(styleMusic));

            return album.Name;


        }


    }
}