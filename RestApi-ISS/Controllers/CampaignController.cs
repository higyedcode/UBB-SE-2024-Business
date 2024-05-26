using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class CampaignDTO
    {
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string AdAccountId { get; set; }
        public List<string> AdSetsNames { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService campaignService;
        private readonly IAdSetService adSetService;

        public CampaignController(ICampaignService campaignService, IAdSetService adSetService)
        {
            this.campaignService = campaignService;
            this.adSetService = adSetService;
        }

        [HttpPost("add")]
        public IActionResult AddCampaign([FromBody] CampaignDTO campaignDto)
        {
            try
            {
                List<AdSet> adSets = new List<AdSet>();

                foreach (var adSetName in campaignDto.AdSetsNames)
                {
                    AdSet adSet = adSetService.GetAdSetByName(new AdSet() { Name = adSetName });
                    adSets.Add(adSet);
                }

                Campaign campaignToAdd = new Campaign()
                {
                    CampaignId = campaignDto.CampaignId,
                    CampaignName = campaignDto.CampaignName,
                    StartDate = campaignDto.StartDate,
                    Duration = campaignDto.Duration,
                    AdAccountId = campaignDto.AdAccountId,
                    AdSets = adSets
                };

                campaignService.AddCampaign(campaignToAdd);
                return Ok("Campaign added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add campaign: {ex.Message}");
            }
        }

        [HttpGet("getbyname/{campaignName}")]
        public IActionResult GetCampaignByName(string campaignName)
        {
            try
            {
                var campaign = campaignService.GetCampaignByName(new Campaign() { CampaignName = campaignName });
                if (campaign == null)
                {
                    return NotFound("Campaign not found.");
                }
                return Ok(campaign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get campaign by name: {ex.Message}");
            }
        }

        [HttpDelete("delete/{campaignName}")]
        public IActionResult DeleteCampaign(string campaignName)
        {
            try
            {
                campaignService.DeleteCampaign(new Campaign() { CampaignName = campaignName });
                return Ok("Campaign deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete campaign: {ex.Message}");
            }
        }

        [HttpPost("addadset/{campaignName}/{adSetName}")]
        public IActionResult AddAdSetToCampaign(string campaignName, string adSetName)
        {
            try
            {
                // Retrieve campaign and ad set from DTO
                Campaign campaign = this.campaignService.GetCampaignByName(new Campaign() { CampaignName = campaignName });
                AdSet adSet = this.adSetService.GetAdSetByName(new AdSet() { Name = adSetName });

                campaignService.AddAdSetToCampaign(campaign, adSet);
                return Ok("Ad set added to campaign successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad set to campaign: {ex.Message}");
            }
        }

        [HttpDelete("deleteadset/{campaignName}/{adSetName}")]
        public IActionResult DeleteAdSetFromCampaign(string campaignName, string adSetName)
        {
            try
            {
                // Retrieve campaign and ad set from DTO
                Campaign campaign = this.campaignService.GetCampaignByName(new Campaign() { CampaignName = campaignName });
                AdSet adSet = this.adSetService.GetAdSetByName(new AdSet() { Name = adSetName });

                campaignService.DeleteAdSetFromCampaign(campaign, adSet);
                return Ok("Ad set removed from campaign successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to remove ad set from campaign: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateCampaign([FromBody] Campaign campaignToUpdate)
        {
            try
            {
                campaignService.UpdateCampaign(campaignToUpdate);
                return Ok("Campaign updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update campaign: {ex.Message}");
            }
        }
    }
}
