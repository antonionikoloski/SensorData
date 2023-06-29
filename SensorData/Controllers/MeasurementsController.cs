using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SensorData.Models;
using SensorData.Services;
using SensorData.Models;

namespace SensorData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementsController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        // GET: api/Measurements
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _measurementService.GetAll());
        }

        // GET api/Measurements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var measurement = await _measurementService.GetById(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // POST api/Measurements
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeasurementInputModel measurementInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measurement = new Measurement
            {
                Date = DateTime.Now,
                SensorId = measurementInput.SensorId,
                Value1 = measurementInput.Value1,
                Value2 = measurementInput.Value2,
                Value3 = measurementInput.Value3
            };

            await _measurementService.Create(measurement);

            return CreatedAtAction(nameof(Get), new { id = measurement.MeasurementId }, measurement);
        }

        // PUT api/Measurements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _measurementService.Update(id, measurement);

            return NoContent();
        }

        // DELETE api/Measurements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _measurementService.Delete(id);

            return NoContent();
        }
    }
}
