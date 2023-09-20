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
    public class AwardsAndHonorController : ControllerBase
    {
        private readonly ResumeBuildContext _context;

        public AwardsAndHonorController(ResumeBuildContext context)
        {
            _context = context;
        }

        // GET: api/AwardsAndHonor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardsAndHonor>>> GetAwardsAndHonors()
        {
            var awardsAndHonors =  _context.AwardsAndHonors.ToList();
            return Ok(awardsAndHonors);
        }

        // GET: api/AwardsAndHonor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardsAndHonor>> GetAwardsAndHonor(int id)
        {
            var awardAndHonor = await _context.AwardsAndHonors.FindAsync(id);

            if (awardAndHonor == null)
            {
                return NotFound();
            }

            return Ok(awardAndHonor);
        }

        // POST: api/AwardsAndHonor
        [HttpPost]
        public async Task<ActionResult<AwardsAndHonor>> PostAwardsAndHonor(AwardsAndHonor awardAndHonor)
        {
            _context.AwardsAndHonors.Add(awardAndHonor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAwardsAndHonor), new { id = awardAndHonor.Id }, awardAndHonor);
        }

        // PUT: api/AwardsAndHonor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAwardsAndHonor(int id, AwardsAndHonor awardAndHonor)
        {
            if (id != awardAndHonor.Id)
            {
                return BadRequest();
            }

            _context.Entry(awardAndHonor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardsAndHonorExists(id))
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

        // DELETE: api/AwardsAndHonor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAwardsAndHonor(int id)
        {
            var awardAndHonor = await _context.AwardsAndHonors.FindAsync(id);
            if (awardAndHonor == null)
            {
                return NotFound();
            }

            _context.AwardsAndHonors.Remove(awardAndHonor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AwardsAndHonorExists(int id)
        {
            return _context.AwardsAndHonors.Any(e => e.Id == id);
        }
    }
}
