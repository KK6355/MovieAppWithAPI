namespace MovieAppWithAPI.Models
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public string? IMDBId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
