using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using united_movers_api.Models;
using united_movers_api.Services;

namespace united_movers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidersController : ControllerBase
    {
        private readonly IRiderService _riderService;

        public RidersController(IRiderService riderService)
        {
            _riderService = riderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rider>>> GetRiders()
        {
            var riders = await _riderService.GetAllRidersAsync();
            return Ok(riders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rider>> GetRider(int id)
        {
            var rider = await _riderService.GetRiderByIdAsync(id);
            if (rider == null)
            {
                return NotFound();
            }
            return Ok(rider);
        }

        [HttpPost]
        public async Task<ActionResult<Rider>> CreateRider(Rider rider)
        {
            var createdRider = await _riderService.CreateRiderAsync(rider);
            return CreatedAtAction(nameof(GetRider), new { id = createdRider.RiderID }, createdRider);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRider(int id, Rider rider)
        {
            if (id != rider.RiderID)
            {
                return BadRequest();
            }

            var updatedRider = await _riderService.UpdateRiderAsync(id, rider);
            if (updatedRider == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRider(int id)
        {
            var result = await _riderService.DeleteRiderAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
