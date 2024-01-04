using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Interfaces.Services;

namespace StaySphere.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> Get()
        {
            var customers = _bookingService.GetBookings();
            
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        public ActionResult<BookingDto> Get(int id)
        {
            var booking = _bookingService.GetBookingById(id);
           
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult Post(BookingForCreateDto booking)
        {
            _bookingService.CreateBooking(booking);
          
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookingForUpdateDto booking)
        {
            if (id != booking.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {booking.Id}.");
            }

            _bookingService.UpdateBooking(booking);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookingService.DeleteBooking(id);
          
            return NoContent();
        }
    }
}
