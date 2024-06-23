using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Joseph Smith: Prophet of the Restoration",
                    ReleaseDate = DateTime.Parse("2005-12-17"),
                    Genre = "Biographical",
                    Rating = "PG",
                    Price = 0.00M
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Rating = "PG",
                    Price = 0.00M
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Drama",
                    Rating = "PG",
                    Price = 0.00M
                },
                new Movie
                {
                    Title = "17 Miracles",
                    ReleaseDate = DateTime.Parse("2011-06-03"),
                    Genre = "Historical Drama",
                    Rating = "PG",
                    Price = 0.00M
                }
            );
            context.SaveChanges();
        }
    }
}