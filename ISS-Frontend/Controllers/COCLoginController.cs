using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
    public class COCLoginController : Controller
    {
		private readonly ICOCUserService userService;
		public COCLoginController(COCUserService userService) 
		{
			this.userService = userService;
		}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginAndRedirect(COCUser user)
        {
			try
			{
				int queryResult = userService.UserExists(user);
				if (queryResult == -1)
				{
					return RedirectToAction("Privacy", "Home");  // this is our 404 page for now lmao
				}
				HttpContext.Session.SetString("userID", queryResult.ToString());
				return RedirectToAction("Index", "COCUserDashboard");  // in my case, successful login redirects you to the dashboard (item shop).
			}
			catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex.Message);  // this should never happen, but regardless should be investigated if it does; redirect to "404".
				return RedirectToAction("Privacy", "Home");
			}
		}

		public IActionResult LogoutAndRedirect(COCUser user)
		{
			try
			{
				HttpContext.Session.Clear(); // Clear the user session

				System.Diagnostics.Debug.WriteLine("User logged out successfully.");

				return RedirectToAction("Index", "COCLogin"); // Redirect to the login page (or any other page of your choice)
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);  // log the error
				return RedirectToAction("Privacy", "Home");  // redirect to the "404" page in case of an error
			}
		}
	}
}
