using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsApi.Controllers;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Tests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private ProductsController controller;

        [SetUp] 
        public void SetUp() 
        {
            var logger = new Logger<ProductsController>(new LoggerFactory());
            this.controller = new ProductsController(logger);
        }

        [Test]
        public void Should_return_all_products()
        {
            // arrange
            // act
            var result = this.controller.GetProducts();

            // assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [TestCase("Red", "Table")]
        [TestCase("Black", "Chair")]
        public void Should_return_product_by_colour(string colour, string expectedProduct)
        {
            // act
            var result = this.controller.GetProductByColour(colour);

            // assert
            var product = (result.Result as OkObjectResult)?.Value as Product;
            Assert.That(product?.Name, Is.EqualTo(expectedProduct));
        }
    }
}
