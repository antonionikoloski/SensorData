using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SensorData.Models;
using SensorData.Services;
using SensorData.Models;

namespace SensorDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _locationService.GetAll());
        }

        // GET api/Locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var location = await _locationService.GetById(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // POST api/Locations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Location location = new Location
            {
                LocationName = inputModel.LocationName
            };

            await _locationService.Create(location);

            return CreatedAtAction(nameof(Get), new { id = location.LocationId }, location);
        }


        // PUT api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _locationService.Update(id, location);

            return NoContent();
        }

        // DELETE api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _locationService.Delete(id);

            return NoContent();
        }
    }
}
