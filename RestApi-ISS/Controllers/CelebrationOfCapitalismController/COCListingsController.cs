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
    public class COCListingsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCListingsController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/Listings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingDTO>>> GetListing()
        {
            return await context.COCListing.Select(element => BaseToDTOConverters.Converter_ListingToDTO(element)).ToListAsync();
        }

        // GET: api/Listings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListingDTO>> GetListing(int id)
        {
            var listing = await context.COCListing.FindAsync(id);

            if (listing == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_ListingToDTO(listing);
        }

        // PUT: api/Listings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListing(int id, ListingDTO listingDTO)
        {
            if (id != listingDTO.Id)
            {
                return BadRequest();
            }

            var listingRef = DTOToBaseConverters.Converter_DTOToListing(listingDTO);
            context.Entry(listingRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(id))
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

        // POST: api/Listings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListingDTO>> PostListing(ListingDTO listingDTO)
        {
            var listingRef = DTOToBaseConverters.Converter_DTOToListing(listingDTO);
            context.COCListing.Add(listingRef);
            await context.SaveChangesAsync();

            listingDTO.Id = listingRef.Id;
            return CreatedAtAction("GetListing", new { id = listingRef.Id }, listingDTO);
        }

        // DELETE: api/Listings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var listing = await context.COCListing.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }

            context.COCListing.Remove(listing);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListingExists(int id)
        {
            return context.COCListing.Any(e => e.Id == id);
        }
    }
}
