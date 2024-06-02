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
    public class BusinessController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public BusinessController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BussinessDTO>>> GetBusiness()
        {
            return await context.SpartacusBusiness.Select(element => BaseToDTOConverters.Converter_BusinessToDTO(element)).ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BussinessDTO>> GetBusiness(int id)
        {
            var business = await context.SpartacusBusiness.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_BusinessToDTO(business);
        }

        // PUT: api/Businesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, BussinessDTO business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }

            context.Entry(business).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [HttpPost]
        public async Task<ActionResult<BussinessDTO>> PostBusiness(BussinessDTO business)
        {
            context.SpartacusBusiness.Add(DTOToBaseConverters.Converter_DTOToBusiness(business));
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { id = business.Id }, business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            var business = await context.SpartacusBusiness.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            context.SpartacusBusiness.Remove(business);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessExists(int id)
        {
            return context.SpartacusBusiness.Any(e => e.Id == id);
        }
    }
}
