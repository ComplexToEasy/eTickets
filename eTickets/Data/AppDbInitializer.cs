using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        //     private const double  = 39.50;

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            context.Database.EnsureCreated();

            //Cinema
            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnetow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of then first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnetow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of then 2nd cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnetow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of then 3rd cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnetow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of then 4th cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnetow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of then first cinema"
                        },

                    });
                context.SaveChanges();
            }
            //Actors
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                    {

                        new Actor()
                        {
                            FullName = "Actor 1",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Actor-1.jpeg",
                            Bio= "This is the description of then first cinema"
                        },
                        new Actor()
                        {
                            FullName = "Actor 1",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Actor-2.jpeg",
                            Bio= "This is the description of then first cinema"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Actor-3.jpeg",
                            Bio= "This is the description of then first cinema"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Actor-4.jpeg",
                            Bio= "This is the description of then first cinema"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Actor-5.jpeg",
                            Bio= "This is the description of then first cinema"
                        }

                    });
                context.SaveChanges();
            }
            //Producers
            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>()
                    {

                        new Producer()
                        {
                            FullName = "Producer 1",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Producer-1.jpeg",
                            Bio= "This is the description of then first Producer"
                        },
                        new Producer()
                        {
                            FullName = "Producer 1",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Producer-2.jpeg",
                            Bio= "This is the description of then first Producer"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Producer-3.jpeg",
                            Bio= "This is the description of then first Producer"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Producer-4.jpeg",
                            Bio= "This is the description of then 4th Producer"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            ProfilePictureURL = "http://dotnetow.net/images/cinemas/Producer-5.jpeg",
                            Bio= "This is the description of then first Producer"
                        }

                    });
                context.SaveChanges();
            }
            //Movies
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 35.25,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                context.SaveChanges();

            }
            //Actor & Movies
            if (!context.Actor_Movies.Any())
            {
                context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                context.SaveChanges();

            }
        }
        public static async Task SeedUserAndRoleAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManger = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                {
                    if (!await roleManger.RoleExistsAsync(UserRoles.Admin))
                        await roleManger.CreateAsync(new IdentityRole(UserRoles.Admin));
                
                    if (!await roleManger.RoleExistsAsync(UserRoles.User))
                        await roleManger.CreateAsync(new IdentityRole(UserRoles.User));
                    //Users
                    var userManger = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var adminUserEmail = "admin@etickets.com";

                    var adminUser = await userManger.FindByEmailAsync(adminUserEmail);
                    if(adminUser == null)
                    {
                        var newAdminUser = new ApplicationUser()
                        {
                            FullName = "Admin User",
                            UserName = "admin",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };
                        await userManger.CreateAsync(newAdminUser, "Codeing@1234?");
                        await userManger.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    var appUserEmail = "user@etickets.com";

                    var appUser = await userManger.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            FullName = "Application User",
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true
                        };
                        await userManger.CreateAsync(newAppUser, "Codeing@1234?");
                        await userManger.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }
        }
    }
}
