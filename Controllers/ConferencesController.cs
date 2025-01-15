using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceAPI.Models;

namespace ConferenceAPI.Controllers
{
    [Route("api/v1/conferences")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConferencesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Conferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conference>>> GetConference()
        {
            return await _context.Conference.ToListAsync();
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conference>> GetConference(int id)
        {
            var conference = await _context.Conference.FindAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            return conference;
        }

        // PUT: api/Conferences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConference(int id, Conference conference)
        {
            if (id != conference.Id)
            {
                return BadRequest();
            }

            _context.Entry(conference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceExists(id))
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

        // POST: api/Conferences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conference>> PostConference(Conference conference)
        {
            _context.Conference.Add(conference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConference", new { id = conference.Id }, conference);
        }

        // DELETE: api/Conferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConference(int id)
        {
            var conference = await _context.Conference.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }

            _context.Conference.Remove(conference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conference.Any(e => e.Id == id);
        }
    }
}
