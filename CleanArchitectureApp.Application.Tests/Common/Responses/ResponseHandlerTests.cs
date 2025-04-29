
using CleanArchitectureApp.Domain.Constants;
using CleanArchitectureApp.Domain.Responses;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace CleanArchitectureApp.Application.Tests.Common.Responses
{
    public class ResponseHandlerTests
    {
        [Fact]
        public void Deleted_ShouldReturnSuccessResponse()
        {
            // Act
            var response = ResponseHandler.Deleted<string>();

            // Assert
            response.Should().NotBeNull();
            response.Succeeded.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Message.Should().Be(ResponseMessage.Deleted);
        }

        [Fact]
        public void Success_ShouldReturnSuccessResponse_WithEntity()
        {
            // Arrange
            var entity = "TestEntity";

            // Act
            var response = ResponseHandler.Success(entity);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().Be(entity);
            response.Succeeded.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Message.Should().Be(ResponseMessage.Success);
        }

        [Fact]
        public void Success_WithCustomMessage_ShouldOverrideDefault()
        {
            // Arrange
            var entity = "TestEntity";
            var customMessage = "Custom Success Message";

            // Act
            var response = ResponseHandler.Success(entity, customMessage);

            // Assert
            response.Message.Should().Be(customMessage);
        }

        [Fact]
        public void Unauthorized_ShouldReturnUnauthorizedResponse()
        {
            // Act
            var response = ResponseHandler.Unauthorized<string>();

            // Assert
            response.Succeeded.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            response.Message.Should().Be(ResponseMessage.Unauthorized);
        }

        [Fact]
        public void BadRequest_ShouldReturnFailureResponse()
        {
            // Arrange
            var message = "Bad Request Message";
            var errors = new List<string> { "Error1", "Error2" };

            // Act
            var response = ResponseHandler.BadRequest<string>(message, errors);

            // Assert
            response.Succeeded.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response.Message.Should().Be(message);
            response.Errors.Should().BeEquivalentTo(errors);
        }

        [Fact]
        public void Conflict_ShouldReturnConflictResponse()
        {
            // Act
            var response = ResponseHandler.Conflict<string>();

            // Assert
            response.Succeeded.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
            response.Message.Should().Be(ResponseMessage.Conflict);
        }

        [Fact]
        public void UnprocessableEntity_ShouldReturnUnprocessableEntityResponse()
        {
            // Act
            var response = ResponseHandler.UnprocessableEntity<string>();

            // Assert
            response.Succeeded.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            response.Message.Should().Be(ResponseMessage.UnprocessableEntity);
        }

        [Fact]
        public void NotFound_ShouldReturnNotFoundResponse()
        {
            // Act
            var response = ResponseHandler.NotFound<string>();

            // Assert
            response.Succeeded.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Message.Should().Be(ResponseMessage.NotFound);
        }

        [Fact]
        public void Created_ShouldReturnCreatedResponse()
        {
            // Arrange
            var entity = "NewEntity";

            // Act
            var response = ResponseHandler.Created(entity);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().Be(entity);
            response.Succeeded.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Message.Should().Be(ResponseMessage.Created);
        }
    }
}
