using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Entity;
using ISS_Frontend.Service;
using Microsoft.Identity.Client;

namespace ISS_Frontend.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public ICampaignService campaignService;
        public IAdAccountService adAccountService;

        public CampaignsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            campaignService = new CampaignServiceRest(httpClient);
            adAccountService = new AdAccountServiceRest(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: Campaigns
        public async Task<IActionResult> Index(string id)
        {
            var campaign = campaignService.GetCampaignByName(new Campaign { CampaignName = id });
            ViewData["AdAccountId"] = campaign.AdAccountId;
            return View(campaign);
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = campaignService.GetCampaignByName(new Campaign { CampaignName = id});
            ViewData["AdAccountId"] = campaign.AdAccountId;
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create(string adAccountId)
        {
            if (string.IsNullOrEmpty(adAccountId))
            {
                return NotFound();
            }

            ViewData["AdAccountId"] = adAccountId; // Pass the AdAccountId to the view
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampaignId,CampaignName,StartDate,Duration,AdAccountId")] Campaign campaign)
        {
            campaign.AdSets = new List<AdSet>(); // Ensure AdSets is initialized
            campaignService.AddCampaign(campaign);
            return RedirectToAction("Index", "AdAccounts");
        }

        // GET: Campaigns/Edit/{name}
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = campaignService.GetCampaignByName(new Campaign { CampaignName = id });
            if (campaign == null)
            {
                return NotFound();
            }

            ViewData["AdAccountId"] = campaign.AdAccountId;
            return View(campaign);
        }

        // POST: Campaigns/Edit/{name}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CampaignId,CampaignName,StartDate,Duration,AdAccountId")] Campaign campaign)
        {

            try
            {
                campaignService.UpdateCampaign(campaign);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(campaign.CampaignId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "AdAccounts");

        }

        // GET: Campaigns/Delete/{name}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = campaignService.GetCampaignByName(new Campaign { CampaignName = id });
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/{name}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var campaign = campaignService.GetCampaignByName(new Campaign { CampaignName = id });
            if (campaign != null)
            {
                campaignService.DeleteCampaign(campaign);
            }

            return RedirectToAction("Index", "AdAccounts");
        }

        private bool CampaignExists(string id)
        {
            return _context.Campaign.Any(e => e.CampaignName == id);
        }
    }
}
