using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.DTOs;
using NamespaceGPT_ASP.NET_Repository.DatabaseContext;
using NamespaceGPT_ASP.NET_Repository.Utils;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivitiesController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public UserActivitiesController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/UserActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserActivityDTO>>> GetUserActivity()
        {
            return await context.UserActivity.Select(element => BaseToDTOConverters.Converter_UserActivityToDTO(element)).ToListAsync();
        }

        // GET: api/UserActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserActivityDTO>> GetUserActivity(int id)
        {
            var userActivity = await context.UserActivity.FindAsync(id);

            if (userActivity == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_UserActivityToDTO(userActivity);
        }

        // PUT: api/UserActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserActivity(int id, UserActivityDTO userActivityDTO)
        {
            if (id != userActivityDTO.Id)
            {
                return BadRequest();
            }

            var userActivityRef = DTOToBaseConverters.Converter_DTOToUserActivity(userActivityDTO);
            context.Entry(userActivityRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserActivity>> PostUserActivity(UserActivityDTO userActivityDTO)
        {
            var userActivityRef = DTOToBaseConverters.Converter_DTOToUserActivity(userActivityDTO);
            context.UserActivity.Add(userActivityRef);
            await context.SaveChangesAsync();

            userActivityDTO.Id = userActivityRef.Id;
            return CreatedAtAction("GetUserActivity", new { id = userActivityRef.Id }, userActivityDTO);
        }

        // DELETE: api/UserActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserActivity(int id)
        {
            var userActivity = await context.UserActivity.FindAsync(id);
            if (userActivity == null)
            {
                return NotFound();
            }

            context.UserActivity.Remove(userActivity);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserActivityExists(int id)
        {
            return context.UserActivity.Any(e => e.Id == id);
        }
    }
}
