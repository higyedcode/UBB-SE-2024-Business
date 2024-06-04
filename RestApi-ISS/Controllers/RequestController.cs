using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpGet("getAllRequestsInfluencer")]
        public IActionResult GetAllRequestsForInfluencer()
        {
            try
            {
                var allRequests = requestService.GetRequestsForInfluencer();
                return Ok("Requests retrieved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllRequestsAddAccount")]
        public IActionResult GetAllRequestsAddAccount()
        {
            try
            {
                var allRequests = requestService.GetRequestsForAdAccount();
                return Ok("Requests retrieved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{requesTitle}")]
        public IActionResult DeleteRequest(string title)
        {
            try
            {
                requestService.DeleteRequest(requestService.GetRequestWithTitle(title));
                return Ok("Request deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete request: {ex.Message}");
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateRequest([FromBody] Request request)
        {
            try
            {
                requestService.UpdateRequest(requestService.GetRequestWithTitle(request.CollaborationTitle), request.Compensation, request.ContentRequirements);
                return Ok("Request updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update request: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public IActionResult AddRequest([FromBody] Request request)
        {
            try
            {
                requestService.AddRequest(request);
                return Ok("Request added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add request: {ex.Message}");
            }
        }
    }
}
