using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Celebration_Of_Capitalism___The_Finale.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
	public class COCUserDashboardController : Controller
	{
		private readonly ICOCProductService productService;
		private readonly ICOCUserService userService;

		public COCUserDashboardController(COCProductService productService, COCUserService userService)
		{
			this.productService = productService;
			this.userService = userService;
		}

		// GET: UserDashboardController
		public ActionResult Index()
		{
			IEnumerable<COCProduct> products = productService.GetAllProducts();

			return View(products.ToList());
		}

		// GET: UserDashboardController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: UserDashboardController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserDashboardController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserDashboardController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: UserDashboardController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserDashboardController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: UserDashboardController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
