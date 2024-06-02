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
    public class ReviewsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public ReviewsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReview()
        {
            return await context.COCReview.Select(element => BaseToDTOConverters.Converter_ReviewToDTO(element)).ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int id)
        {
            var review = await context.COCReview.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_ReviewToDTO(review);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewDTO reviewDTO)
        {
            if (id != reviewDTO.Id)
            {
                return BadRequest();
            }

            var reviewRef = DTOToBaseConverters.Converter_DTOToReview(reviewDTO);
            context.Entry(reviewRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO reviewDTO)
        {
            var reviewRef = DTOToBaseConverters.Converter_DTOToReview(reviewDTO);
            context.COCReview.Add(reviewRef);
            await context.SaveChangesAsync();

            reviewDTO.Id = reviewRef.Id;
            return CreatedAtAction("GetReview", new { id = reviewRef.Id }, reviewDTO);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await context.COCReview.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            context.COCReview.Remove(review);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return context.COCReview.Any(e => e.Id == id);
        }
    }
}
