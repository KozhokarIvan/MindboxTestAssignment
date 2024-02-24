using System;

namespace MindboxTestAssignment.Shapes
{
    public class Circle(double radius) : PlainShape
    {
        public PositiveDouble Radius { get; set; } = radius;
        public override PositiveDouble CalculateArea() => Math.PI * Radius * Radius;
    }
}