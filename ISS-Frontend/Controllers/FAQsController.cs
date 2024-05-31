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
    public class FAQsController : Controller
    {
        private readonly ISS_FrontendContext _context;
        private readonly IFAQService _faqService;

        public FAQsController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            _faqService = new FAQService(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: FAQs
        public IActionResult Index()
        {
            var faqs = _faqService.GetAllFAQs();
            return View(faqs);
        }

        // GET: FAQs/Details/5
        public IActionResult Details(int id)
        {
            var fAQ = _faqService.GetFAQById(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // GET: FAQs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FAQs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Question,Answer,Topic")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                _faqService.AddSubmittedQuestion(fAQ);
                return RedirectToAction(nameof(Index));
            }
            return View(fAQ);
        }

        // GET: FAQs/Edit/5
        public IActionResult Edit(int id)
        {
            var fAQ = _faqService.GetFAQById(id);
            if (fAQ == null)
            {
                return NotFound();
            }
            return View(fAQ);
        }

        // POST: FAQs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Question,Answer,Topic")] FAQ fAQ)
        {
            if (id != fAQ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _faqService.UpdateFAQ(id, fAQ);
                }
                catch (Exception)
                {
                    if (!FAQExists(fAQ.Id))
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
            return View(fAQ);
        }

        // GET: FAQs/Delete/5
        public IActionResult Delete(int id)
        {
            var fAQ = _faqService.GetFAQById(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // POST: FAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _faqService.DeleteFAQ(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
            return _faqService.GetFAQById(id) != null;
        }
    }
}
