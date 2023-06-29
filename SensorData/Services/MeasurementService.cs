using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;
using Microsoft.EntityFrameworkCore;
using SensorData.Data;
using SensorData.Services;

namespace SensorData.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly SensorDataContext _context;

        public MeasurementService(SensorDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measurement>> GetAll()
        {
            return await _context.Measurements.ToListAsync();
        }

        public async Task<Measurement> GetById(int id)
        {
            return await _context.Measurements.FindAsync(id);
        }

        public async Task Create(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Measurement measurement)
        {
            if (id != measurement.MeasurementId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(measurement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement != null)
            {
                _context.Measurements.Remove(measurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
