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
    public class IndexModel : PageModel
    {
        private readonly MovieAppWithAPI.Data.ApplicationDbContext _context;

        public IndexModel(MovieAppWithAPI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cast> Cast { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cast != null)
            {
                Cast = await _context.Cast
                .Include(c => c.Movie).ToListAsync();
            }
        }
    }
}
