using MindboxTestAssignment.Shapes;
using MindboxTestAssignment.Shapes.Exceptions;

namespace MindboxTestAssignment.Tests.Unit.Shapes
{
    public class TriangleTests
    {
        [Fact(DisplayName = "Создается треугольник с возможным набором сторон")]
        public void Triangle_ShouldCreatePositiveSided()
        {
            //arrange
            var a = 3;
            var b = 4;
            var c = 5;

            //act
            Triangle[] triangles = [new Triangle(a, b, c), new Triangle(c, a, b), new Triangle(b, c, a)];

            //assert
            foreach (var triangle in triangles)
            {
                triangle.A.Should().BeGreaterThan(0);
                triangle.B.Should().BeGreaterThan(0);
                triangle.C.Should().BeGreaterThan(0);
            }
        }


        [Fact(DisplayName = "Не создается треугольник с невозможным набором сторон")]
        public void Triangle_ShouldNotCreateNonPositiveSided()
        {
            //arrange
            var a = 3;
            var b = 1;
            var c = 1;

            //act
            Action[] acts = [() => new Triangle(a, b, c), () => new Triangle(c, a, b), () => new Triangle(b, c, a)];

            //assert
            foreach (var act in acts)
                act.Should().Throw<ImpossibleTriangleException>("у треугольника длина стороны не может превосходить сумму двух других");
        }

        [Fact(DisplayName = "Правильно вычисляется площадь треугольника")]
        public void Triangle_CalculateArea_ShouldCalculateArea()
        {
            //arrange
            var a = 3;
            var b = 4;
            var c = 5;
            var expectedArea = 6;
            var triangles = GetTriangleCombinations(a, b, c);

            //act
            var areas = triangles.Select(t => t.CalculateArea()).ToArray();

            //assert
            foreach (var area in areas)
                area.Should().Be(expectedArea);
        }
        [Fact(DisplayName = "Правильно определяет, что треугольник прямоугольный")]
        public void Triangle_IsRight_ShouldReturnTrue()
        {
            //arrange
            var a = 3;
            var b = 4;
            var c = 5;

            //act
            var triangles = GetTriangleCombinations(a, b, c);

            //assert
            foreach (var triangle in triangles)
                triangle.IsRight.Should().BeTrue();
        }

        [Fact(DisplayName = "Правильно определяет, что треугольник не прямоугольный")]
        public void Triangle_IsRight_ShouldReturnFalse()
        {
            //arrange
            var a = 3;
            var b = 3;
            var c = 3;

            //act
            var triangles = GetTriangleCombinations(a, b, c);

            //assert
            foreach (var triangle in triangles)
                triangle.IsRight.Should().BeFalse();
        }
        private static Triangle[] GetTriangleCombinations(PositiveDouble a, PositiveDouble b, PositiveDouble c)
            => [new Triangle(a, b, c), new Triangle(c, a, b), new Triangle(b, c, a)];
    }
}
