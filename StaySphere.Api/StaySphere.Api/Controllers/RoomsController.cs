
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
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
            var metaData = await GetPagenationMetaDataAsync(rooms);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));
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
        private async Task<PagenationMetaData> GetPagenationMetaDataAsync(PaginatedList<RoomDto> roomDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = roomDtOs.TotalCount,
                PageSize = roomDtOs.PageSize,
                CurrentPage = roomDtOs.CurrentPage,
                TotalPages = roomDtOs.TotalPages,
            };
        }
        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
