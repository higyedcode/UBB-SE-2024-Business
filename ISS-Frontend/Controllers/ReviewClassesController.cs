using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Entity;
using ISS_Frontend.Service;

namespace ISS_Frontend.Controllers
{
    public class ReviewClassesController : Controller
    {
        private readonly ISS_FrontendContext _context;
        private readonly IReviewService _reviewService;

        public ReviewClassesController(ISS_FrontendContext context, IReviewService reviewService)
        {
            _context = context;
            _reviewService = reviewService;
        }

        // GET: ReviewClasses
        public IActionResult Index()
        {
            var reviews = _reviewService.GetAllReviews();
            return View(reviews);
        }

        // GET: ReviewClasses/Details/5
        public IActionResult Details(int id)
        {
            var reviewClass = _reviewService.GetReviewById(id);
            if (reviewClass == null)
            {
                return NotFound();
            }

            return View(reviewClass);
        }

        // GET: ReviewClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,User,Review")] ReviewClass reviewClass)
        {
            if (ModelState.IsValid)
            {
                _reviewService.AddReview(reviewClass);
                return RedirectToAction(nameof(Index));
            }
            return View(reviewClass);
        }

        // GET: ReviewClasses/Edit/5
        public IActionResult Edit(int id)
        {
            var reviewClass = _reviewService.GetReviewById(id);
            if (reviewClass == null)
            {
                return NotFound();
            }
            return View(reviewClass);
        }

        // POST: ReviewClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,User,Review")] ReviewClass reviewClass)
        {
            if (id != reviewClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reviewService.UpdateReview(reviewClass);
                }
                catch (Exception)
                {
                    if (!ReviewClassExists(reviewClass.Id))
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
            return View(reviewClass);
        }

        // GET: ReviewClasses/Delete/5
        public IActionResult Delete(int id)
        {
            var reviewClass = _reviewService.GetReviewById(id);
            if (reviewClass == null)
            {
                return NotFound();
            }

            return View(reviewClass);
        }

        // POST: ReviewClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _reviewService.DeleteReview(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewClassExists(int id)
        {
            return _reviewService.GetReviewById(id) != null;
        }
    }
}
