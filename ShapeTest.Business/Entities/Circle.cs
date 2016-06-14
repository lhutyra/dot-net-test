using System;

namespace ShapeTest.Business.Entities
{
    public class Circle : BaseFigure
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}