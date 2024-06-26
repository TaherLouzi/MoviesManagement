using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
        {
            return await _context.Ratings.Include(r => r.Movie).Include(r => r.User).ToListAsync();
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsForMovie(int movieId)
        {
            var ratings = await _context.Ratings.Include(r => r.User).Where(r => r.MovieId == movieId).ToListAsync();

            if (ratings == null || ratings.Count == 0)
            {
                return NotFound();
            }

            return ratings;
        }

        [Authorize(Policy = "ObserverPolicy")]
        [HttpPost("{movieId}")]
        public async Task<ActionResult<Rating>> PostRating(int movieId, Rating rating)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingRating = await _context.Ratings.FirstOrDefaultAsync(r => r.MovieId == movieId && r.UserId == userId);

            if (existingRating != null)
            {
                return BadRequest("l'utilisateur a déja noté ce film.");
            }

            rating.MovieId = movieId;
            rating.UserId = userId;

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatings", new{id = rating.Id }, rating);
        }
    }
}
