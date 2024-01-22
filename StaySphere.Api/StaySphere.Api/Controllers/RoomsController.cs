using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using System.Text.Json;

namespace StaySphere.Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        public IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsAsync(
               [FromQuery] RoomResourceParameters roomResourceParameters)
        {
            var rooms = await _roomService.GetRoomsAsync(roomResourceParameters);

            var metaData = await GetPaginationMetaDataAsync(rooms);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(rooms);
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<ActionResult> Get(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoomForCreateDto room)
        {
            await _roomService.CreateRoomAsync(room);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RoomForUpdateDto room)
        {
            if (id != room.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {room.Id}.");
            }

            await _roomService.UpdateRoomAsync(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
        private async Task<PagenationMetaData> GetPaginationMetaDataAsync(PaginatedList<RoomDto> roomDtos)
        {
            return new PagenationMetaData
            {
                Totalcount = roomDtos.TotalCount,
                PageSize = roomDtos.PageSize,
                CurrentPage = roomDtos.CurrentPage,
                TotalPages = roomDtos.TotalPages,
            };
        }
    }
}
