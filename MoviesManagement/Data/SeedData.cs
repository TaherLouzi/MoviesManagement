using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesManagement.Data;
using MoviesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesManagement.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // DB est deja remplie
                if (context.Movies.Any())
                {
                    return; 
                }

                var actors = new List<Actor>
                {
                    new Actor { Name = "Tom Cruise", Gender = "Male" },
                    new Actor { Name = "Steve Segal", Gender = "Male" },
                    new Actor { Name = "Tom Hanks", Gender = "Male" },
                    new Actor { Name = "Brad Pitt", Gender = "Male" },
                    new Actor { Name = "Robert Deniro", Gender = "Male" },
                    new Actor { Name = "Al Paccino", Gender = "Male" },
                };

                context.Actors.AddRange(actors);
                context.SaveChanges();

                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Title = "the big short",
                        Duration = 180,
                        Directors = "steven spielberg",
                        Genre = "Drama",
                        ReleaseYear = 2018,
                        Synopsis = "Plusieurs personnes dans le secteur finnancier prevoient la bulle immobiliere de 2008",
                        MovieActors = new List<MovieActor>
                        {
                            new MovieActor { Actor = actors.Single(a => a.Name == "Tom Cruise") },
                            new MovieActor { Actor = actors.Single(a => a.Name == "Steve Segal") },
                            new MovieActor { Actor = actors.Single(a => a.Name == "Tom Hanks") },
                            new MovieActor { Actor = actors.Single(a => a.Name == "Brad Pitt") }
                        }
                    },
                    new Movie
                    {
                        Title = "margin call",
                        Duration = 221,
                        Directors = "Ford copolla",
                        Genre = "Thriler",
                        ReleaseYear = 2013,
                        Synopsis = "un employé tombe sur des secrets professionnels qui peuvent causer faillite a sa societé",
                        MovieActors = new List<MovieActor>
                        {
                            new MovieActor { Actor = actors.Single(a => a.Name == "Robert Deniro") },
                            new MovieActor { Actor = actors.Single(a => a.Name == "Al Paccino") },
                        }
                    }
                };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}

