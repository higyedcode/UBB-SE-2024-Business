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
using Microsoft.Extensions.Hosting;
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

namespace NamespaceGPT_ASP.NET_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ProjectDBContext context;

        public PostsController(ProjectDBContext context)
        {
            this.context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            return await context.Post.Select(element => BaseToDTOConverters.Converter_PostToDTO(element)).ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_PostToDTO(post);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDTO postDTO)
        {
            if (id != postDTO.Id)
            {
                return BadRequest();
            }

            var postRef = DTOToBaseConverters.Converter_DTOToPost(postDTO);

            context.Entry(postRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost(PostDTO postDTO)
        {
            Post postRef = DTOToBaseConverters.Converter_DTOToPost(postDTO);
            context.Post.Add(postRef);
            await context.SaveChangesAsync();

            postDTO.Id = postRef.Id;
            return CreatedAtAction("GetPost", new { id = postRef.Id }, postDTO);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            context.Post.Remove(post);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return context.Post.Any(e => e.Id == id);
        }
    }
}
