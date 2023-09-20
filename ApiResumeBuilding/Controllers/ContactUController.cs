using ApiResumeBuilding.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiResumeBuilding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUController : ControllerBase
    {
        private readonly ResumeBuildContext _context;

        public ContactUController(ResumeBuildContext context)
        {
            _context = context;
        }

        // GET: api/ContactU
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactU>>> GetContactUs()
        {
            var contactUs =  _context.ContactUs.ToList();
            return Ok(contactUs);
        }

        // GET: api/ContactU/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactU>> GetContactU(int id)
        {
            var contactU = await _context.ContactUs.FindAsync(id);

            if (contactU == null)
            {
                return NotFound();
            }

            return Ok(contactU);
        }

        // POST: api/ContactU
        [HttpPost]
        public async Task<ActionResult<ContactU>> PostContactU(ContactU contactU)
        {
            _context.ContactUs.Add(contactU);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactU), new { id = contactU.ContactUsId }, contactU);
        }

        // PUT: api/ContactU/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactU(int id, ContactU contactU)
        {
            if (id != contactU.ContactUsId)
            {
                return BadRequest();
            }

            _context.Entry(contactU).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactUExists(id))
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

        // DELETE: api/ContactU/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactU(int id)
        {
            var contactU = await _context.ContactUs.FindAsync(id);
            if (contactU == null)
            {
                return NotFound();
            }

            _context.ContactUs.Remove(contactU);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactUExists(int id)
        {
            return _context.ContactUs.Any(e => e.ContactUsId == id);
        }
    }
}
