using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieAppWithAPI.Models
{
public class Cast
{
        public Guid Id { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Screen Name")]
        public string? ScreenName { get; set; }
        public Guid? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
