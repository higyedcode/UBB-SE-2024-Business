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
    public class AdSetsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IAdSetService adSetService;

        public AdSetsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            adSetService = new AdSetServiceRest(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: AdSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdSet.ToListAsync());
        }

        // GET: AdSets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adSet = await _context.AdSet
                .FirstOrDefaultAsync(m => m.AdSetId == id);
            if (adSet == null)
            {
                return NotFound();
            }

            return View(adSet);
        }

        // GET: AdSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdSetId,AdAccountId,CampaignId,Name,TargetAudience")] AdSet adSet)
        {
            adSetService.AddAdSet(adSet);
            return RedirectToAction("Index", "AdAccounts");
        }

        // GET: AdSets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adSet = await _context.AdSet.FindAsync(id);
            if (adSet == null)
            {
                return NotFound();
            }
            return View(adSet);
        }

        // POST: AdSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AdSetId,AdAccountId,CampaignId,Name,TargetAudience")] AdSet adSet)
        {
            if (id != adSet.AdSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdSetExists(adSet.AdSetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adSet);
        }

        // GET: AdSets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adSet = await _context.AdSet
                .FirstOrDefaultAsync(m => m.AdSetId == id);
            if (adSet == null)
            {
                return NotFound();
            }

            return View(adSet);
        }

        // POST: AdSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adSet = await _context.AdSet.FindAsync(id);
            if (adSet != null)
            {
                _context.AdSet.Remove(adSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdSetExists(string id)
        {
            return _context.AdSet.Any(e => e.AdSetId == id);
        }
    }
}
