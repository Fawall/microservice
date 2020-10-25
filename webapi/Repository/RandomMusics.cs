using System;
using System.Collections.Generic;

namespace webapi.Repository
{
    public class RandomMusics : IRandomMusics
    {
        public string GetTypeMusic(string getMusic)
        {

            string[] TipoDeMusica = {getMusic};

            if(TipoDeMusica[0] == "PopMusic")
                return PartyMusic();

            else if(TipoDeMusica[0] == "PartyMusic")
                return PartyMusic();
            
            else
                return RockMusic();

        }
        public string PartyMusic()
        {
            string[] idAlbunsForParty = {"4TqvKXoNxzUt3KFvb2kMOL", "2v4Crisjd4sT782Jvn7ISC", "7v3QqNKdhBQ6n3IrjZO5mq"};
        
            return RandomMusic(idAlbunsForParty);      
        }

        public string PopMusic()
        {
            string[] idAlbunsForPop = {"6nZPb5jp5hSeWl5pnCXIuX", "3ZJMXbIYhx5CG7DsrRVxwP"+
            "1enqkS1DrDducYiQkuYJWw", "6cKBoHXh7dKn2gVsGniZ58"};

            return RandomMusic(idAlbunsForPop);
        }
        public string RockMusic()
        {
            string[] idAlbunsForRock = {"5WXL9YjbNd4GIqWc9mZOOq", "399w1uaOvKhnkczdMMZYoy", 
            "0CxPbTRARqKUYighiEY9Sz", "6Eycw3dwcDMEFSqkUvLQ7g"};

            return RandomMusic(idAlbunsForRock);
        }
        public string RandomMusic(string[] musics)
        {
            Random random = new Random();
            
            List<string> AlbumName = new List<string>(musics);
            string index = AlbumName[random.Next(AlbumName.Count)];
      
            return index;
        }

    }
}