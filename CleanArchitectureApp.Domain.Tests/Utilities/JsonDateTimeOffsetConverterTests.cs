using System.Text.Json;
using CleanArchitectureApp.Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Utilities
{
    public class JsonDateTimeOffsetConverterTests
    {
        [Fact]
        public void JsonDateTimeOffsetConverter_ShouldSerializeToIso8601()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonDateTimeOffsetConverter());
            var date = new DateTimeOffset(2024, 4, 26, 10, 30, 0, TimeSpan.Zero);

            // Act
            var json = JsonSerializer.Serialize(date, options);

            // Assert
            json.Should().Contain("2024-04-26T10:30:00.0000000+00:00");
        }

        [Fact]
        public void JsonDateTimeOffsetConverter_ShouldDeserializeFromIso8601()
        {
            // Arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonDateTimeOffsetConverter());
            var json = "\"2024-04-26T10:30:00Z\"";

            // Act
            var output = JsonSerializer.Deserialize<DateTimeOffset>(json, options);

            // Assert
            output.Should().Be(new DateTimeOffset(2024, 4, 26, 10, 30, 0, TimeSpan.Zero));
        }
    }
}
