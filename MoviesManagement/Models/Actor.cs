using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
