using Microsoft.AspNetCore.Mvc;
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
        public SpotifyRepository(IRandomMusics randomMusics)
        {
            _randomMusics = randomMusics;
        }

        public async Task<string> TrackName()
        {
            SpotifyWebAPI spotify;
            

            CredentialsAuth auth = new CredentialsAuth("12733ce1e5a44b0fbd0aaf839169ce84", "a4c0256914aa48c3a03f1cc8e395c393");
            Token token = await auth.GetToken();
            
            spotify = new SpotifyWebAPI()
            {
            AccessToken = token.AccessToken,
            TokenType = token.TokenType
            };

            FullAlbum album = await spotify.GetAlbumAsync(_randomMusics.PartyMusic());
      
            return album.Name;


        }


    }
}