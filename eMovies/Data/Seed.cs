using eMovies.Models;
using eMovies.Models.Enums;
using Microsoft.AspNetCore.Identity;

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
                    ProfilePictureURL = "https://th.bing.com/th/id/R.e226f72b85ad0ba9a1d25202cbdbdabb?rik=Trxnqnb%2fXABAmw&pid=ImgRaw&r=0",
                    Bio = "Elijah Wood is a versatile actor and producer who rose to fame as Frodo Baggins in the epic Lord of the Rings trilogy."
                },
                new Actor()
                {
                    Name = "Ian McKellen",
                    ProfilePictureURL = "https://th.bing.com/th/id/R.e33dd22597ae77b2251f1ad729dd9384?rik=O95qVEqHGWsghg&pid=ImgRaw&r=0",
                    Bio = "Ian McKellen is a revered, award-winning British actor of stage and screen known for his starring roles in 'The Lord of the Rings' and 'X-Men' films."
                },
                new Actor()
                {
                    Name = "Orlando Bloom",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.YJTmtT9B7bppRuXqmogCswHaHU?pid=ImgDet&rs=1",
                    Bio = "Orlando Jonathan Blanchard Copeland Bloom (born 13 January 1977) is an English actor. He made his breakthrough as the character Legolas in The Lord of the Rings film series."
                },

                new Actor()
                {
                    Name = "Benedict Cumberbatch",
                    ProfilePictureURL = "https://th.bing.com/th/id/R.a070dec4e7e9b74404114e35a9a0ec7f?rik=az0B8BC%2bqguOqA&pid=ImgRaw&r=0",
                    Bio = "Actor Benedict Cumberbatch has performed in many films, television series, theatre productions, and recorded lines for various radio programs, narrations and video games."
                },
                new Actor()
                {
                    Name = "Keira Knightley",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.ZZHTh3fgECEkEHrzORJtcQHaHa?pid=ImgDet&rs=1",
                    Bio = "Keira Christina Righton OBE is an English actress. Known for her work in both independent films and blockbusters, particularly period dramas, she has received several accolades."
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
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.bigr5yf3tzul8dYiaPzbTgHaHa?pid=ImgDet&rs=1",
                    Bio = "Sir Peter Robert Jackson ONZ KNZM (born 31 October 1961) is a New Zealand film director, screenwriter and producer. He is best known as the director, writer and producer of the Lord of the Rings trilogy (2001–2003) and the Hobbit trilogy (2012–2014)."
                },
                new Director()
                {
                    Name = "Morten Tyldum",
                    ProfilePictureURL = "https://th.bing.com/th/id/R.3478f542495a87507dec59151e65e7f1?rik=HY17OPde2lbYYA&riu=http%3a%2f%2fwww.indiewire.com%2fwp-content%2fuploads%2f2016%2f06%2fmorten-tyldum-for-indiewire.jpg%3fw%3d780&ehk=ovQdzoOwS7rQhkLtnUxPLWyiHPImjrWT1QdHyBwq%2bZI%3d&risl=&pid=ImgRaw&r=0",
                    Bio = "Morten Tyldum (born 19 May 1967) is a Norwegian film director. He is best known in his native Norway for directing the thriller film Headhunters (2011), based on the novel by Jo Nesbø, and internationally for directing the historical drama The Imitation Game (2014), for which he was nominated for the Academy Award for Best Director."
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
                    ImageURL = "https://th.bing.com/th/id/R.e21f7fd45a770f481f275030a6e25c1f?rik=NVKrC2L%2fzt28JA&riu=http%3a%2f%2fcontent9.flixster.com%2fmovie%2f11%2f17%2f02%2f11170263_800.jpg&ehk=rg%2br%2bEVaCKbWSjY%2boz6Ke5eadZF9MgxoYoGre8oR3Fs%3d&risl=&pid=ImgRaw&r=0",
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
                    ImageURL = "https://th.bing.com/th/id/OIP._AWQua901tukexSsdbr6IgHaLH?pid=ImgDet&rs=1",
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
                    ImageURL = "https://th.bing.com/th/id/R.16736172a2cfe1e212e3cc884d514f63?rik=6ej6uucBbqKbfA&riu=http%3a%2f%2fwww.blackfilm.com%2fread%2fwp-content%2fuploads%2f2014%2f10%2fThe-Hobbit-The-Battle-Of-The-Five-Armies-poster-3.jpg&ehk=%2bPV0hPJ8FCTSTlMBlqcZnCwXz1ycl3eZ6ETla10o40o%3d&risl=&pid=ImgRaw&r=0",
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
                    ImageURL = "https://th.bing.com/th/id/R.2541c8b6a92c2747c84a01e148b2052b?rik=XOVwCEPyV6bkgg&riu=http%3a%2f%2fis4.mzstatic.com%2fimage%2fthumb%2fVideo2%2fv4%2f56%2fad%2faa%2f56adaa45-57b0-6722-9ac6-be653f41eff0%2fsource%2f1400x2100sr.jpg&ehk=48P9HJoeeRPMyBeFB2VisL6Q%2bHE7Y%2fidxIY%2f%2fhPcm%2b8%3d&risl=&pid=ImgRaw&r=0",
                    StartDate = DateTime.Now.AddDays(-5),
                    EndDate = DateTime.Now.AddDays(10),
                    CinemaId = 2,
                    DirectorId = 2,
                    Category = MovieCategory.War
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
                    ActorId = 1
                },
                new ActorMovie()
                {
                    MovieId = 1,
                    ActorId = 2
                },
                new ActorMovie()
                {
                    MovieId = 1,
                    ActorId = 3
                },

                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 1
                },
                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 2
                },
                new ActorMovie()
                {
                    MovieId = 2,
                    ActorId = 3
                },

                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 1
                },
                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 2
                },
                new ActorMovie()
                {
                    MovieId = 3,
                    ActorId = 3
                },

                new ActorMovie()
                {
                    MovieId = 4,
                    ActorId = 4
                },
                new ActorMovie()
                {
                    MovieId = 4,
                    ActorId = 5
                }
            });
            context.SaveChanges();
        }
    }

    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder appBuilder)
    {
        using var serviceScope = appBuilder.ApplicationServices.CreateScope();
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        }
        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var adminUser = await userManager.FindByEmailAsync("admin@emovies.com");
        if (adminUser == null)
        {
            var newAdminUser = new User()
            {
                FullName = "Admin User",
                UserName = "Admin",
                Email = "admin@emovies.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newAdminUser, "Admin@123");
            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        }

        var user = await userManager.FindByEmailAsync("user@emovies.com");
        if (user == null)
        {
            var newUser = new User()
            {
                FullName = "Simple User",
                UserName = "User",
                Email = "user@emovies.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newUser, "User@123");
            await userManager.AddToRoleAsync(newUser, UserRoles.User);
        }
    }
}
