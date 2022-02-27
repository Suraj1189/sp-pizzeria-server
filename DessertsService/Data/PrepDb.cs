using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DessertsService.Models;

namespace DessertsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SendData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
        private static void SendData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to run migrations...");
                try
                {
                    //context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Migration failed: {ex.Message}");
                }
            }
            if (!context.Desserts.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Desserts.AddRange(
                    new Dessert
                    {
                        Price =  355,
                        Name =  "Chocolate Mousse",
                        ImageURL =  "../../assets/Sides/chocolate mousse-1636004271-1_crop.jpg",
                        CreateDate =  DateTime.Now,
                        Description =  "Sinful Eggless dessert made with delicious dark chocolate and fresh cream",
                        CategoryId =  9
                    },
                    new Dessert
                    {
                        Price =  100,
                        Name =  "Tiramisu",
                        ImageURL =  "../../assets/Sides/tiramisu-1636003837-1_crop.jpg",
                        CreateDate =  DateTime.Now,
                        Description =  "Classic Eggless Tiramisu made authentically in the Italian way, simply too hard to resist for that Tiramisu lover.",
                        CategoryId =  9
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}