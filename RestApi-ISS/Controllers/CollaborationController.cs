using System.Collections.Generic;
using Azure.Core;
using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class AddCollaborationRequest
    {
        public string CollaborationTitle { get; set; }
        public string AdOverview { get; set; }
        public string Compensation { get; set; }
        public string ContentRequirements { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CollaborationController : ControllerBase
    {
        private readonly ICollaborationService collaborationService;

        public CollaborationController(ICollaborationService collaborationService)
        {
            this.collaborationService = collaborationService;
        }

        [HttpPost("add")]
        public IActionResult AddCollaboration([FromBody] AddCollaborationRequest request)
        {
            try
            {
                Collaboration collaboration = new Collaboration(
                    request.CollaborationTitle,
                    request.AdOverview,
                    request.Compensation,
                    request.ContentRequirements,
                    request.StartDate,
                    request.EndDate,
                    true);

                collaborationService.AddCollaboration(collaboration);
                return Ok("Collaboration added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add collaboration: {ex.Message}");
            }
        }

        [HttpGet("for-adaccount")]
        public IActionResult GetCollaborationForAdAccount()
        {
            try
            {
                var collaborations = collaborationService.GetCollaborationForAdAccount();
                return Ok(collaborations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve collaborations for ad account: {ex.Message}");
            }
        }

        [HttpGet("for-influencer")]
        public IActionResult GetCollaborationForInfluencer()
        {
            try
            {
                var collaborations = collaborationService.GetCollaborationForInfluencer();
                return Ok(collaborations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve collaborations for influencer: {ex.Message}");
            }
        }

        [HttpGet("active-for-adaccount")]
        public IActionResult GetActiveCollaborationForAdAccount()
        {
            try
            {
                var activeCollaborations = collaborationService.GetActiveCollaborationForAdAccount();
                return Ok(activeCollaborations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve active collaborations for ad account: {ex.Message}");
            }
        }
    }
}
