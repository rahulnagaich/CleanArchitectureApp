using Xunit;
using System;
using CleanArchitectureApp.Domain.Common;

namespace CleanArchitectureApp.Domain.Tests.Common
{
    public class BaseEntityTests
    {
        private class DummyEntity : BaseEntity<Guid> { }

        [Fact]
        public void Should_SetIdCorrectly()
        {
            // Arrange
            var dummy = new DummyEntity
            {
                Id = Guid.NewGuid()
            };

            // Assert
            Assert.NotEqual(Guid.Empty, dummy.Id);
        }
    }
}
