using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieAppWithAPI.Data;
using MovieAppWithAPI.Models;

namespace MovieAppWithAPI.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieAppWithAPI.Data.ApplicationDbContext _context;

        public DetailsModel(MovieAppWithAPI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
