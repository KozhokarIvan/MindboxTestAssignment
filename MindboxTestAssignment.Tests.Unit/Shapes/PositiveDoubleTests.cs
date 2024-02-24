using MindboxTestAssignment.Shapes;

namespace MindboxTestAssignment.Tests.Unit.Shapes
{
    public class PositiveDoubleTests
    {
        [Fact(DisplayName = "Должен успешно создавать положительное число")]
        public void PositiveDouble_ShouldCreatePositive()
        {
            //arrange
            var expectedNumber = 5.0;

            //act
            PositiveDouble result = expectedNumber;

            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(expectedNumber);
        }

        [Theory(DisplayName = "Не должен создавать неположительное число")]
        [InlineData(0)]
        [InlineData(-1)]
        public void PositiveDouble_ShouldNotCreateNonPositive(double value)
        {
            //arrange
            PositiveDouble result;

            //act
            Action act = () => result = value;

            //assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
