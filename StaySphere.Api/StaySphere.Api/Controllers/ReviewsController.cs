using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Services;

namespace StaySphere.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewDto>> GetReviewAsync(
               [FromQuery] ReviewResourceParameters reviewResourceParameters)
        {
            var reviews = _reviewService.GetReviews(reviewResourceParameters);

            return Ok(reviews);
        }

        [HttpGet("{id}", Name = "GetReviewById")]
        public ActionResult<ReviewDto> Get(int id)
        {
            var review = _reviewService.GetReviewById(id);

            return Ok(review);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ReviewForCreateDto review)
        {
            _reviewService.CreateReview(review);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ReviewForUpdateDto review)
        {
            if (id != review.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {review.Id}.");
            }
            _reviewService.UpdateReview(review);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _reviewService.DeleteReview(id);

            return NoContent();
        }
    }
}
