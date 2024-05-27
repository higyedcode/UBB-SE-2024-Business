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

namespace ISS_Frontend.Controllers
{
    public class AdObject
    {
        /// <summary>
        /// Gets or sets the name of the product being advertised.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the path to the photo associated with the advertisement.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the description of the product being advertised.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the website link related to the advertisement.
        /// </summary>
        public string WebsiteLink { get; set; }


    }
    public class AdsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IAdService adService;


        

        public AdsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            adService = new AdServiceRest(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var ad = adService.GetAdByName(name);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdId,AdAccountId,AdSetId,ProductName,Photo,Description,WebsiteLink")] Ad ad)
        {
            
                adService.AddAd(ad);
                return RedirectToAction("Index", "AdAccounts");
            
            
        }

        // GET: Ads/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var ad = adService.GetAdByName(name);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ProductName,Photo,Description,WebsiteLink")] AdObject ad)
        {
            try {
                Ad adFound = adService.GetAdByName(ad.ProductName);
                adService.UpdateAd(adFound);
                }
                catch (Exception)
                {
                return NotFound();
                }
            return RedirectToAction("Index", "AdAccounts");

        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var ad = adService.GetAdByName(name);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string name)
        {
            var ad = adService.GetAdByName(name);
            if (ad != null)
            {
                adService.DeleteAd(ad);
            }

            return RedirectToAction("Index", "AdAccounts");
        }

        private bool AdExists(string name)
        {
            return (adService.GetAdByName(name) != null);
        }
    }
}
