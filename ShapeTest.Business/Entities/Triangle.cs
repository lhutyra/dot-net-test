using System;
using System.Diagnostics;
namespace ShapeTest.Business.Entities
{
    public class Triangle : FigureBaseEntity
    {
        private string _Name;
        private double _Base;
        private double _Height;

        public Triangle(string Name,double Base, double Height)
        {
            if (Base < 0 || Height < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid initalization data");
            }
            this._Base = Base;
            this._Height = Height;
            this.Name = Name;
        }

        public Triangle()
        {
            
        }


        public override string Name
        {
            get { return _Name; }
            set { SetAndRaiseIfChanged(ref _Name, value); }
        }

        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }

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
    }
}
