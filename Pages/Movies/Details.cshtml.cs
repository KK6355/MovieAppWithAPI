using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieAppWithAPI.Data;
using MovieAppWithAPI.Models;
using MovieAppWithAPI.Services;

namespace MovieAppWithAPI.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IAPI _api;

        public DetailsModel(ApplicationDbContext context, IAPI api)
        {
            _context = context;
            _api = api;
        }

      public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.MovieId == id);
            Movie movieAPI = await _api.GetMovies(movie.IMDBId, "9adad78f3fmsh65443a93600444dp17223ejsn9ecd90763758");
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movieAPI;
            }
            return Page();
            
           
        }
    }
}
