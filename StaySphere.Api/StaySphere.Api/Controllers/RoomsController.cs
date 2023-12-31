﻿using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Interfaces.Services;

namespace StaySphere.Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> Get()
        {
            var rooms = _roomService.GetRooms();

            return Ok(rooms);
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult Get(int id)
        {
            var room = _roomService.GetRoomById(id);

            return Ok(room);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RoomForCreateDto room)
        {
            _roomService.CreateRoom(room);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoomForUpdateDto room)
        {
            if (id != room.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {room.Id}.");
            }
            _roomService.UpdateRoom(room);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _roomService.DeleteRoom(id);

            return NoContent();
        }
    }
}
