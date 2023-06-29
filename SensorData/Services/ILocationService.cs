using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;

namespace SensorData.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAll();
        Task<Location> GetById(int id);
        Task Create(Location location);
        Task Update(int id, Location location);
        Task Delete(int id);
    }
}
