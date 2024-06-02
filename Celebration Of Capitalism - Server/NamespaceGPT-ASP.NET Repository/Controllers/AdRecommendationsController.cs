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
    public class AdRecommendationsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public AdRecommendationsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/AdRecommendations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdRecommendationDTO>>> GetAdRecommendation()
        {
            return await context.COCAdRecommendation.Select(element => BaseToDTOConverters.Converter_AdRecommendationToDTO(element)).ToListAsync();
        }

        // GET: api/AdRecommendations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdRecommendationDTO>> GetAdRecommendation(int id)
        {
            var adRecommendation = await context.COCAdRecommendation.FindAsync(id);

            if (adRecommendation == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_AdRecommendationToDTO(adRecommendation);
        }

        // PUT: api/AdRecommendations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdRecommendation(int id, AdRecommendationDTO adRecommendationDTO)
        {
            if (id != adRecommendationDTO.Id)
            {
                return BadRequest();
            }

            var adRecommendationRef = DTOToBaseConverters.Converter_DTOToAdRecommendation(adRecommendationDTO);

            context.Entry(adRecommendationRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdRecommendationExists(id))
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

        // POST: api/AdRecommendations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdRecommendationDTO>> PostAdRecommendation(AdRecommendationDTO adRecommendationDTO)
        {
            COCAdRecommendation adRecommendationRef = DTOToBaseConverters.Converter_DTOToAdRecommendation(adRecommendationDTO);
            context.COCAdRecommendation.Add(adRecommendationRef);
            await context.SaveChangesAsync();

            adRecommendationDTO.Id = adRecommendationRef.Id;
            return CreatedAtAction("GetAdRecommendation", new { id = adRecommendationRef.Id }, adRecommendationDTO);
        }

        // DELETE: api/AdRecommendations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdRecommendation(int id)
        {
            var adRecommendation = await context.COCAdRecommendation.FindAsync(id);
            if (adRecommendation == null)
            {
                return NotFound();
            }

            context.COCAdRecommendation.Remove(adRecommendation);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdRecommendationExists(int id)
        {
            return context.COCAdRecommendation.Any(e => e.Id == id);
        }
    }
}
