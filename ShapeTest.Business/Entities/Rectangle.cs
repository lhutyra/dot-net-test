using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Entities
{
    public class Rectangle : FigureBaseEntity
    {
        public override string Name { get; set; }
        public double Size { get; set; }

        public override double GetArea()
        {
            return Size * Size;
        }
    }
}