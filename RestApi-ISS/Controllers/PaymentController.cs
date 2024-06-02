using Iss.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class SubscriptionRequest
    {
        public string SubscriptionType { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("add-ad")]
        public IActionResult AddOneAd()
        {
            try
            {
                paymentService.AddOneAd();
                return Ok("Ad added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad: {ex.Message}");
            }
        }

        [HttpPost("add-adset")]
        public IActionResult AddOneAdSet()
        {
            try
            {
                paymentService.AddOneAdSet();
                return Ok("Ad set added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add ad set: {ex.Message}");
            }
        }

        [HttpPost("add-campaign")]
        public IActionResult AddOneCampaign()
        {
            try
            {
                paymentService.AddOneCampaign();
                return Ok("Campaign added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add campaign: {ex.Message}");
            }
        }

        [HttpPost("add-subscription")]
        public IActionResult AddSubscription([FromBody] SubscriptionRequest subscriptionRequest)
        {
            try
            {
                switch (subscriptionRequest.SubscriptionType.ToLower())
                {
                    case "basic":
                        paymentService.AddBasicSubscription();
                        break;
                    case "silver":
                        paymentService.AddSilverSubscription();
                        break;
                    case "gold":
                        paymentService.AddGoldSubscription();
                        break;
                    default:
                        return BadRequest("Invalid subscription type.");
                }
                return Ok($"Subscription '{subscriptionRequest.SubscriptionType}' added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add subscription: {ex.Message}");
            }
        }
    }
}
