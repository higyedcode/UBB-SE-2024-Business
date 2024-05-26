using System.Collections.Generic;
using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class AddAdRequest
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string SelectedImagePath { get; set; }
        public string Link { get; set; }
    }

    public class UpdateAdRequest
    {
        public string AdId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string SelectedImagePath { get; set; }
        public string Link { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        [HttpPost("add")]
        public IActionResult AddAd([FromBody] AddAdRequest addAdRequest)
        {
            try
            {
                Ad adToAdd = new Ad(addAdRequest.ProductName, addAdRequest.SelectedImagePath, addAdRequest.Description, addAdRequest.Link);

                adService.AddAd(adToAdd);
                return Ok("Ad added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad: {ex.Message}\n\n {ex.InnerException}");
            }
        }

        [HttpGet("not-in-adset")]
        public IActionResult GetAdsThatAreNotInAdSet()
        {
            try
            {
                var ads = adService.GetAdsThatAreNotInAdSet();
                return Ok(ads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve ads: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateAd([FromBody] UpdateAdRequest updateAdRequest)
        {
            try
            {
                Ad adToUpdate = new Ad(updateAdRequest.AdId, updateAdRequest.ProductName, updateAdRequest.SelectedImagePath, updateAdRequest.Description, updateAdRequest.Link);

                adService.UpdateAd(adToUpdate);
                return Ok("Ad updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update ad: {ex.Message}");
            }
        }

        [HttpGet("by-name/{adName}")]
        public IActionResult GetAdByName(string adName)
        {
            try
            {
                var ad = adService.GetAdByName(adName);
                if (ad == null)
                {
                    return NotFound($"Ad with name '{adName}' not found.");
                }
                return Ok(ad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve ad: {ex.Message}");
            }
        }

        [HttpDelete("delete/{adName}")]
        public IActionResult DeleteAd(string adName)
        {
            try
            {
                Ad adToDelete = adService.GetAdByName(adName);

                adService.DeleteAd(adToDelete);
                return Ok("Ad deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete ad: {ex.Message}");
            }
        }

        [HttpGet("from-adset/{adSetId}")]
        public IActionResult GetAdsFromAdSet(string adSetId)
        {
            try
            {
                var ads = adService.GetAdsFromAdSet(adSetId);
                return Ok(ads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve ads: {ex.Message}");
            }
        }
    }
}
