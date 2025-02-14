using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using united_movers_api.Models;
using united_movers_api.Repositories.Implementations;
using united_movers_api.Repositories.Interfaces;
using united_movers_api.Services.Interfaces;

namespace united_movers_api.Services.Implementations
{
    public class RiderService : IRiderService
    {
        private readonly IRiderRepository _riderRepository;

        public RiderService(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }
      
         
        public async Task<IEnumerable<Rider>> GetAllRidersAsync()
        {
            return await _riderRepository.GetAllRidersAsync();
        }

        public async Task<Rider> GetRiderByIdAsync(int id)
        {
            return await _riderRepository.GetRiderByIdAsync(id);
        }

        public async Task<Rider> CreateRiderAsync(Rider rider)
        {
            return await _riderRepository.CreateRiderAsync(rider);

        }

        public async Task<Rider> UpdateRiderAsync(int id, Rider rider)
        {
            return await _riderRepository.UpdateRiderAsync(id, rider);

        }

        public async Task<bool> DeleteRiderAsync(int id)
        {
             return await _riderRepository.DeleteRiderAsync(id);
        }

        
    }
}
