﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAppWithAPI.Data;
using MovieAppWithAPI.Models;

namespace MovieAppWithAPI.Pages.Casts
{
    public class CreateModel : PageModel
    {
        private readonly MovieAppWithAPI.Data.ApplicationDbContext _context;

        public CreateModel(MovieAppWithAPI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title");
            return Page();
        }

        [BindProperty]
        public Cast Cast { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cast.Add(Cast);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
