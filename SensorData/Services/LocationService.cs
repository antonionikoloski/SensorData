using System.Collections.Generic;
using System.Threading.Tasks;
using SensorData.Models;
using Microsoft.EntityFrameworkCore;
using SensorData.Data;
using SensorData.Models;


namespace SensorData.Services
{
    public class LocationService : ILocationService
    {
        private readonly SensorDataContext _context;

        public LocationService(SensorDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task Create(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Location location)
        {
            if (id != location.LocationId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}
