using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeveragesService.Models;

namespace BeveragesService.Data
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
            if (!context.Beverages.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Beverages.AddRange(
                    new Beverage
                    {
                        Price = 99,
                        Name = "Masala Lemonade",
                        ImageURL =  "../../assets/Sides/masala lemonade-1636004414-1_crop.jpg",
                        CreateDate =  DateTime.Now,
                        Description =  "200 ml",
                        CategoryId =  8
                    },
                    new Beverage
                    {
                        Price = 100,
                        Name = "Lychee Lemonade",
                        ImageURL =  "../../assets/Sides/lychee lemonade-1636004307-1_crop.jpg",
                        CreateDate =  DateTime.Now,
                        Description =  "200 ml",
                        CategoryId =  8
                    },
                    new Beverage
                    {
                        Price = 99,
                        Name = "Peach Iced Tea",
                        ImageURL =  "../../assets/Sides/peach ice tea-1636004370-1_crop.jpg",
                        CreateDate =  DateTime.Now,
                        Description =  "200 ml",
                        CategoryId =  8
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