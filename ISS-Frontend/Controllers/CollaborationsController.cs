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
    public class CollaborationsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public ICollaborationService collaborationService;

        public CollaborationsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            collaborationService = new CollaborationServiceRest(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: Collaborations
        public async Task<IActionResult> Index()
        {
            return View(collaborationService.GetCollaborationForInfluencer());
        }

        // GET: Collaborations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TODO
            //var collaboration = collaborationService.GetCollaborationById((int)id);
            var collaboration = new Collaboration();
            if (collaboration == null)
            {
                return NotFound();
            }

            return View(collaboration);
        }

        // GET: Collaborations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collaborations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaborationId,CollaborationTitle,StartDate,Status,ContentRequirement,AdOverview,CollaborationFee,EndDate,AdAccountId,InfluencerId")] Collaboration collaboration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaboration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collaboration);
        }

        // GET: Collaborations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaboration = await _context.Collaboration.FindAsync(id);
            if (collaboration == null)
            {
                return NotFound();
            }
            return View(collaboration);
        }

        // POST: Collaborations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaborationId,CollaborationTitle,StartDate,Status,ContentRequirement,AdOverview,CollaborationFee,EndDate,AdAccountId,InfluencerId")] Collaboration collaboration)
        {
            if (id != collaboration.CollaborationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaboration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaborationExists(collaboration.CollaborationId))
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
            return View(collaboration);
        }

        // GET: Collaborations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TODO
            var collaboration = await _context.Collaboration
                .FirstOrDefaultAsync(m => m.CollaborationId == id);
            if (collaboration == null)
            {
                return NotFound();
            }

            return View(collaboration);
        }

        // POST: Collaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //TODO
            var collaboration = await _context.Collaboration.FindAsync(id);
            if (collaboration != null)
            {
                _context.Collaboration.Remove(collaboration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaborationExists(int id)
        {
            return _context.Collaboration.Any(e => e.CollaborationId == id);
        }
    }
}
