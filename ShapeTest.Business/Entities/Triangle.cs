namespace ShapeTest.Business.Entities
{
    public class Triangle : BaseFigure
    {
        private double _Base;
        private double _Height;

        public double Base
        {
            get { return _Base; }
            set { SetAndRaiseIfChanged(ref _Base, value); }
        }

        public double Height
        {
            get { return _Height; }
            set { SetAndRaiseIfChanged(ref _Height, value); }
        }

        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
