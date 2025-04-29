using System.Text.Json;
using CleanArchitectureApp.Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Utilities
{
    public class ErrorTests
    {
        [Fact]
        public void Error_ShouldSerializeToJson_WhenImplicitlyConvertedToString()
        {
            // Arrange
            var error = new Error("400", "Bad Request", Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            // Act
            string serialized = error;

            // Assert
            serialized.Should().Contain("\"Code\":\"400\"");
            serialized.Should().Contain("\"Message\":\"Bad Request\"");
            serialized.Should().Contain("\"ErrorId\":\"aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa\"");
        }
    }
}
