using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi_ISS.Entity;
using RestApi_ISS.Service;
namespace RestApi_ISS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : Controller
    {
        private readonly IInfluencerService influencerService;

        public InfluencerController(IInfluencerService service)
        {
            this.influencerService = service;
        }

        [HttpGet("getAllInfluencers")]
        public IActionResult GetAllInfluencers()
        {
            try
            {
                var influencers = influencerService.GetInfluencers();
                return Ok(influencers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetInfluencerById(int id)
        {
            try
            {
                var influencer = influencerService.GetInfluencerById(id);
                return Ok(influencer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult AddInfluencer(Influencer influencer)
        {
            try
            {
                influencerService.AddInfluencer(influencer);
                return Ok(influencer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteInfluencer(int id)
        {
            try
            {
                influencerService.DeleteInfluencer(id);
                return Ok("Influencer deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateRequest([FromBody] Influencer influencer)
        {
            try
            {
                influencerService.UpdateInfluencer(influencer);
                return Ok("influencer updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update influencer: {ex.Message}");
            }
        }
    }
}
