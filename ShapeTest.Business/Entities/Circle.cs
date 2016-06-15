using System;

namespace ShapeTest.Business.Entities
{
    public class Circle : BaseFigure
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            if (Radius < 0) return double.NaN;
            return Radius * Radius * Math.PI;
        }
    }
}