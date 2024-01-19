
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/positions")]
    [ApiController]
    [Authorize]
    public class PositionsController : ControllerBase
    {
        public IPositionService _positionService;
        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetPositionsAsync(
              [FromQuery] PositionResourceParameters positionResourceParameters)
        {
            var positions = await _positionService.GetPositionsAsync(positionResourceParameters);
            return Ok(positions);
        }
        [HttpGet("{id}", Name = "GetPositionById")]
        public async Task<ActionResult<PositionDto>> Get(int id)
        {
            var position = _positionService.GetPositionByIdAsync(id);
            return Ok(position);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PositionForCreateDto position)
        {
            await _positionService.CreatePositionAsync(position);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PositionForUpdateDto position)
        {
            if (id != position.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {position.Id}.");
            }

            await _positionService.UpdatePositionAsync(position);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
