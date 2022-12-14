using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MovieAppWithAPI.Services;
using MovieAppWithAPI.Models;
using Microsoft.EntityFrameworkCore;
using MovieAppWithAPI.Operations;
using System.Collections.Generic;

namespace MovieAppWithAPI.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
      
        private readonly IAPI _api;
        public List<Movie> MovieList { get; set; }
        public string IMDBId { get; set; } = "";
        public List<string> IMDBIdList { get; set; }
        public string APIKey = "YOUROWNKEY";


        public IndexModel(IAPI api)
        {
            _api = api;
            MovieList = new List<Movie>();
            IMDBIdList = new List<string>
            {
                "tt0118799",
                "tt0245429",
                "tt0816692",
                "tt0108052",
                "tt0468569",
                "tt0088763",
                "tt1675434",
                "tt0253474"
            };
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            foreach (var IMDBId in IMDBIdList)
            {
                Movie movie = new Movie();
                Movie movieAPI = await _api.GetMovies(IMDBId, APIKey);
                if (movieAPI != null)
                {
                    movie.IMDBId = IMDBId;
                    movie.Title = movieAPI.Title;
                    movie.Image = movieAPI.Image;
                    movie.Description = movieAPI.Description;
                }
                else
                {
                    movie.Title = "Invail API";
                    movie.Image = "Invail API";
                    movie.Description = "Invail API";
                }
                MovieList.Add(movie);

            }
            MovieList = MovieList.OrderBy(x => x.Title).ToList();



            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (IMDBId != null)
            {
                StaticList.RenderedMovies.Add(IMDBId);
            }
            IMDBIdList.AddRange(StaticList.RenderedMovies);

            foreach (var IMDBId in IMDBIdList)
            {
                Movie movie = new Movie();
                Movie movieAPI = await _api.GetMovies(IMDBId, APIKey);
                if (movieAPI != null)
                {
                    movie.IMDBId = IMDBId;
                    movie.Title = movieAPI.Title;
                    movie.Image = movieAPI.Image;
                    movie.Description = movieAPI.Description;

                }
                else
                {
                    movie.Title = "Invail API";
                    movie.Image = "Invail API";
                    movie.Description = "Invail API";
                }
                MovieList.Add(movie);

            }
            MovieList = MovieList.OrderBy(x => x.Title).ToList();

            return Page();

        }
    }
}
