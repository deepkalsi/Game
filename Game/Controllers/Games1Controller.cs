using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Game.Models;

namespace Game.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class Games1Controller : Controller
    {
        private readonly CloudprojectContext _context;

        public Games1Controller(CloudprojectContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<Games> GetGames()
        {
            return _context.Games;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games = await _context.Games.SingleOrDefaultAsync(m => m.GameId == id);

            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames([FromRoute] int id, [FromBody] Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games.GameId)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        [HttpPost]
        public async Task<IActionResult> PostGames([FromBody] Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Games.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGames", new { id = games.GameId }, games);
        }

        // DELETE: api/Games1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games = await _context.Games.SingleOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Games.Remove(games);
            await _context.SaveChangesAsync();

            return Ok(games);
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}