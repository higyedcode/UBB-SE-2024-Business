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
    public class NewProductAlertsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public NewProductAlertsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/COCNewProductAlerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewProductAlertDTO>>> GetNewProductAlerts()
        {
            return await context.COCNewProductAlerts.Select(element => BaseToDTOConverters.Converter_NewProductAlertToDTO(element)).ToListAsync();
        }

        // GET: api/COCNewProductAlerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewProductAlertDTO>> GetNewProductAlert(int id)
        {
            var newProductAlert = await context.COCNewProductAlerts.FindAsync(id);

            if (newProductAlert == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_NewProductAlertToDTO(newProductAlert);
        }

        // PUT: api/COCNewProductAlerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewProductAlert(int id, NewProductAlertDTO newProductAlertDTO)
        {
            if (id != newProductAlertDTO.Id)
            {
                return BadRequest();
            }

            var newProductAlertRef = DTOToBaseConverters.Converter_DTOToNewProductAlert(newProductAlertDTO);
            context.Entry(newProductAlertRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewProductAlertExists(id))
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

        // POST: api/COCNewProductAlerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewProductAlertDTO>> PostNewProductAlert(NewProductAlertDTO newProductAlertDTO)
        {
            var newProductAlertRef = DTOToBaseConverters.Converter_DTOToNewProductAlert(newProductAlertDTO);
            context.COCNewProductAlerts.Add(newProductAlertRef);
            await context.SaveChangesAsync();

            newProductAlertDTO.Id = newProductAlertRef.Id;
            return CreatedAtAction("GetNewProductAlert", new { id = newProductAlertRef.Id }, newProductAlertDTO);
        }

        // DELETE: api/COCNewProductAlerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewProductAlert(int id)
        {
            var newProductAlert = await context.COCNewProductAlerts.FindAsync(id);
            if (newProductAlert == null)
            {
                return NotFound();
            }

            context.COCNewProductAlerts.Remove(newProductAlert);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewProductAlertExists(int id)
        {
            return context.COCNewProductAlerts.Any(e => e.Id == id);
        }
    }
}
