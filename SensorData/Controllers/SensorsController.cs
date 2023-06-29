using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SensorData.Models;
using SensorData.Services;
using SensorData.Models;

namespace SensorData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _sensorService.GetAll());
        }

        // GET api/Sensors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var sensor = await _sensorService.GetById(id);

            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(sensor);
        }

        // POST api/Sensors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SensorInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sensor sensor = new Sensor
            {
                SensorId = inputModel.SensorId,
                SensorName = inputModel.SensorName,
                LocationId = inputModel.LocationId,
                IsActive = inputModel.IsActive,
                ActivationDate = inputModel.ActivationDate
            };

            await _sensorService.Create(sensor);

            return CreatedAtAction(nameof(Get), new { id = sensor.SensorId }, sensor);
        }


        // PUT api/Sensors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorService.Update(id, sensor);

            return NoContent();
        }

        // DELETE api/Sensors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _sensorService.Delete(id);

            return NoContent();
        }
    }
}
