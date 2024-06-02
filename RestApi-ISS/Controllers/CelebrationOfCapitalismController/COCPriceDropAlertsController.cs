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
    public class COCPriceDropAlertsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCPriceDropAlertsController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/COCPriceDropAlerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceDropAlertDTO>>> GetPriceDropAlerts()
        {
            return await context.COCPriceDropAlerts.Select(element => BaseToDTOConverters.Converter_PriceDropAlertToDTO(element)).ToListAsync();
        }

        // GET: api/COCPriceDropAlerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceDropAlertDTO>> GetPriceDropAlert(int id)
        {
            var priceDropAlert = await context.COCPriceDropAlerts.FindAsync(id);

            if (priceDropAlert == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_PriceDropAlertToDTO(priceDropAlert);
        }

        // PUT: api/COCPriceDropAlerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceDropAlert(int id, PriceDropAlertDTO priceDropAlertDTO)
        {
            if (id != priceDropAlertDTO.Id)
            {
                return BadRequest();
            }

            var priceDropAlertRef = DTOToBaseConverters.Converter_DTOToPriceDropAlert(priceDropAlertDTO);
            context.Entry(priceDropAlertRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceDropAlertExists(id))
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

        // POST: api/COCPriceDropAlerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriceDropAlertDTO>> PostPriceDropAlert(PriceDropAlertDTO priceDropAlertDTO)
        {
            var priceDropAlertRef = DTOToBaseConverters.Converter_DTOToPriceDropAlert(priceDropAlertDTO);
            context.COCPriceDropAlerts.Add(priceDropAlertRef);
            await context.SaveChangesAsync();

            priceDropAlertDTO.Id = priceDropAlertRef.Id;
            return CreatedAtAction("GetPriceDropAlert", new { id = priceDropAlertRef.Id }, priceDropAlertDTO);
        }

        // DELETE: api/COCPriceDropAlerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceDropAlert(int id)
        {
            var priceDropAlert = await context.COCPriceDropAlerts.FindAsync(id);
            if (priceDropAlert == null)
            {
                return NotFound();
            }

            context.COCPriceDropAlerts.Remove(priceDropAlert);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriceDropAlertExists(int id)
        {
            return context.COCPriceDropAlerts.Any(e => e.Id == id);
        }
    }
}
