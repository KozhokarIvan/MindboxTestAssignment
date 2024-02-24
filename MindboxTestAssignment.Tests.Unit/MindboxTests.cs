using MindboxTestAssignment.Shapes;

namespace MindboxTestAssignment.Tests.Unit
{
    public class MindboxTests
    {
        [Fact(DisplayName = "Вычисление площади фигуры без знания типа фигуры в compile-time")]
        public void Mindbox_CalculatingAreaWithoutKnowingTypeInCompileTime()
        {
            //arrange
            Random rnd = new Random(12345);
            PlainShape[] shapes =
                [
                    rnd.Next() % 2 == 0 ? new Triangle(3, 4, 5) : new Circle(5),
                    rnd.Next() % 2 == 0 ? new Triangle(3, 3, 3) : new Circle(1),
                    rnd.Next() % 2 == 0 ? new Triangle(2, 4, 5) : new Circle(4),
                    rnd.Next() % 2 == 0 ? new Triangle(10, 18, 20) : new Circle(27),
                ];

            //act
            var areas = shapes.Select(s => s.CalculateArea()).ToArray();

            //assert
            for (int i = 0; i < shapes.Length; i++)
            {
                switch (shapes[i])
                {
                    case Triangle triangle:
                        areas[i].Should().Be(triangle.CalculateArea());
                        break;
                    case Circle circle:
                        areas[i].Should().Be(circle.CalculateArea());
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
