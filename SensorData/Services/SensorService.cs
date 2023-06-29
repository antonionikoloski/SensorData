using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;
using Microsoft.EntityFrameworkCore;
using SensorData.Data;
using SensorData.Models;


namespace SensorData.Services
{
    public class SensorService : ISensorService
    {
        private readonly SensorDataContext _context;

        public SensorService(SensorDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sensor>> GetAll()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetById(string id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task Create(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string id, Sensor sensor)
        {
            if (id != sensor.SensorId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
