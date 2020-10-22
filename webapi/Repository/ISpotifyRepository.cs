using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapi.Repository
{
    public interface ISpotifyRepository
    {
        public Task<string> TrackName(string styleMusic);



    }
}