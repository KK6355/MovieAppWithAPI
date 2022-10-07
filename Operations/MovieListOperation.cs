using MovieAppWithAPI.Models;
using MovieAppWithAPI.Services;
namespace MovieAppWithAPI.Operations
{
    public class MovieListOperation
    {
        public async Task<List<Movie>> GetMovieList(List<Movie> MovieList, List<string> IMDBIdList, IAPI _api)
        {
            foreach (var IMDBId in IMDBIdList)
            {
                Movie movie = new Movie();
                Movie movieAPI = await _api.GetMovies(IMDBId, "9adad78f3fmsh65443a93600444dp17223ejsn9ecd90763758");
                if (movieAPI != null)
                {

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
            return MovieList = MovieList.OrderBy(x => x.Title).ToList();

            

        }
    }
}
