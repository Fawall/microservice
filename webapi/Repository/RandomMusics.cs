using System;
using System.Collections.Generic;

namespace webapi.Repository
{
    public class RandomMusics : IRandomMusics
    {
        public string PartyMusic()
        {
            string[] idAlbunsForParty = {"4TqvKXoNxzUt3KFvb2kMOL", "2v4Crisjd4sT782Jvn7ISC", "7v3QqNKdhBQ6n3IrjZO5mq"};
        
            return RandomMusic(idAlbunsForParty);
        
        }

        public string PopMusic()
        {
            throw new NotImplementedException();
        }

        public string RandomMusic(string[] musicas)
        {
            Random random = new Random();
            
            List<string> nomeAlbum = new List<string>(musicas);
            string index = nomeAlbum[random.Next(nomeAlbum.Count)];
      
            return index;
        }

        public string RockMusic()
        {
            throw new NotImplementedException();
        }
    }
}