using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.DTOs;
using Iss.Database;
using NamespaceGPT_ASP.NET_Repository.Utils;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COCBackInStockAlertsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCBackInStockAlertsController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/COCBackInStockAlerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BackInStockAlertDTO>>> GetBackInStockAlerts()
        {
            return await context.COCBackInStockAlerts.Select(element => BaseToDTOConverters.Converter_BackInStockAlertToDTO(element)).ToListAsync();
        }

        // GET: api/COCBackInStockAlerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BackInStockAlertDTO>> GetBackInStockAlert(int id)
        {
            var backInStockAlert = await context.COCBackInStockAlerts.FindAsync(id);

            if (backInStockAlert == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_BackInStockAlertToDTO(backInStockAlert);
        }

        // PUT: api/COCBackInStockAlerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBackInStockAlert(int id, BackInStockAlertDTO backInStockAlertDTO)
        {
            if (id != backInStockAlertDTO.Id)
            {
                return BadRequest();
            }

            var backInStockAlertRef = DTOToBaseConverters.Converter_DTOToBackInStockAlert(backInStockAlertDTO);
            context.Entry(backInStockAlertRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BackInStockAlertExists(id))
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

        // POST: api/COCBackInStockAlerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BackInStockAlertDTO>> PostBackInStockAlert(BackInStockAlertDTO backInStockAlertDTO)
        {
            var backInStockAlertRef = DTOToBaseConverters.Converter_DTOToBackInStockAlert(backInStockAlertDTO);
            context.COCBackInStockAlerts.Add(backInStockAlertRef);
            await context.SaveChangesAsync();

            backInStockAlertDTO.Id = backInStockAlertRef.Id;
            return CreatedAtAction("GetBackInStockAlert", new { id = backInStockAlertRef.Id }, backInStockAlertDTO);
        }

        // DELETE: api/COCBackInStockAlerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBackInStockAlert(int id)
        {
            var backInStockAlert = await context.COCBackInStockAlerts.FindAsync(id);
            if (backInStockAlert == null)
            {
                return NotFound();
            }

            context.COCBackInStockAlerts.Remove(backInStockAlert);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BackInStockAlertExists(int id)
        {
            return context.COCBackInStockAlerts.Any(e => e.Id == id);
        }
    }
}
