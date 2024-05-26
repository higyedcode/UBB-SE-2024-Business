using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class AddAdSetRequest
    {
        public string Name { get; set; }

        public string TargetAudience { get; set; }

        public List<string> AdsNames { get; set; }
    }

    public class UpdateAdSetRequest
    {
        public string AdSetId { get; set; }
        public string Name { get; set; }
        public string TargetAudience { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AdSetController : ControllerBase
    {
        private readonly IAdSetService adSetService;
        private readonly IAdService adService;

        public AdSetController(IAdSetService adSetService, IAdService adService)
        {
            this.adSetService = adSetService;
            this.adService = adService;
        }

        [HttpPost("add")]
        public IActionResult AddAdSet([FromBody] AddAdSetRequest addAdSetRequest)
        {
            try
            {
                List<Ad> adSetAds = new List<Ad>();

                foreach (var adName in addAdSetRequest.AdsNames)
                {
                    Ad ad = adService.GetAdByName(adName);

                    adSetAds.Add(ad);
                }

                AdSet adSet = new AdSet(addAdSetRequest.Name, addAdSetRequest.TargetAudience, adSetAds);

                adSetService.AddAdSet(adSet);
                return Ok("Ad set added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad set: {ex.Message}");
            }
        }

        [HttpPost("{adSetName}/ads/{adName}")]
        public IActionResult AddAdToAdSet(string adSetName, string adName)
        {
            try
            {
                // Retrieve adSet and ad from repository based on IDs
                AdSet adSet = adSetService.GetAdSetByName(new AdSet() { Name = adSetName });
                Ad ad = adService.GetAdByName(adName);

                if (adSet == null || ad == null)
                {
                    return NotFound("Ad set or ad not found.");
                }

                adSetService.AddAdToAdSet(adSet, ad);
                return Ok("Ad added to ad set successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad to ad set: {ex.Message}");
            }
        }

        [HttpDelete("{adSetName}/ads/{adName}")]
        public IActionResult RemoveAdFromAdSet(string adSetName, string adName)
        {
            try
            {
                // Retrieve adSet and ad from repository based on IDs
                AdSet adSet = adSetService.GetAdSetByName(new AdSet() { Name = adSetName });
                Ad ad = adService.GetAdByName(adName);

                if (adSet == null || ad == null)
                {
                    return NotFound("Ad set or ad not found.");
                }

                adSetService.RemoveAdFromAdSet(adSet, ad);
                return Ok("Ad removed from ad set successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to remove ad from ad set: {ex.Message}");
            }
        }

        [HttpGet("notincampaign")]
        public IActionResult GetAdSetsThatAreNotInCampaign()
        {
            try
            {
                var adSets = adSetService.GetAdSetsThatAreNotInCampaign();
                return Ok(adSets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get ad sets: {ex.Message}");
            }
        }

        [HttpGet("incampaign/{id}")]
        public IActionResult GetAdSetsInCampaign(string id)
        {
            try
            {
                var adSets = adSetService.GetAdSetsInCampaign(id);
                return Ok(adSets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get ad sets: {ex.Message}");
            }
        }

        [HttpGet("getbyname/{adSetName}")]
        public IActionResult GetAdSetByName(string adSetName)
        {
            try
            {
                var retrievedAdSet = adSetService.GetAdSetByName(new AdSet() { Name = adSetName });
                if (retrievedAdSet == null)
                {
                    return NotFound("Ad set not found.");
                }
                return Ok(retrievedAdSet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get ad set: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateAdSet([FromBody] UpdateAdSetRequest updateAdSetRequest)
        {
            try
            {
                AdSet adSet = this.adSetService.GetAdSetByName(new AdSet() { Name = updateAdSetRequest.Name });
                adSet.Name = updateAdSetRequest.Name;
                adSet.TargetAudience = updateAdSetRequest.TargetAudience;

                adSetService.UpdateAdSet(adSet);
                return Ok("Ad set updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update ad set: {ex.Message}");
            }
        }

        [HttpDelete("{adSetName}")]
        public IActionResult DeleteAdSet(string adSetName)
        {
            try
            {
                // Retrieve ad set from repository based on ID
                AdSet adSet = adSetService.GetAdSetByName(new AdSet() { Name = adSetName });
                if (adSet == null)
                {
                    return NotFound("Ad set not found.");
                }

                adSetService.DeleteAdSet(adSet);
                return Ok("Ad set deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete ad set: {ex.Message} \n\n {ex.InnerException}");
            }
        }
    }
}
