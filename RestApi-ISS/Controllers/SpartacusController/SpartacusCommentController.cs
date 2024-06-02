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
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpartacusCommentController : ControllerBase
    {
        private readonly DatabaseContext context;

        public SpartacusCommentController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetComment()
        {
            return await context.SpartacusComment.Select(element => BaseToDTOConverters.Converter_CommentToDTO(element)).ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int id)
        {
            var comment = await context.SpartacusComment.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_CommentToDTO(comment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentDTO comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            context.Entry(comment).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<CommentDTO>> PostComment(CommentDTO comment)
        {
            context.SpartacusComment.Add(DTOToBaseConverters.Converter_DTOToComment(comment));
            await context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await context.SpartacusComment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            context.SpartacusComment.Remove(comment);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return context.SpartacusComment.Any(e => e.Id == id);
        }
    }
}
