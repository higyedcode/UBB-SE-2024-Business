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
    public class InfluencersController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IInfluencerService influencerService;

        public InfluencersController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            influencerService = new InfluencerService(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: Influencers
        public async Task<IActionResult> Index()
        {
            var influencers = influencerService.GetAllInfluencers();
            return View(influencers);
        }

        // GET: Influencers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influencer = influencerService.GetInfluencerById((int)id);
            if (influencer == null)
            {
                return NotFound();
            }

            return View(influencer);
        }

        // GET: Influencers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Influencers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfluencerId,InfluencerName,FollowerCount,CollaborationPrice")] Influencer influencer)
        {
            if (ModelState.IsValid)
            {
                influencerService.AddInfluencer(influencer);
                return RedirectToAction(nameof(Index));
            }
            return View(influencer);
        }

        // GET: Influencers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influencer = influencerService.GetInfluencerById((int)id);

            if (influencer == null)
            {
                return NotFound();
            }
            return View(influencer);
        }

        // POST: Influencers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InfluencerId,InfluencerName,FollowerCount,CollaborationPrice")] Influencer influencer)
        {
            if (id != influencer.InfluencerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    influencerService.UpdateInfluencer(influencer);
                }
                catch (Exception)
                {
                    if (!InfluencerExists(influencer.InfluencerId))
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
            return View(influencer);
        }

        private bool InfluencerExists(int influencerId)
        {
            return (influencerService.GetInfluencerById(influencerId) != null);
        }

        // GET: Influencers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influencer = influencerService.GetInfluencerById(id);

            if (influencer == null)
            {
                return NotFound();
            }

            return View(influencer);
        }

        // POST: Influencers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                influencerService.DeleteInfluencer(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
