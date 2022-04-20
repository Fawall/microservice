using System.Threading.Tasks;

namespace webapi.Repository
{
    public interface IClientRepository
    {
        public Task<string> GetTemperature(string city);
    }
}