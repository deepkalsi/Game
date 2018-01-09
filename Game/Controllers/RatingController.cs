using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game.Controllers
{
    [Produces("application/json")]
    [Route("api/Rating")]
    public class RatingController : Controller
    {
        private readonly CloudprojectContext _context;
        public RatingController(CloudprojectContext context)
        {
            _context = context;
        }

        // GET: api/Rating
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

            var games = await _context.Games.SingleOrDefaultAsync(m => m.ReleaseYear.Equals(2015));
           // var game = await _context.Games.Except(m1 =>m1.ReleaseYear.);
         
               // var games = _context.Database.ExecuteSqlCommand("Select * from games where releaseyear<=2015");

            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }
    }
}