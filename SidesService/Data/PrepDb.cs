using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SidesService.Models;

namespace SidesService.Data
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
            if (!context.Sides.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Sides.AddRange(
                    new Side
                    {
                        Price = 95,
                        Name = "Garlic Bread",
                        ImageURL = "../../assets/Sides/garlic bread-1636005232-1_crop.jpg",
                        CreateDate = DateTime.Now,
                        Description = "Classic wood-fired garlic bread smoked to perfection",
                        CategoryId = 7
                    },
                    new Side
                    {
                        Price = 165,
                        Name = "Roasted Potatoes (8 pcs)",
                        ImageURL = "../../assets/Sides/roasted potatoes-1636005264-1_crop.jpg",
                        CreateDate = DateTime.Now,
                        Description = "Crisp, golden roasted potato topped with chilli flakes, rosemary and coriander.",
                        CategoryId = 7
                    },
                    new Side
                    {
                        Price = 250,
                        Name = "Smokey Cheese Dough Balls (10 pcs)",
                        ImageURL = "../../assets/Sides/smokey cheese dough balls_1-1636005293-1_crop.jpg",
                        CreateDate = DateTime.Now,
                        Description = "Smokey dough balls, rich with cheese, flavoured with garlic, chilli flakes & oregano baked to perfection.",
                        CategoryId = 7
                    },
                    new Side
                    {
                        Price = 100,
                        Name = "Chilli Cheese Bread",
                        ImageURL = "../../assets/Sides/chilli cheese bread-1636005588-1_crop.jpg",
                        CreateDate = DateTime.Now,
                        Description = "Delicious combination of cheesy bread with infusions of spicy chilli.",
                        CategoryId = 7
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