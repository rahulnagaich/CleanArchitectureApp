using Xunit;
using System;
using CleanArchitectureApp.Domain.Common;

namespace CleanArchitectureApp.Domain.Tests.Common
{
    public class AuditableEntityTests
    {
        private class DummyAuditableEntity : AuditableEntity { }

        [Fact]
        public void Should_SetAuditFields()
        {
            // Arrange
            var dummy = new DummyAuditableEntity
            {
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastModifiedDate = DateTime.UtcNow.AddMinutes(5),
                LastModifiedBy = "User1"
            };

            // Assert
            //Assert.NotNull(dummy.CreatedDate);
            Assert.Equal("Admin", dummy.CreatedBy);
            Assert.NotNull(dummy.LastModifiedDate);
            Assert.Equal("User1", dummy.LastModifiedBy);
        }
    }
}
