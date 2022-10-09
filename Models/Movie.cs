
using System.ComponentModel.DataAnnotations;

namespace MovieAppWithAPI.Models
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        [Display(Name  = "IMDb Id")]
        public string? IMDBId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        [Display(Name = "Release Year")]
        public int? ReleaseYear { get; set; }
    }
}
