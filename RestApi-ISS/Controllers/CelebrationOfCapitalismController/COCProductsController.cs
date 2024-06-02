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
    public class COCProductsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCProductsController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
        {
            return await context.COCProduct.Select(element => BaseToDTOConverters.Converter_ProductToDTO(element)).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await context.COCProduct.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_ProductToDTO(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest();
            }

            var productRef = DTOToBaseConverters.Converter_DTOToProduct(productDTO);
            context.Entry(productRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO productDTO)
        {
            var productRef = DTOToBaseConverters.Converter_DTOToProduct(productDTO);
            context.COCProduct.Add(productRef);
            await context.SaveChangesAsync();

            productDTO.Id = productRef.Id;
            return CreatedAtAction("GetProduct", new { id = productRef.Id }, productDTO);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.COCProduct.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            context.COCProduct.Remove(product);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return context.COCProduct.Any(e => e.Id == id);
        }
    }
}
