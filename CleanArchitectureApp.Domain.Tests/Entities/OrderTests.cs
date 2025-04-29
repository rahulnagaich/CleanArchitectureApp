using Xunit;
using System;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Domain.Tests.Entities
{
    public class OrderTests
    {
        [Fact]
        public void Constructor_ShouldInitializeOrderCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customerId = Guid.NewGuid();

            // Act
            var order = new Order(id, customerId);

            // Assert
            Assert.Equal(id, order.Id);
            Assert.Equal(customerId, order.CustomerId);
            Assert.NotEqual(default(DateTime), order.OrderDate);
            Assert.NotNull(order.OrderProducts);
            Assert.Empty(order.OrderProducts);
        }

        [Fact]
        public void AddItem_ShouldAddOrderProduct()
        {
            // Arrange
            var order = new Order(Guid.NewGuid(), Guid.NewGuid());
            var productId = Guid.NewGuid();

            // Act
            order.AddItem(productId, 2, 100m);

            // Assert
            Assert.Single(order.OrderProducts);
            var item = Assert.Single(order.OrderProducts);
            Assert.Equal(productId, item.ProductId);
            Assert.Equal(2, item.Quantity);
            Assert.Equal(100m, item.UnitPrice);
        }

        [Fact]
        public void TotalAmount_ShouldCalculateCorrectly()
        {
            // Arrange
            var order = new Order(Guid.NewGuid(), Guid.NewGuid());
            order.AddItem(Guid.NewGuid(), 2, 100m); // 200
            order.AddItem(Guid.NewGuid(), 1, 50m);  // 50

            // Act
            var total = order.TotalAmount;

            // Assert
            Assert.Equal(250m, total);
        }
    }
}
