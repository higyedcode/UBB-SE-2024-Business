using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Iss.Database;
using Iss.User;
using Iss.Service;
using RestApi_ISS.Service;

namespace RestApi_ISS.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                userService.LoginUser(loginRequest.Username, loginRequest.Password);
                return Ok("Login successful.");
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
