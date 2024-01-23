using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

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
    }
}
