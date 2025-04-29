using System.Text.Json;
using CleanArchitectureApp.Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Utilities
{
    public class NullToDefaultConverterTests
    {
        [Fact]
        public void NullToDefaultConverter_ShouldReturnDefaultValue_ForNullValueType()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new NullToDefaultConverter());
            var json = "null";

            // Act
            var output = JsonSerializer.Deserialize<int>(json, options);

            // Assert
            output.Should().Be(0); // Default of int
        }

        [Fact]
        public void NullToDefaultConverter_ShouldReturnNull_ForReferenceType()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new NullToDefaultConverter());
            var json = "null";

            // Act
            var output = JsonSerializer.Deserialize<string>(json, options);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void NullToDefaultConverter_ShouldDeserializeNormally_ForNonNull()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new NullToDefaultConverter());
            var json = "\"Test\"";

            // Act
            var output = JsonSerializer.Deserialize<string>(json, options);

            // Assert
            output.Should().Be("Test");
        }
    }
}
