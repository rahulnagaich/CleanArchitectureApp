using System.Text.Json;
using CleanArchitectureApp.Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Utilities
{
    public class DecimalPrecisionConverterTests
    {
        [Fact]
        public void DecimalPrecisionConverter_ShouldRoundCorrectly_OnSerialization()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DecimalPrecisionConverter(2));
            decimal input = 12.3456m;

            // Act
            var json = JsonSerializer.Serialize(input, options);

            // Assert
            json.Should().Be("12.35");
        }

        [Fact]
        public void DecimalPrecisionConverter_ShouldRoundCorrectly_OnDeserialization()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DecimalPrecisionConverter(2));
            var json = "12.3456";

            // Act
            var output = JsonSerializer.Deserialize<decimal>(json, options);

            // Assert
            output.Should().Be(12.35m);
        }
    }
}
