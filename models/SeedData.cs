using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WEB315_Hobbies.Models;
using System;
using System.Linq;

namespace WEB315_Hobbies.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WEB315_HobbiesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WEB315_HobbiesContext>>()))
            {
                // Look for any movies.
                if (context.hobbies.Any())
                {
                    return;   // DB has been seeded
                }

                context.hobbies.AddRange(
                    new hobbies
                    {
                        Title =  "Reading",
                        VisitDate = DateTime.Parse("2022-01-01"),
                        Location = "Mnali",
                        cost= 25,
                        placetype="Adventurous",
                        visitcount= 2,



                    },

                    new hobbies
                    {
                        Title =  "Listening Music",
                        VisitDate = DateTime.Parse("2022-02-16"),
                        Location = "Famous meuseum",
                        cost= 50,
                        placetype="Tourist",
                        visitcount= 6,
                    },

                    new hobbies
                    {
                         Title =  "Travelling",
                        VisitDate = DateTime.Parse("2022-01-30"),
                        Location = "J&K",
                        cost= 30,
                        placetype="Holy",
                        visitcount= 8,
                    },

                    new hobbies
                    {
                        Title =  "Hang-out",
                        VisitDate = DateTime.Parse("2022-03-01"),
                        Location = "Shukhna lake",
                        cost= 20,
                        placetype="Tracking",
                        visitcount= 9,
                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}