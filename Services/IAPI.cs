using MovieAppWithAPI.Models;

namespace MovieAppWithAPI.Services
{
    public interface IAPI
    {
        Task<Movie> GetMovies();
    }
}