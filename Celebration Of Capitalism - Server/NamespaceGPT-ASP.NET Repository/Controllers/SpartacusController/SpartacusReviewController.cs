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
    public class SpartacusReviewController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public SpartacusReviewController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/SpartacusReview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpartacusReviewDTO>>> GetSpartacusReviews()
        {
            return await context.SpartacusReview.Select(element => BaseToDTOConverters.Converter_SpartacusReviewToDTO(element)).ToListAsync();
        }

        // GET: api/SpartacusReview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpartacusReviewDTO>> GetSpartacusReview(int id)
        {
            var review = await context.SpartacusReview.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_SpartacusReviewToDTO(review);
        }

        // PUT: api/SpartacusReview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpartacusReview(int id, SpartacusReviewDTO reviewDTO)
        {
            if (id != reviewDTO.Id)
            {
                return BadRequest();
            }

            var reviewRef = DTOToBaseConverters.Converter_DTOToSpartacusReview(reviewDTO);

            context.Entry(reviewRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpartacusReviewExists(id))
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

        // POST: api/SpartacusReview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpartacusReviewDTO>> PostSpartacusReview(SpartacusReviewDTO reviewDTO)
        {
            SpartacusReview reviewRef = DTOToBaseConverters.Converter_DTOToSpartacusReview(reviewDTO);
            context.SpartacusReview.Add(reviewRef);
            await context.SaveChangesAsync();

            reviewDTO.Id = reviewRef.Id;
            return CreatedAtAction("GetReview", new { id = reviewRef.Id }, reviewDTO);
        }

        // DELETE: api/SpartacusReview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpartacusReview(int id)
        {
            var review = await context.SpartacusReview.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            context.SpartacusReview.Remove(review);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpartacusReviewExists(int id)
        {
            return context.SpartacusReview.Any(e => e.Id == id);
        }
    }
}
