using CleanArchitectureApp.Domain.Settings;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Settings
{
    public class JWTSettingsTests
    {
        //[Fact]
        //public void JWTSettings_ShouldBindPropertiesCorrectly()
        //{
        //    // Arrange
        //    var inMemorySettings = new Dictionary<string, string>
        //    {
        //        {"JWTSettings:Key", "TestSecretKey"},
        //        {"JWTSettings:Issuer", "TestIssuer"},
        //        {"JWTSettings:Audience", "TestAudience"},
        //        {"JWTSettings:DurationInMinutes", "60"}
        //    };

        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .AddInMemoryCollection(inMemorySettings)
        //        .Build();

        //    // Act
        //    var jwtSettings = new JWTSettings();
        //    configuration.GetSection("JWTSettings").Bind(jwtSettings);

        //    // Assert
        //    jwtSettings.Key.Should().Be("TestSecretKey");
        //    jwtSettings.Issuer.Should().Be("TestIssuer");
        //    jwtSettings.Audience.Should().Be("TestAudience");
        //    jwtSettings.DurationInMinutes.Should().Be(60);
        //}
    }
}
