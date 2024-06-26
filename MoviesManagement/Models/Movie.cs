using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Directors { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Synopsis { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
