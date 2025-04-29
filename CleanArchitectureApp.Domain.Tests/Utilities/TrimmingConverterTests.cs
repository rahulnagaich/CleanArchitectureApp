using System.Text.Json;
using CleanArchitectureApp.Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Utilities
{
    public class TrimmingConverterTests
    {
        [Fact]
        public void TrimmingConverter_ShouldTrimWhitespace_OnRead()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new TrimmingConverter());
            var json = "\"   Hello World   \"";

            // Act
            var result = JsonSerializer.Deserialize<string>(json, options);

            // Assert
            result.Should().Be("Hello World");
        }

        [Fact]
        public void TrimmingConverter_ShouldTrimWhitespace_OnWrite()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new TrimmingConverter());
            var input = "   Hello World   ";

            // Act
            var json = JsonSerializer.Serialize(input, options);

            // Assert
            json.Should().Be("\"Hello World\"");
        }
    }
}
