using System.Collections.Generic;
using System.Threading.Tasks;
using united_movers_api.Models;

namespace united_movers_api.Services
{
    public interface IRiderService
    {
        Task<IEnumerable<Rider>> GetAllRidersAsync();
        Task<Rider> GetRiderByIdAsync(int id);
        Task<Rider> CreateRiderAsync(Rider rider);
        Task<Rider> UpdateRiderAsync(int id, Rider rider);
        Task<bool> DeleteRiderAsync(int id);
    }
}
