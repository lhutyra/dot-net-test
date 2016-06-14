using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Entities
{
    public class Rectangle : BaseFigure
    {        
        public double Size { get; set; }

        public override double GetArea()
        {
            return Size * Size;
        }
    }
}