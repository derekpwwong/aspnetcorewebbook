using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using System;
using System.Linq;
using WebApplication1.Data;

namespace MvcBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any Books.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                     new Book
                     {
                         Title = "Detroit Metal City",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Music Comedy",
                         Price = 7.99M
                     },

                     new Book
                     {
                         Title = "The Girl Who Lept Through Time",
                         ReleaseDate = DateTime.Parse("2014-4-03"),
                         Genre = "Action Adventure",
                         Price = 8.99M
                     },

                     new Book
                     {
                         Title = "Harry Potter: The Philosopher's Stone",
                         ReleaseDate = DateTime.Parse("2000-7-23"),
                         Genre = "Comedy Magic",
                         Price = 9.99M
                     },

                   new Book
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
