
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        public IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewAsync(
               [FromQuery] ReviewResourceParameters reviewResourceParameters)
        {
            var reviews = await _reviewService.GetReviewsAsync(reviewResourceParameters);
            var metaData = await GetPagenationMetaDataAsync(reviews);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(reviews);
        }

        [HttpGet("{id}", Name = "GetReviewById")]
        public async Task<ActionResult<ReviewDto>> Get(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReviewForCreateDto review)
        {
           await _reviewService.CreateReviewAsync(review);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReviewForUpdateDto review)
        {
            if (id != review.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {review.Id}.");
            }

            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           await _reviewService.DeleteReviewAsync(id);
           return NoContent();
        }
        private async Task<PagenationMetaData> GetPagenationMetaDataAsync(PaginatedList<ReviewDto> reviewDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = reviewDtOs.TotalCount,
                PageSize = reviewDtOs.PageSize,
                CurrentPage = reviewDtOs.CurrentPage,
                TotalPages = reviewDtOs.TotalPages,
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
