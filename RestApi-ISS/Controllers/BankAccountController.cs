using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Iss.Database;

namespace RestApi_ISS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly DatabaseContext context;

        public BankAccountController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBankAccounts()
        {
            try
            {
                var bankAccounts = await context.Set<BankAccount>().ToListAsync();
                return Ok(bankAccounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve bank accounts: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            try
            {
                var bankAccount = await context.Set<BankAccount>().FindAsync(id);
                if (bankAccount == null)
                {
                    return NotFound($"Bank account with ID '{id}' not found.");
                }
                return Ok(bankAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve bank account: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostBankAccount([FromBody] BankAccount bankAccount)
        {
            try
            {
                context.Set<BankAccount>().Add(bankAccount);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.Id }, bankAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add bank account: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccount(int id, [FromBody] BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return BadRequest("ID mismatch.");
            }

            context.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound($"Bank account with ID '{id}' not found.");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update bank account: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            try
            {
                var bankAccount = await context.Set<BankAccount>().FindAsync(id);
                if (bankAccount == null)
                {
                    return NotFound($"Bank account with ID '{id}' not found.");
                }

                context.Set<BankAccount>().Remove(bankAccount);
                await context.SaveChangesAsync();

                return Ok("Bank account deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete bank account: {ex.Message}");
            }
        }

        private bool BankAccountExists(int id)
        {
            return context.Set<BankAccount>().Any(e => e.Id == id);
        }
    }
}
