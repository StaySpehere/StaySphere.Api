using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        public IPositionService _positionService;
        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PositionDto>> GetPositionsAsync(
              [FromQuery] PositionResourceParameters positionResourceParameters)
        {
            var positions = _positionService.GetPositions(positionResourceParameters);

            return Ok(positions);
        }
        [HttpGet("{id}", Name = "GetPositionById")]
        public ActionResult<PositionDto> Get(int id)
        {
            var position = _positionService.GetPositionById(id);

            return Ok(position);
        }

        [HttpPost]
        public ActionResult Post([FromBody] PositionForCreateDto position)
        {
            _positionService.CreatePosition(position);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PositionForUpdateDto position)
        {
            if (id != position.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {position.Id}.");
            }
            _positionService.UpdatePosition(position);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _positionService.DeletePosition(id);

            return NoContent();
        }
    }
}
