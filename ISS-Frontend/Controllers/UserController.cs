using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISS_Frontend.Data;
using ISS_Frontend.Models;
using ISS_Frontend.Service;

namespace ISS_Frontend.Controllers
{
    public class UserController : Controller
    {
        private readonly ISS_FrontendContext _context;
        public IUserService userService;

        public UserController(ISS_FrontendContext context)
        {
            _context = context;
            HttpClient httpClient = new HttpClient();
            userService = new UserService(httpClient);
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
        }

        // GET: User/Login
        public IActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginUser(string username, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.LoginUser(username, password);
                    return RedirectToAction("Index", "Home");
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while trying to log in.");
                }
            }
            return View();
        }
    }
}
