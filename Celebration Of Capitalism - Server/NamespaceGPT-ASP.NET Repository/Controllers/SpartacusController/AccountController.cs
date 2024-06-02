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
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public AccountController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccount()
        {
            return await context.Account.Select(element => BaseToDTOConverters.Converter_AccountToDTO(element)).ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{username}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(string username)
        {
            var account = await context.Account.FindAsync(username);

            if (account == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_AccountToDTO(account);
        }

        // PUT: api/Accounts/5
        [HttpPut("{username}")]
        public async Task<IActionResult> PutAccount(string username, AccountDTO account)
        {
            if (username != account.Username)
            {
                return BadRequest();
            }

            context.Entry(account).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(username))
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

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> PostAccount(AccountDTO account)
        {
            context.Account.Add(DTOToBaseConverters.Converter_DTOToAccount(account));
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { username = account.Username }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var account = await context.Account.FindAsync(username);
            if (account == null)
            {
                return NotFound();
            }

            context.Account.Remove(account);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(string username)
        {
            return context.Account.Any(e => e.Username == username);
        }
    }
}
