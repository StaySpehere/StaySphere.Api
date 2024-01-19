using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/guests")]
    [ApiController]
    [Authorize]
    public class GuestsController : ControllerBase
    {
        public IGuestService _guestService;
        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetGuestAsync(
               [FromQuery] GuestResourceParameters guestResourceParameters)
        {
            var guests = await _guestService.GetGuestsAsync(guestResourceParameters);
            return Ok(guests);
        }
        [HttpGet("{id}", Name = "GetGuestById")]
        public ActionResult<GuestDto> Get(int id)
        {
            var guest = _guestService.GetGuestById(id);

            return Ok(guest);

        }

        [HttpPost]
        public ActionResult Post([FromBody] GuestForCreateDto guest)
        {
            _guestService.CreateGuest(guest);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GuestForUpdateDto guest)
        {
            if (id != guest.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {guest.Id}.");
            }
            _guestService.UpdateGuest(guest);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _guestService.DeleteGuest(id);

            return NoContent();
        }
    }
}
