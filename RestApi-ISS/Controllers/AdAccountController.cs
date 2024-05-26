using Microsoft.AspNetCore.Mvc;
using Iss.Service;
using Iss.Entity;

namespace IssApi.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AdAccountRequest
    {
        public string CompanyName { get; set; }
        public string DomainOfActivity { get; set; }
        public string Password { get; set; }
        public string SiteUrl { get; set; }
        public string HeadQuarters { get; set; }
        public string CIF { get; set; }
        public string AuthorisingInstitution { get; set; }
    }

    public class EditAccountRequest
    {
        public string NameOfCompany { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AdAccountController : ControllerBase
    {
        private readonly IAdAccountService adAccountService;

        public AdAccountController(IAdAccountService adAccountService)
        {
            this.adAccountService = adAccountService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginRequest loginRequest)
        {
            try
            {
                adAccountService.Login(loginRequest.Username, loginRequest.Password);
                return Ok("Login successful.");
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("account")]
        public ActionResult<AdAccount> GetAccount()
        {
            try
            {
                var account = adAccountService.GetAccount();
                if (account == null)
                {
                    return NotFound("Account not found.");
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ads")]
        public ActionResult<List<Ad>> GetAdsForCurrentUser()
        {
            try
            {
                var ads = adAccountService.GetAdsForCurrentUser();
                return Ok(ads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("adsets")]
        public ActionResult<List<AdSet>> GetAdSetsForCurrentUser()
        {
            try
            {
                var adSets = adAccountService.GetAdSetsForCurrentUser();
                return Ok(adSets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("campaigns")]
        public ActionResult<List<Campaign>> GetCampaignsForCurrentUser()
        {
            try
            {
                var campaigns = adAccountService.GetCampaignsForCurrentUser();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add")]
        public ActionResult AddAdAccount([FromBody] AdAccountRequest accountRequest)
        {
            try
            {
                AdAccount account = new AdAccount();
                account.NameOfCompany = accountRequest.CompanyName;
                account.DomainOfActivity = accountRequest.DomainOfActivity;
                account.Password = accountRequest.Password;
                account.SiteUrl = accountRequest.SiteUrl;
                account.HeadquartersLocation = accountRequest.HeadQuarters;
                account.TaxIdentificationNumber = accountRequest.CIF;
                account.AuthorisingInstituion = accountRequest.AuthorisingInstitution;

                adAccountService.AddAdAccount(account);
                return Ok("Account added successfully.");
            }
            catch (Exception ex)
            {
                // server error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("edit")]
        public ActionResult EditAdAccount([FromBody] EditAccountRequest editAccountRequest)
        {
            try
            {
                adAccountService.EditAdAccount(editAccountRequest.NameOfCompany, editAccountRequest.Url, editAccountRequest.Password, editAccountRequest.Location);
                return Ok("Account edited successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
