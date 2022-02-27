using System.Collections.Generic;
using Moq;
using PizzaService.Controllers;
using PizzaService.Data;
using PizzaService.Models;
using Xunit;
using PizzaService.Dtos;
using PizzaService.Components;

namespace PizzaService.UT
{
    public class PizzaComponentTests : BaseUnitTest
    {
        private PizzaComponent pizzaComponent = null;
        private Mock<IPizzaRepo> pizzaRepoMock = null;
        public PizzaComponentTests()
        {
            pizzaRepoMock = new Mock<IPizzaRepo>();
        }

        [Fact]
        public void Test_GetAllPizza_RetrunEmptyList()
        {
            //Arrange
            IEnumerable<Pizza> pizzas = null;
            pizzaRepoMock.Setup(x => x.GetAllPizzas()).Returns(pizzas);

            pizzaComponent = new PizzaComponent(pizzaRepoMock.Object, Mapper);

            //Act
            var result = pizzaComponent.GetAllPizzas();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Test_GetAllPizza_RetrunPizzaDtoList()
        {
            //Arrange
            List<Pizza> pizzas = new List<Pizza>();
            pizzas.Add(new Pizza { Name = "Test Pizza", Description = "Test Pizza", CategoryId = 2, PizzaId = 1, Price = 325 });

            pizzaRepoMock.Setup(x => x.GetAllPizzas()).Returns(pizzas);

            pizzaComponent = new PizzaComponent(pizzaRepoMock.Object, Mapper);

            //Act
            var result = pizzaComponent.GetAllPizzas();

            //Assert
            Assert.NotNull(result);
        }
    }
}