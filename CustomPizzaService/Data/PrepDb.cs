using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CustomPizzaService.Models;

namespace CustomPizzaService.Data
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
            if (!context.CustomPizzas.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.CustomPizzas.AddRange(
                    new CustomPizza
                    {
                        CategoryId = 1,
                        Price = 425,
                        Name = "Gourmet Pizza (Veg)",
                        ImageUrl = "../../assets/Pizza/classic-pizza-myo-1637221659-1_crop.jpg",
                    },
                    new CustomPizza
                    {
                        CategoryId = 2,
                        Price = 500,
                        Name = "Gourmet Pizza (Non Veg)",
                        ImageUrl = "../../assets/Pizza/non-veg make your-own pizza.jpg",
                    }
                );

                context.Ingredients.AddRange(
                    new Ingredient
                    {
                        Name = "Yellow Capsicum",
                        Price = 50,
                        CreateDate = new DateTime(),
                        CategoryId = 4
                    },
                     new Ingredient
                     {
                         Name = "Jalapeno",
                         Price = 50,
                         CreateDate = new DateTime(),
                         CategoryId = 4
                     },
                     new Ingredient
                     {
                         Name = "Plain Paneer",
                         Price = 90,
                         CreateDate = new DateTime(),
                         CategoryId = 4
                     },
                     new Ingredient
                     {
                         Name = "Shredded Mozarella",
                         Price = 100,
                         CreateDate = new DateTime(),
                         CategoryId = 5
                     },
                     new Ingredient
                     {
                         Name = "Vegan Mozzarella Cheese",
                         Price = 300,
                         CreateDate = new DateTime(),
                         CategoryId = 5
                     },
                     new Ingredient
                     {
                         Name = "Italian Pelati Sauce (Rather Tangy)",
                         Price = 90,
                         CreateDate = new DateTime(),
                         CategoryId = 6
                     },
                     new Ingredient
                     {
                         Name = "Mama'S Sauce (Slightly Spicy)",
                         Price = 30,
                         CreateDate = new DateTime(),
                         CategoryId = 6
                     },
                     new Ingredient
                     {
                         Name = "Marinara Sauce",
                         Price = 60,
                         CreateDate = new DateTime(),
                         CategoryId = 6
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