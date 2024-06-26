using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public int Stars { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
