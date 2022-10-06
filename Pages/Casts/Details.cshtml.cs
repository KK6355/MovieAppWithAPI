using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieAppWithAPI.Data;
using MovieAppWithAPI.Models;

namespace MovieAppWithAPI.Pages.Casts
{
    public class DetailsModel : PageModel
    {
        private readonly MovieAppWithAPI.Data.ApplicationDbContext _context;

        public DetailsModel(MovieAppWithAPI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cast Cast { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }
            else 
            {
                Cast = cast;
            }
            return Page();
        }
    }
}
