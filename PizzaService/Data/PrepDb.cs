using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PizzaService.Models;

namespace PizzaService.Data
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
            if (!context.Pizzas.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Pizzas.AddRange(
                    new Pizza
                    {
                        CategoryId = 1,
                        Price = 255,
                        Name = "Garden Fresh Pizza",
                        ImageUrl = "../../assets/Pizza/gardenfreshpizza.jpg",
                        Description = "Mama Sauce + Mozzarella Cheese + Green Capsicum + Black Olives + Tomatoes + Mushroom + Jalapenos + Sweetcorn"
                    },
                    new Pizza
                    {
                        CategoryId = 1,
                        Price = 310,
                        Name = "Hot & Spicy Pizza",
                        ImageUrl = "../../assets/Pizza/hot&spicypizza.jpg",
                        Description = "Italian Sauce + Shredded Mozzarella + Onions + Green Chili + Jalapenos + Red Paprika"
                    },
                    new Pizza
                    {
                        CategoryId = 2,
                        Price = 399,
                        Name = "Chicken Mexicana Pizza",
                        ImageUrl = "../../assets/Pizza/chickenmexicana.jpg",
                        Description = "Italian Sauce + Shredded Mozzarella + Onions + Green Chili + Jalapenos + Red Paprika"
                    },
                    new Pizza
                    {
                        CategoryId = 2,
                        Price = 425,
                        Name = "Smoked Chicken Pizza",
                        ImageUrl = "../../assets/Pizza/smokedchickenpizza.jpg",
                        Description = "Italian Sauce + Shredded Mozzarella + Onions + Green Chili + Jalapenos + Red Paprika"
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