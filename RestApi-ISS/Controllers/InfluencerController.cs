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

        [HttpGet("GetAllInfluencers")]
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
    }
}
