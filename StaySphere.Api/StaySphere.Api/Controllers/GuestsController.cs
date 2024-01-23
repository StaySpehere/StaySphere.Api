using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using System.Text.Json;

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

            var metaData = await GetPaginationMetaDataAsync(guests);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(guests);
        }
        [HttpGet("{id}", Name = "GetGuestById")]
        public async Task<ActionResult<GuestDto>> Get(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            return Ok(guest);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GuestForCreateDto guest)
        {
            await _guestService.CreateGuestAsync(guest);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GuestForUpdateDto guest)
        {
            if (id != guest.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {guest.Id}.");
            }

            await _guestService.UpdateGuestAsync(guest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
        private async Task<PagenationMetaData> GetPaginationMetaDataAsync(PaginatedList<GuestDto> guestDtos)
        {
            return new PagenationMetaData
            {
                Totalcount = guestDtos.TotalCount,
                PageSize = guestDtos.PageSize,
                CurrentPage = guestDtos.CurrentPage,
                TotalPages = guestDtos.TotalPages,
            };
        }
    }
}
