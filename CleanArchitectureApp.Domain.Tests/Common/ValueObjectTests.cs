using Xunit;

namespace CleanArchitectureApp.Domain.Tests.Common
{
    public class ValueObjectTests
    {
        [Fact]
        public void EqualOperator_ShouldReturnTrue_ForSameValues()
        {
            // Arrange
            var obj1 = new DummyValueObject("test", 1);
            var obj2 = new DummyValueObject("test", 1);

            // Act & Assert
            Assert.True(obj1.Equals(obj2));
            Assert.Equal(obj1.GetHashCode(), obj2.GetHashCode());
        }

        [Fact]
        public void EqualOperator_ShouldReturnFalse_ForDifferentValues()
        {
            // Arrange
            var obj1 = new DummyValueObject("test", 1);
            var obj2 = new DummyValueObject("test", 2);

            // Act & Assert
            Assert.False(obj1.Equals(obj2));
        }
    }
}
