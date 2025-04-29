using CleanArchitectureApp.Domain.Common;
using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Common
{
    public class IpHelperTests
    {
        [Fact]
        public void GetIpAddress_ShouldReturnString()
        {
            // Act
            var ip = IpHelper.GetIpAddress();

            // Assert
            Assert.NotNull(ip);
            Assert.IsType<string>(ip);
        }
    }
}
