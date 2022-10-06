using MovieAppWithAPI.Models;
using Newtonsoft.Json;
namespace MovieAppWithAPI.Services
{
    public class API : IAPI
    {

        // public static string APIKey = "9adad78f3fmsh65443a93600444dp17223ejsn9ecd90763758"; //do not steal my API key,use your own
        HttpClient client = new HttpClient();
        public async Task<Movie> GetMovies(string IMDBId, string APIKey)
        {
            string response = await client.GetStringAsync($"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={IMDBId}&rapidapi-key={APIKey}");
            Movie movieObject = JsonConvert.DeserializeObject<Movie>(response);
            return movieObject;
        }


    }
}
