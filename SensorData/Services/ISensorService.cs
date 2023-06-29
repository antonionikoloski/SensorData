using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;

namespace SensorData.Services
{
    public interface ISensorService
    {
        Task<IEnumerable<Sensor>> GetAll();
        Task<Sensor> GetById(string id);
        Task Create(Sensor sensor);
        Task Update(string id, Sensor sensor);
        Task Delete(string id);
    }
}
