namespace ShapeTest.Business.Entities
{
    public class Square : BaseFigure
    {
        public double SideLength { get; set; }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }
        
    }
}