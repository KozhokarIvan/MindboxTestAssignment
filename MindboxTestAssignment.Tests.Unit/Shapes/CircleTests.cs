using MindboxTestAssignment.Shapes;

namespace MindboxTestAssignment.Tests.Unit.Shapes
{
    public class CircleTests
    {

        [Theory(DisplayName = "Правильно создается круг")]
        [InlineData(1)]
        [InlineData(1.1f)]
        [InlineData(1.23423423423)]
        public void Circle_ShouldCreatePositiveSize(double expectedRadius)
        {
            //arrange
            Circle circle;

            //act
            circle = new Circle(expectedRadius);

            //assert
            circle.Radius.Should().Be(expectedRadius);
        }

        [Theory(DisplayName = "Выбрасывает исключение при попытке создать круг с неположительным радиусом")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1.1f)]
        [InlineData(-1.23423423423)]
        public void Circle_ShouldNotCreateNonPositiveSize(double radius)
        {
            //arrange
            Circle circle;

            //act
            Action act = () => circle = new Circle(radius);

            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory(DisplayName = "Правильно вычисляется площадь круга")]
        [InlineData(1, Math.PI)]
        [InlineData(2, Math.PI * 2 * 2)]
        [InlineData(3.15f, Math.PI * 3.15f * 3.15f)]
        [InlineData(500.12341234, Math.PI * 500.12341234 * 500.12341234)]
        public void Circle_CalculateArea_ShouldReturnCorrectArea(double radius, double expectedArea)
        {
            //arrange
            var circle = new Circle(radius);

            //act
            var area = circle.CalculateArea();

            //assert
            area.Should().Be(expectedArea);
        }
    }
}