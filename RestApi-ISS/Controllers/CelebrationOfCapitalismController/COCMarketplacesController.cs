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
    public class COCMarketplacesController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCMarketplacesController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/Marketplaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplaceDTO>>> GetMarketplace()
        {
            return await context.COCMarketplace.Select(element => BaseToDTOConverters.Converter_MarketplaceToDTO(element)).ToListAsync();
        }

        // GET: api/Marketplaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketplaceDTO>> GetMarketplace(int id)
        {
            var marketplace = await context.COCMarketplace.FindAsync(id);

            if (marketplace == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_MarketplaceToDTO(marketplace);
        }

        // PUT: api/Marketplaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketplace(int id, MarketplaceDTO marketplaceDTO)
        {
            if (id != marketplaceDTO.Id)
            {
                return BadRequest();
            }

            var marketplaceRef = DTOToBaseConverters.Converter_DTOToMarketplace(marketplaceDTO);
            context.Entry(marketplaceRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketplaceExists(id))
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

        // POST: api/Marketplaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MarketplaceDTO>> PostMarketplace(MarketplaceDTO marketplaceDTO)
        {
            var marketplaceRef = DTOToBaseConverters.Converter_DTOToMarketplace(marketplaceDTO);
            context.COCMarketplace.Add(marketplaceRef);
            await context.SaveChangesAsync();

            marketplaceDTO.Id = marketplaceRef.Id;
            return CreatedAtAction("GetMarketplace", new { id = marketplaceRef.Id }, marketplaceDTO);
        }

        // DELETE: api/Marketplaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketplace(int id)
        {
            var marketplace = await context.COCMarketplace.FindAsync(id);
            if (marketplace == null)
            {
                return NotFound();
            }

            context.COCMarketplace.Remove(marketplace);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarketplaceExists(int id)
        {
            return context.COCMarketplace.Any(e => e.Id == id);
        }
    }
}
