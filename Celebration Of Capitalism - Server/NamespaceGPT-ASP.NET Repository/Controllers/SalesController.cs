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
    public class SalesController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public SalesController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetSale()
        {
            return await context.Sale.Select(element => BaseToDTOConverters.Converter_SaleToDTO(element)).ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDTO>> GetSale(int id)
        {
            var sale = await context.Sale.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_SaleToDTO(sale);
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, SaleDTO saleDTO)
        {
            if (id != saleDTO.Id)
            {
                return BadRequest();
            }

            var saleRef = DTOToBaseConverters.Converter_DTOToSale(saleDTO);
            context.Entry(saleRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(SaleDTO saleDTO)
        {
            var saleRef = DTOToBaseConverters.Converter_DTOToSale(saleDTO);
            context.Sale.Add(saleRef);
            await context.SaveChangesAsync();

            saleDTO.Id = saleRef.Id;
            return CreatedAtAction("GetSale", new { id = saleRef.Id }, saleDTO);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            context.Sale.Remove(sale);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return context.Sale.Any(e => e.Id == id);
        }
    }
}
