using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISS_FrontendContext _context;

        public AdminController(ISS_FrontendContext context)
        {
            _context = context;
        }

        public ActionResult AdminMainPage()
        {
            return View();
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminViewModels.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminViewModel = await _context.AdminViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminViewModel == null)
            {
                return NotFound();
            }

            return View(adminViewModel);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Questions")] AdminViewModel adminViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminViewModel);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminViewModel = await _context.AdminViewModels.FindAsync(id);
            if (adminViewModel == null)
            {
                return NotFound();
            }
            return View(adminViewModel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Questions")] AdminViewModel adminViewModel)
        {
            if (id != adminViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminViewModelExists(adminViewModel.Id))
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
            return View(adminViewModel);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminViewModel = await _context.AdminViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminViewModel == null)
            {
                return NotFound();
            }

            return View(adminViewModel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminViewModel = await _context.AdminViewModels.FindAsync(id);
            if (adminViewModel != null)
            {
                _context.AdminViewModels.Remove(adminViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminViewModelExists(int id)
        {
            return _context.AdminViewModels.Any(e => e.Id == id);
        }
    }
}
