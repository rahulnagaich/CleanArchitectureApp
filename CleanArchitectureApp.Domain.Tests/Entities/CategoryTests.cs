using Xunit;
using System;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Domain.Tests.Entities
{
    public class CategoryTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCategoryCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Electronics";
            var description = "Electronic items";

            // Act
            var category = new Category(id, name, description);

            // Assert
            Assert.Equal(id, category.Id);
            Assert.Equal(name, category.Name);
            Assert.Equal(description, category.Description);
            Assert.True(category.IsActive);
            Assert.NotNull(category.Products);
            Assert.Empty(category.Products);
        }

        [Fact]
        public void UpdateName_ShouldChangeName()
        {
            // Arrange
            var category = new Category(Guid.NewGuid(), "Old Name");

            // Act
            category.UpdateName("New Name");

            // Assert
            Assert.Equal("New Name", category.Name);
        }
    }
}
