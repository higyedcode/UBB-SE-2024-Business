using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
	public class COCRegisterController : Controller
	{
		private readonly ICOCUserService userService;
		public COCRegisterController(COCUserService userService)
		{
			this.userService = userService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult RegisterAndRedirect(COCUser user)
		{
			try
			{
				int queryResult = userService.UserExists(user);
				if (queryResult != -1)
				{
					return RedirectToAction("Privacy", "Home");
				}
				int addedUserId = userService.AddUser(user);
				if (addedUserId == -1)
				{
					return RedirectToAction("Privacy", "Home");
				}
				HttpContext.Session.SetString("userID", addedUserId.ToString());
				return RedirectToAction("Index", "UserDashboard");
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				return RedirectToAction("Privacy", "Home");
			}
		}
		public IActionResult LoginRedirect()
		{
			return RedirectToAction("Index", "Login");
		}
	}
}
