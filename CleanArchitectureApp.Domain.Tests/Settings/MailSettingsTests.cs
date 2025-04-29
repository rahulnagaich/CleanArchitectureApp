using CleanArchitectureApp.Domain.Settings;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Settings
{
    public class MailSettingsTests
    {
        //[Fact]
        //public void MailSettings_ShouldBindPropertiesCorrectly()
        //{
        //    // Arrange
        //    var inMemorySettings = new Dictionary<string, string>
        //    {
        //        {"MailSettings:Mail", "test@example.com"},
        //        {"MailSettings:DisplayName", "Test User"},
        //        {"MailSettings:Password", "TestPassword"},
        //        {"MailSettings:Host", "smtp.example.com"},
        //        {"MailSettings:Port", "587"}
        //    };

        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .AddInMemoryCollection(inMemorySettings)
        //        .Build();

        //    // Act
        //    var mailSettings = new MailSettings();
        //    configuration.GetSection("MailSettings").Bind(mailSettings);

        //    // Assert
        //    mailSettings.Mail.Should().Be("test@example.com");
        //    mailSettings.DisplayName.Should().Be("Test User");
        //    mailSettings.Password.Should().Be("TestPassword");
        //    mailSettings.Host.Should().Be("smtp.example.com");
        //    mailSettings.Port.Should().Be(587);
        //}
    }
}
