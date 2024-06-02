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
    public class COCFavouriteProductsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCFavouriteProductsController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/FavouriteProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavouriteProductDTO>>> GetFavouriteProduct()
        {
            return await context.COCFavouriteProduct.Select(element => BaseToDTOConverters.Converter_FavouriteProductToDTO(element)).ToListAsync();
        }

        // GET: api/FavouriteProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavouriteProductDTO>> GetFavouriteProduct(int id)
        {
            var favouriteProduct = await context.COCFavouriteProduct.FindAsync(id);

            if (favouriteProduct == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_FavouriteProductToDTO(favouriteProduct);
        }

        // PUT: api/FavouriteProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavouriteProduct(int id, FavouriteProductDTO favouriteProductDTO)
        {
            if (id != favouriteProductDTO.Id)
            {
                return BadRequest();
            }

            var favouriteProductRef = DTOToBaseConverters.Converter_DTOToFavouriteProduct(favouriteProductDTO);
            context.Entry(favouriteProductRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteProductExists(id))
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

        // POST: api/FavouriteProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavouriteProductDTO>> PostFavouriteProduct(FavouriteProductDTO favouriteProductDTO)
        {
            var favouriteProductRef = DTOToBaseConverters.Converter_DTOToFavouriteProduct(favouriteProductDTO);
            context.COCFavouriteProduct.Add(favouriteProductRef);
            await context.SaveChangesAsync();

            favouriteProductDTO.Id = favouriteProductRef.Id;
            return CreatedAtAction("GetFavouriteProduct", new { id = favouriteProductRef.Id }, favouriteProductDTO);
        }

        // DELETE: api/FavouriteProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavouriteProduct(int id)
        {
            var favouriteProduct = await context.COCFavouriteProduct.FindAsync(id);
            if (favouriteProduct == null)
            {
                return NotFound();
            }

            context.COCFavouriteProduct.Remove(favouriteProduct);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteProductExists(int id)
        {
            return context.COCFavouriteProduct.Any(e => e.Id == id);
        }
    }
}
