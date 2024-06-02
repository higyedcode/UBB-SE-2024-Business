﻿using System;
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
    public class COCUsersController : ControllerBase
    {
        private readonly DatabaseContext context;

        public COCUsersController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAppUser()
        {
            return await context.COCUser.Select(element => BaseToDTOConverters.Converter_UserToDTO(element)).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var user = await context.COCUser.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return BaseToDTOConverters.Converter_UserToDTO(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var userRef = DTOToBaseConverters.Converter_DTOToUser(userDTO);
            context.Entry(userRef).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            COCUser userRef = DTOToBaseConverters.Converter_DTOToUser(userDTO);
            context.COCUser.Add(userRef);
            await context.SaveChangesAsync();

            userDTO.Id = userRef.Id;
            return CreatedAtAction("GetUser", new { id = userRef.Id }, userDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await context.COCUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.COCUser.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return context.COCUser.Any(e => e.Id == id);
        }
    }
}
