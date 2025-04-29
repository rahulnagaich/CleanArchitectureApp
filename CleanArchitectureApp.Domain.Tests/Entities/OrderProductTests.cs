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
            var id = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var quantity = 5;
            var unitPrice = 20m;

            // Act
            var orderProduct = new OrderProduct(id, orderId, productId, quantity, unitPrice);

            // Assert
            Assert.Equal(id, orderProduct.Id);
            Assert.Equal(orderId, orderProduct.OrderId);
            Assert.Equal(productId, orderProduct.ProductId);
            Assert.Equal(quantity, orderProduct.Quantity);
            Assert.Equal(unitPrice, orderProduct.UnitPrice);
        }
    }
}
