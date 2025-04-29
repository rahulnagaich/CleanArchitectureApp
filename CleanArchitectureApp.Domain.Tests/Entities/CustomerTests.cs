using Xunit;
using System;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Domain.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCustomerCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "John Doe";
            var email = "john@example.com";

            // Act
            var customer = new Customer(id, name, email);

            // Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(name, customer.FullName);
            Assert.Equal(email, customer.Email);
            Assert.NotNull(customer.Orders);
            Assert.Empty(customer.Orders);
        }

        [Fact]
        public void UpdateContact_ShouldChangeFullNameAndEmail()
        {
            // Arrange
            var customer = new Customer(Guid.NewGuid(), "Old Name", "old@example.com");

            // Act
            customer.UpdateContact("New Name", "new@example.com");

            // Assert
            Assert.Equal("New Name", customer.FullName);
            Assert.Equal("new@example.com", customer.Email);
        }
    }
}
