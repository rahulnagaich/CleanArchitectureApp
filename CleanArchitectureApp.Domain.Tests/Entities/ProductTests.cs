using Xunit;
using System;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Domain.Tests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProductCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Laptop";
            var price = 1200m;
            var categoryId = Guid.NewGuid();

            // Act
            var product = new Product(id, name, price, categoryId);

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.NotNull(product.OrderProducts);
            Assert.Empty(product.OrderProducts);
        }

        [Fact]
        public void UpdatePrice_ShouldChangePrice()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Phone", 500m, Guid.NewGuid());

            // Act
            product.UpdatePrice(600m);

            // Assert
            Assert.Equal(600m, product.Price);
        }

        [Fact]
        public void Rename_ShouldChangeName()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Tablet", 300m, Guid.NewGuid());

            // Act
            product.Rename("Smart Tablet");

            // Assert
            Assert.Equal("Smart Tablet", product.Name);
        }
    }
}
