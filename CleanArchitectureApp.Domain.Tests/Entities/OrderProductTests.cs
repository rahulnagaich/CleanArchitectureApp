using Xunit;
using System;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Domain.Tests.Entities
{
    public class OrderProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeOrderProductCorrectly()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var quantity = 5;
            var unitPrice = 20m;

            // Act
            var orderProduct = new OrderProduct( orderId, productId, quantity, unitPrice);

            // Assert
            Assert.Equal(orderId, orderProduct.OrderId);
            Assert.Equal(productId, orderProduct.ProductId);
            Assert.Equal(quantity, orderProduct.Quantity);
            Assert.Equal(unitPrice, orderProduct.UnitPrice);
        }
    }
}
