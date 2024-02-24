using System;
using System.Diagnostics.CodeAnalysis;

namespace MindboxTestAssignment.Shapes
{
    public readonly struct PositiveDouble(double value) : IComparable<double>
    {
        private readonly double _value = CreatePositive(value);

        public static implicit operator double(PositiveDouble positiveValue)
            => positiveValue._value;

        public static implicit operator PositiveDouble(double value)
            => new(value);
        private static double CreatePositive(double value)
            => value > 0 ? value : throw new ArgumentException("Отрезок не может быть неположительной длины");

        public int CompareTo(double other) => _value.CompareTo(other);
        public override bool Equals([NotNullWhen(true)] object? obj) => _value.Equals(obj);
        public override string ToString() => _value.ToString();

    }
}
