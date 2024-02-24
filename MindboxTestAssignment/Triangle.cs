using System;
using MindboxTestAssignment.Shapes.Exceptions;

namespace MindboxTestAssignment.Shapes
{
    public class Triangle : PlainShape
    {
        /// <summary>
        /// Первая сторона треугольника
        /// </summary>
        public PositiveDouble A { get; set; }

        /// <summary>
        /// Вторая сторона треугольника
        /// </summary>
        public PositiveDouble B { get; set; }

        /// <summary>
        /// Третья сторона треугольника
        /// </summary>
        public PositiveDouble C { get; set; }
        public bool IsRight =>
            A * A + B * B == C * C
            ||
            A * A + C * C == B * B
            ||
            B * B + C * C == A * A;
        public Triangle(double a, double b, double c)
            : this(new PositiveDouble(a), new PositiveDouble((b)), new PositiveDouble((c))) { }
        private Triangle(PositiveDouble a, PositiveDouble b, PositiveDouble c)
        {
            // У треугольника длина стороны не может превосходить сумму двух других
            var isTrianglePossible = a < b + c && b < a + c && c < a + b;
            if (!isTrianglePossible) throw new ImpossibleTriangleException();
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона (по трем сторонам)
        /// </summary>
        /// <returns>Площадь этого треугольника</returns>
        public override PositiveDouble CalculateArea()
        {
            var perimeterHalf = (A + B + C) / 2;
            var area = Math.Sqrt(perimeterHalf * (perimeterHalf - A) * (perimeterHalf - B) * (perimeterHalf - C));
            return area;
        }
    }
}
