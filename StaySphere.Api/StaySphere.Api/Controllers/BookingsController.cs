using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    //[Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookingsAsync(
              [FromQuery] BookingResourceParameters bookingResourceParameters)
        {
            var bookings = await _bookingService.GetBookingsAsync(bookingResourceParameters);
            var metaData = await GetPagenationMetaDataAsync(bookings);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(bookings);
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        public async Task<ActionResult<BookingDto>> Get(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookingForCreateDto booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookingService.CreateBookingAsync(booking);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookingForUpdateDto booking)
        {
            if (id != booking.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {booking.Id}.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookingService.UpdateBookingAsync(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
        private async Task<PagenationMetaData> GetPagenationMetaDataAsync(PaginatedList<BookingDto> attendanceDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = attendanceDtOs.TotalCount,
                PageSize = attendanceDtOs.PageSize,
                CurrentPage = attendanceDtOs.CurrentPage,
                TotalPages = attendanceDtOs.TotalPages,
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
