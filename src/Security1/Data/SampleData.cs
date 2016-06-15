using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Security1.Models;
using System.Collections.Generic;

namespace Security1.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com",
                    FirstName = "Stephen",
                    LastName = "Walther",
                    Blogs = new List<Blog> {
                        new Blog { Title = "Let's learn C#", Message = "blah blah blah..." },
                        new Blog { Title = "Why use Git", Message = "blah blah blah..." },
                        new Blog { Title = "What is dependency injection", Message = "blah blah blah..." },
                        new Blog { Title = "Basics of HTML", Message = "blah blah blah..." },
                    }
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com",
                    FirstName = "Mike",
                    LastName = "Smith",
                    Blogs = new List<Blog> {
                        new Blog { Title = "Mike's hard lemonade", Message = "blah blah blah..." },
                        new Blog { Title = "Beer is awesome", Message = "blah blah blah..." },
                        new Blog { Title = "Eat sleep and code", Message = "blah blah blah..." }
                    }
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


        }

    }
}
