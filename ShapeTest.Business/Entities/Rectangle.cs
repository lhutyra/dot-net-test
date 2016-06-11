using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Entities
{
    public class Rectangle : IFigure
    {
        public string Name { get; set; }
        public double Size { get; set; }

        public double GetArea()
        {
            return Size*Size;
        }       
    }
}