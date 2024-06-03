using Backend.Models;
using Iss.Entity;
using Iss.Service;
using Iss.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class AddReviewRequest
    {
        public string User { get; set; }

        public string Review { get; set; }
    }

    public class UpdateReviewRequest
    {
        public string User { get; set; }

        public string Review { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceReview reviewService;

        public ReviewController(IServiceReview adSetService)
        {
            this.reviewService = adSetService;
        }

        [HttpPost("add")]
        public IActionResult AddReview([FromBody] AddReviewRequest addReviewRequest)
        {
            try
            {
                if (addReviewRequest == null || string.IsNullOrEmpty(addReviewRequest.Review))
                {
                    return BadRequest("Invalid review request.");
                }

                reviewService.AddReview(addReviewRequest.User, addReviewRequest.Review);
                return Ok("Review added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add review: {ex.Message}");
            }
        }

        [HttpDelete("{user}/reviews/{review}")]
        public IActionResult DeleteReview(string user, string review)
        {
            try
            {
                reviewService.DeleteReview(user, review);
                return Ok("Review deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete review: {ex.Message}");
            }
        }

        [HttpGet("getallReviews")]
        public IActionResult GetReviews()
        {
            try
            {
                var retrievedAdSet = reviewService.GetAllReviews();
                if (retrievedAdSet == null)
                {
                    return NotFound("Ad set not found.");
                }
                return Ok(retrievedAdSet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get reviews set: {ex.Message}");
            }
        }

        /*[HttpPut("update")]
        public IActionResult UpdateAdSet([FromBody] UpdateAdSetRequest updateAdSetRequest)
        {
            try
            {
                AdSet adSet = this.reviewService.GetAdSetByName(new AdSet() { Name = updateAdSetRequest.Name });
                adSet.Name = updateAdSetRequest.Name;
                adSet.TargetAudience = updateAdSetRequest.TargetAudience;

                reviewService.UpdateAdSet(adSet);
                return Ok("Ad set updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update ad set: {ex.Message}");
            }
        }*/

        /*[HttpDelete("{adSetName}")]
        public IActionResult DeleteAdSet(string adSetName)
        {
            try
            {
                // Retrieve ad set from repository based on ID
                AdSet adSet = reviewService.GetAdSetByName(new AdSet() { Name = adSetName });
                if (adSet == null)
                {
                    return NotFound("Ad set not found.");
                }

                reviewService.DeleteAdSet(adSet);
                return Ok("Ad set deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete ad set: {ex.Message} \n\n {ex.InnerException}");
            }
        }*/
    }
}
