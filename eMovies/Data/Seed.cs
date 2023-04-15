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
                },

                new Actor()
                {
                    Name = "Pedro Pascal",
                    ProfilePictureURL = "https://akns-images.eonline.com/eol_images/Entire_Site/2021118/rs_1024x759-210218040505-t6bigstock-Pedro-Pascal-at-the-World-prem-339979147.jpg?fit=around%7C1080:1080&output-quality=90&crop=1080:1080;center,top",
                    Bio = "José Pedro Balmaceda Pascal is a Chilean-born American actor. Since 2023, he has played Joel Miller in the HBO drama series The Last of Us. Time magazine named him one of the 100 most influential people in the world in 2023"
                },
                new Actor()
                {
                    Name = "Bella Ramsey",
                    ProfilePictureURL = "https://justbiography.com/wp-content/uploads/2020/06/95cf15c1a5fe0f044922cd8a0ebb4c662d-Bella-Ramsey.rsquare.w700.jpg",
                    Bio = "Isabella May Ramsey (born September 2003) is an English actor. Ramsey was cast in the lead role of Ellie for the HBO adaptation of the 2013 video game The Last of Us alongside fellow Game of Thrones alumnus Pedro Pascal."
                },

                new Actor()
                {
                    Name = "Joe Locke",
                    ProfilePictureURL = "https://th.bing.com/th/id/R.539e810ad9d4600ed47080e912a98c94?rik=kdVh4Cr8hVZsHA&pid=ImgRaw&r=0",
                    Bio = "Joseph William Locke (born 24 September 2003) is a Manx actor. He is known for his lead role as Charlie Spring in the Netflix teen series Heartstopper (since 2022), for which he received a nomination for the Children's and Family Emmy Award for Outstanding Lead Performance"
                },
                new Actor()
                {
                    Name = "Kit Connor",
                    ProfilePictureURL = "https://i.pinimg.com/736x/7e/a0/57/7ea0576b3e89ba2576b41ce3fa6a244a.jpg",
                    Bio = "Kit Sebastian Connor (born 8 March 2004) is an English actor. He gained recognition for his starring role as Nick Nelson in the Netflix teen series Heartstopper, for which he won the Children's and Family Emmy Award for Outstanding Lead Performance in 2022."
                },

                new Actor()
                {
                    Name = "Tobey Maguire",
                    ProfilePictureURL = "https://th.bing.com/th/id/R.5539fa5d3c49817bbd0b191a763c836c?rik=lcqTHAeef7IMTA&pid=ImgRaw&r=0",
                    Bio = "Tobias Vincent Maguireis an American actor and film producer. He is known for playing the title character from Sam Raimi's Spider-Man trilogy (2002–2007), a role he reprised in 2021's Spider-Man: No Way Home."
                },
                new Actor()
                {
                    Name = "Andrew Garfield",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.QmXupQXxGriV1U6ooStOyQHaGD?pid=ImgDet&rs=1",
                    Bio = "Andrew Russell Garfield is an English and American actor. He has received various accolades, including a Tony Award, a BAFTA TV Award and a Golden Globe Award, in addition to nominations for a Primetime Emmy Award, a Laurence Olivier Award and two Academy Awards. Time included Garfield on its list of 100 most influential people in the world in 2022."
                },
                new Actor()
                {
                    Name = "Tom Holland",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.rfqQY89Gaq1zVYqdOYIBKAHaGN?pid=ImgDet&rs=1",
                    Bio = "Thomas Stanley Holland (born 1 June 1996) is an English actor. His accolades include a British Academy Film Award and three Saturn Awards. Some publications have called him one of the most popular actors of his generation."
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
                },
                new Director()
                {
                    Name = "Neil Druckmann",
                    ProfilePictureURL = "https://th.bing.com/th/id/OIP.RR3KHa9rLirIu1-GXC-ArQHaGe?pid=ImgDet&rs=1",
                    Bio = "Neil Druckmann is an Israeli-American writer, creative director, designer, and programmer who has been co-president (alongside Evan Wells) of the video game developer Naughty Dog since 2020. He is best known for his work on the Naughty Dog game franchises Uncharted and The Last of Us, having co-created the latter."
                },
                new Director()
                {
                    Name = "Euros Lyn",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Euros_Lyn.jpg/330px-Euros_Lyn.jpg",
                    Bio = "Euros Lyn is a Welsh film and television director, best known for his work in Doctor Who, Sherlock, Black Mirror, Daredevil, His Dark Materials and Heartstopper."
                },
                new Director()
                {
                    Name = "Jon Watts",
                    ProfilePictureURL = "https://marriedbiography.com/wp-content/uploads/2017/06/jon-watts.jpg",
                    Bio = "Jonathan Watts (born June 28, 1981) is an American filmmaker. His credits include directing the Marvel Cinematic Universe (MCU) superhero films Spider-Man: Homecoming, Spider-Man: Far From Home, and Spider-Man: No Way Home."
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
                },
                new Movie()
                {
                    Name = "The Last Of Us",
                    Description = "Joel and Ellie, a pair connected through the harshness of the world they live in, are forced to endure brutal circumstances and ruthless killers on a trek across post-pandemic America.",
                    Price = 10.99,
                    ImageURL = "https://th.bing.com/th/id/OIP.cjEyrzS-AS64hdQaCSDqMgHaK9?pid=ImgDet&rs=1",
                    StartDate = DateTime.Now.AddDays(-20),
                    EndDate = DateTime.Now.AddDays(-5),
                    CinemaId = 5,
                    DirectorId = 3,
                    Category = MovieCategory.Action
                },
                new Movie()
                {
                    Name = "Heartstopper",
                    Description = "Heartstopper is a British coming-of-age romantic comedy-drama television series on Netflix, adapted from the webcomic and graphic novel of the same name by Alice Oseman. Written by Oseman herself, the series primarily tells the story of Charlie Spring, a gay schoolboy who falls in love with classmate Nick Nelson, whom he sits next to in his new form. It also explores the lives of their friends Tao, Elle, Tara and Darcy.",
                    Price = 34.99,
                    ImageURL = "https://th.bing.com/th/id/R.ace726b5bdb2b4ace671862540aca2d2?rik=BzgRIjxT7OV1KA&pid=ImgRaw&r=0",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(13),
                    CinemaId = 4,
                    DirectorId = 4,
                    Category = MovieCategory.Drama
                },
                new Movie()
                {
                    Name = "Spider Man: No Way Home",
                    Description = "Spider-Man: No Way Home is a 2021 American superhero film based on the Marvel Comics character Spider-Man, co-produced by Columbia Pictures and Marvel Studios and distributed by Sony Pictures Releasing. It is the sequel to Spider-Man: Homecoming (2017) and Spider-Man: Far From Home (2019).",
                    Price = 23.49,
                    ImageURL = "https://i2.wp.com/trendienewz.com/wp-content/uploads/2021/11/Spider-Man_-_No_Way_Home_Poster_2.jpg?w=1080&ssl=1",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(30),
                    CinemaId = 1,
                    DirectorId = 5,
                    Category = MovieCategory.Action
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
                },

                new ActorMovie()
                {
                    MovieId = 5,
                    ActorId = 6
                },
                new ActorMovie()
                {
                    MovieId = 5,
                    ActorId = 7
                },

                new ActorMovie()
                {
                    MovieId = 6,
                    ActorId = 8
                },
                new ActorMovie()
                {
                    MovieId = 6,
                    ActorId = 9
                },

                new ActorMovie()
                {
                    MovieId = 7,
                    ActorId = 10
                },
                new ActorMovie()
                {
                    MovieId = 7,
                    ActorId = 11
                },
                new ActorMovie()
                {
                    MovieId = 7,
                    ActorId = 12
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
