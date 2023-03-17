using eMovies.Models;

namespace eMovies.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder appBuilder)
    {
        using var serviceScope = appBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated();

        if (!context.Cinemas.Any())
        {
            context.Cinemas.AddRange(new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "Cinema 1",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                    Description = "Yay"
                }
            });

            context.SaveChanges();
        }

        if (!context.Actors.Any())
        {
            context.SaveChanges();
        }

        if (!context.Producers.Any())
        {
            context.SaveChanges();
        }

        if (!context.Movies.Any())
        {
            context.SaveChanges();
        }

        if (!context.Actors_Movies.Any())
        {
            context.SaveChanges();
        }
    }
}
