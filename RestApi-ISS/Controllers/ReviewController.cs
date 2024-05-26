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

                reviewService.AddReview(addReviewRequest.Review);
                return Ok("Review added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add review: {ex.Message}");
            }
        }

        /*[HttpPost("{adSetName}/ads/{adName}")]
        public IActionResult AddAdToAdSet(string adSetName, string adName)
        {
            try
            {
                // Retrieve adSet and ad from repository based on IDs
                AdSet adSet = reviewService.GetAdSetByName(new AdSet() { Name = adSetName });
                Ad ad = adService.GetAdByName(adName);

                if (adSet == null || ad == null)
                {
                    return NotFound("Ad set or ad not found.");
                }

                reviewService.AddAdToAdSet(adSet, ad);
                return Ok("Ad added to ad set successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad to ad set: {ex.Message}");
            }
        }*/

        /*[HttpDelete("{adSetName}/ads/{adName}")]
        public IActionResult RemoveAdFromAdSet(string adSetName, string adName)
        {
            try
            {
                // Retrieve adSet and ad from repository based on IDs
                AdSet adSet = reviewService.GetAdSetByName(new AdSet() { Name = adSetName });
                Ad ad = adService.GetAdByName(adName);

                if (adSet == null || ad == null)
                {
                    return NotFound("Ad set or ad not found.");
                }

                reviewService.RemoveAdFromAdSet(adSet, ad);
                return Ok("Ad removed from ad set successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to remove ad from ad set: {ex.Message}");
            }
        }*/

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
