namespace webapi.Repository
{
    public interface IRandomMusics
    {
        public string PartyMusic();
        public string PopMusic();
        public string RockMusic();

        public string GetTypeMusic(string styleMusic);

         
    }
}