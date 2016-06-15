namespace ShapeTest.Business.Entities
{
    public class Square : BaseFigure
    {
        protected double _SideLength;

        public double SideLength
        {
            get
            {
                return _SideLength;
            }
            set
            {                
                _SideLength = value;
            }
        }

        public override double GetArea()
        {
            if (SideLength < 0) return double.NaN;
            return SideLength * SideLength;
        }
        
    }
}