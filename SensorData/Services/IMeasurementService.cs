using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;

namespace SensorData.Services
{
    public interface IMeasurementService
    {
        Task<IEnumerable<Measurement>> GetAll();
        Task<Measurement> GetById(int id);
        Task Create(Measurement measurement);
        Task Update(int id, Measurement measurement);
        Task Delete(int id);
    }
}
