using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.DTOs;
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;
using NamespaceGPT_ASP.NET_Repository.DatabaseContext;
using NamespaceGPT_ASP.NET_Repository.Utils;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public FAQsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/FAQs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQDTO>>> GetFAQs()
        {
            return await context.FAQ.Select(element => BaseToDTOConverters.Converter_FAQToDTO(element)).ToListAsync();
        }

        // GET: api/FAQs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FAQDTO>> GetFAQ(int id)
        {
            var faq = await context.FAQ.FindAsync(id);

            if (faq == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_FAQToDTO(faq);
        }

        // PUT: api/FAQs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFAQ(int id, FAQDTO faqDTO)
        {
            if (id != faqDTO.Id)
            {
                return BadRequest();
            }

            var faqRef = DTOToBaseConverters.Converter_DTOToFAQ(faqDTO);

            context.Entry(faqRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id))
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

        // POST: api/FAQs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FAQDTO>> PostFAQ(FAQDTO faqDTO)
        {
            FAQ faqRef = DTOToBaseConverters.Converter_DTOToFAQ(faqDTO);
            context.FAQ.Add(faqRef);
            await context.SaveChangesAsync();

            faqDTO.Id = faqRef.Id;
            return CreatedAtAction("GetFAQ", new { id = faqRef.Id }, faqDTO);
        }

        // DELETE: api/FAQs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFAQ(int id)
        {
            var faq = await context.FAQ.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            context.FAQ.Remove(faq);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FAQExists(int id)
        {
            return context.FAQ.Any(e => e.Id == id);
        }
    }
}
