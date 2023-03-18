using eMovies.Data.Enums;
using eMovies.Models;

namespace eMovies.Data;

public class Seed
{
    public static void GenerateSeed(IApplicationBuilder appBuilder)
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
                    Name = "Cinematics",
                    Logo = "https://yt3.ggpht.com/a/AATXAJz8UN1YU6jIaS67F0wzD9tcvDS6p4x8kQMdSQ=s900-c-k-c0xffffffff-no-rj-mo",
                    Description = "A great place to go"
                },
                new Cinema()
                {
                    Name = "Sun Cinema",
                    Logo = "https://d32qys9a6wm9no.cloudfront.net/images/cinemas/large/5a/32d4a316df5fb81307ccacd0dd721c32.jpg?t=1584068882",
                    Description = "Ooh this seems nice"
                },
                new Cinema()
                {
                    Name = "Cinema Plus",
                    Logo = "https://th.bing.com/th/id/OIP.mMr3jqxaD8cS6ww2Ay5pFwHaFj?pid=ImgDet&rs=1",
                    Description = "It's alright I guess"
                },
                new Cinema()
                {
                    Name = "Screens of Play",
                    Logo = "https://th.bing.com/th/id/OIP.PTAAcWx66andJrqyDQJ82AHaFj?pid=ImgDet&rs=1",
                    Description = "Something here"
                },
                new Cinema()
                {
                    Name = "Film Matrix",
                    Logo = "https://th.bing.com/th/id/R.fec9b3c624d559f4f919bf59ff117e8d?rik=z36Bv12LKQznKA&pid=ImgRaw&r=0",
                    Description = "I get that reference"
                }
            });
            context.SaveChanges();
        }

        if (!context.Actors.Any())
        {
            context.Actors.AddRange(new List<Actor>()
            {
                new Actor()
                {
                    Name = "Elijah Wood",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.o_ZR147qM3CfPLBFdvRXOgHaKI?pid=ImgDet&rs=1",
                    Bio = "Elijah Wood is a versatile actor and producer who rose to fame as Frodo Baggins in the epic Lord of the Rings trilogy."
                },
                new Actor()
                {
                    Name = "Ian McKellen",
                    ProfilePictureURL = "",
                    Bio = ""
                },
                new Actor()
                {
                    Name = "Orlando Bloom",
                    ProfilePictureURL = "",
                    Bio = "Orlando Jonathan Blanchard Copeland Bloom (born 13 January 1977) is an English actor. He made his breakthrough as the character Legolas in The Lord of the Rings film series."
                },

                new Actor()
                {
                    Name = "Benedict Cumberbatch",
                    ProfilePictureURL = "",
                    Bio = "Actor Benedict Cumberbatch has performed in many films, television series, theatre productions, and recorded lines for various radio programs, narrations and video games."
                },
                new Actor()
                {
                    Name = "Keira Knightley",
                    ProfilePictureURL = "",
                    Bio = "Keira Christina Righton OBE is an English actress. Known for her work in both independent films and blockbusters, particularly period dramas, she has received several accolades."
                },

                new Actor()
                {
                    Name = "Jack Black",
                    ProfilePictureURL = "",
                    Bio = "The Dragon Warrior"
                },
                new Actor()
                {
                    Name = "Dustin Hoffman",
                    ProfilePictureURL = "",
                    Bio = ""
                },
                new Actor()
                {
                    Name = "Ian McShane",
                    ProfilePictureURL = "",
                    Bio = ""
                }
            });
            context.SaveChanges();
        }

        if (!context.Directors.Any())
        {
            context.Directors.AddRange(new List<Director>()
            {
                new Director()
                {
                    Name = "Peter Jackson",
                    ProfilePictureURL = "",
                    Bio = ""
                },
                new Director()
                {
                    Name = "Morten Tyldum",
                    ProfilePictureURL = "",
                    Bio = ""
                },
                new Director()
                {
                    Name = "Mark Osborne",
                    ProfilePictureURL = "",
                    Bio = ""
                }
            });
            context.SaveChanges();
        }

        if (!context.Movies.Any())
        {
            context.Movies.AddRange(new List<Movie>()
            {
                new Movie()
                {
                    Name = "The Hobbit: An Unexpected Journey",
                    Description = "A reluctant Hobbit, Bilbo Baggins, sets out to the Lonely Mountain with a spirited group of dwarves to reclaim their mountain home, and the gold within it from the dragon Smaug.",
                    Price = 39.50,
                    ImageURL = "",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10),
                    CinemaId = 3,
                    DirectorId = 1,
                    Category = MovieCategory.Adventure
                },
                new Movie()
                {
                    Name = "The Hobbit: The Desolation of Smaug",
                    Description = "The dwarves, along with Bilbo Baggins and Gandalf the Grey, continue their quest to reclaim Erebor, their homeland, from Smaug. Bilbo Baggins is in possession of a mysterious and magical ring.",
                    Price = 44.90,
                    ImageURL = "",
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(15),
                    CinemaId = 3,
                    DirectorId = 1,
                    Category = MovieCategory.Adventure
                },
                new Movie()
                {
                    Name = "The Hobbit: The Battle of the Five Armies",
                    Description = "Bilbo and company are forced to engage in a war against an array of combatants and keep the Lonely Mountain from falling into the hands of a rising darkness.",
                    Price = 59.50,
                    ImageURL = "",
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(30),
                    CinemaId = 3,
                    DirectorId = 1,
                    Category = MovieCategory.Adventure
                },
                new Movie()
                {
                    Name = "The Imitation Game",
                    Description = "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians while attempting to come to terms with his troubled private life.",
                    Price = 23.50,
                    ImageURL = "",
                    StartDate = DateTime.Now.AddDays(-5),
                    EndDate = DateTime.Now.AddDays(10),
                    CinemaId = 2,
                    DirectorId = 2,
                    Category = MovieCategory.War
                },
                new Movie()
                {
                    Name = "Kung Fu Panda",
                    Description = "To everyone's surprise, including his own, Po, an overweight, clumsy panda, is chosen as protector of the Valley of Peace. His suitability will soon be tested as the valley's arch-enemy is on his way.",
                    Price = 39.50,
                    ImageURL = "",
                    StartDate = DateTime.Now.AddDays(-20),
                    EndDate = DateTime.Now.AddDays(5),
                    CinemaId = 5,
                    DirectorId = 3,
                    Category = MovieCategory.Cartoon
                }
            });
            context.SaveChanges();
        }

        if (!context.Actors_Movies.Any())
        {
            context.Actors_Movies.AddRange(new List<ActorMovie>()
            {
                new ActorMovie()
                {
                    MovieId = 1,
                    ActorId = 1,
                    Character = "Frodo Baggins"
                },
                new ActorMovie()
                {
                    MovieId = 1,
                    ActorId = 2,
                    Character = "Gandalf The Gray"
                },
                new ActorMovie()
                {
                    MovieId = 1,
                    ActorId = 3,
                    Character = "Legolas"
                },

                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 1,
                    Character = "Frodo Baggins"
                },
                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 2,
                    Character = "Gandalf The Gray"
                },
                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 3,
                    Character = "Legolas"
                },

                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 1,
                    Character = "Frodo Baggins"
                },
                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 2,
                    Character = "Gandalf The Gray"
                },
                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 3,
                    Character = "Legolas"
                },

                new ActorMovie()
                {
                    MovieId = 4,
                    ActorId = 4,
                    Character = "Alan Turing"
                },
                new ActorMovie()
                {
                    MovieId = 4,
                    ActorId = 5,
                    Character = "Joan Clarke"
                },

                new ActorMovie()
                {
                    MovieId = 5,
                    ActorId = 6,
                    Character = "Po (voice)"
                },
                new ActorMovie()
                {
                    MovieId = 5,
                    ActorId = 7,
                    Character = "Master Shifu (voice)"
                },
                new ActorMovie()
                {
                    MovieId = 5,
                    ActorId = 8,
                    Character = "Tai Lung (voice)"
                }
            });
            context.SaveChanges();
        }
    }
}
