﻿using MovieAppWithAPI.Models;
using Newtonsoft.Json;
namespace MovieAppWithAPI.Services
{
    public class API : IAPI
    {
        Movie movie = new Movie();
        public static string APIKey = "9adad78f3fmsh65443a93600444dp17223ejsn9ecd90763758"; //do not steal my API key,use your own
        HttpClient client = new HttpClient();
        public async Task<Movie> GetMovies()
        {
            string reponse = await client.GetStringAsync($"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={movie.IMDBId}&rapidapi-key={APIKey}");
            Movie movieObject = JsonConvert.DeserializeObject<Movie>(reponse);
            return movieObject;
        }

    }
}