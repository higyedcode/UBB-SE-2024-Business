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
    public class RequestsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IRequestService requestService;

        public RequestsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            requestService = new RequestService(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049");
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var requests = requestService.GetAllRequestsInfluencer();
            return View(requests);
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = requestService.GetRequestById((int)id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaborationTitle,AdOverview,ContentRequirements,Compensation,StartDate,EndDate,InfluencerAccept,AdAccountAccept,RequestId,AdAccountId,InfluencerId")] Entity.Request request)
        {
            if (ModelState.IsValid)
            {
                requestService.AddRequest(request);
                return RedirectToAction(nameof(Index));
            }
           return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = requestService.GetRequestById((int)id);
            if (request == null)
            {
                return NotFound();
            }
           return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaborationTitle,AdOverview,ContentRequirements,Compensation,StartDate,EndDate,InfluencerAccept,AdAccountAccept,RequestId,AdAccountId,InfluencerId")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    requestService.UpdateRequest(request);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
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
           return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = requestService.GetRequestById((int)id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try { 
                requestService.DeleteRequest(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return requestService.GetRequestById(id) != null;
        }
    }
}
