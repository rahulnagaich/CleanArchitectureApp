using Xunit;
using FluentAssertions;
using CleanArchitectureApp.Domain.Constants;

namespace CleanArchitectureApp.Domain.Tests.Constants
{
    public class ConstantsTests
    {
        //[Fact]
        //public void ApplicationConstants_ShouldHaveExpectedValues()
        //{
        //    ApplicationConstants.Name.Should().Be("CleanArchitecture");
        //    ApplicationConstants.FluentValidationErrorKey.Should().Be("FluentValidationErrorKey");
        //}

        [Fact]
        public void AuthIdentityErrorMessage_ShouldContainExpectedMessages()
        {
            AuthIdentityErrorMessage.TokenNotExistMessage.Should().Be("The specified token does not exist.");
            AuthIdentityErrorMessage.UserNotExistMessage.Should().Be("The user does not exist.");
            AuthIdentityErrorMessage.EmailAndPasswordNotNullMessage.Should().Be("Email and password must not be null.");
        }

        //[Fact]
        //public void ErrorRespondCode_ShouldContainExpectedCodes()
        //{
        //    ErrorRespondCode.NOT_FOUND.Should().Be("not_found");
        //    ErrorRespondCode.BAD_REQUEST.Should().Be("bad_request");
        //}

        [Fact]
        public void HealthCheck_ShouldContainExpectedNames()
        {
            HealthCheck.InfrastructureCheck.Should().Be("InfrastructureCheck");
            HealthCheck.DBHealthCheck.Should().Be("DBHealthCheck");
        }

        [Fact]
        public void ResponseMessage_ShouldContainExpectedMessages()
        {
            ResponseMessage.Success.Should().Be("Operation completed successfully.");
            ResponseMessage.BadRequest.Should().Be("Bad request.");
            ResponseMessage.InternalServerError.Should().Be("An unexpected error occurred.");
        }
    }
}
