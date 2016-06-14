using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class FiguresRepository : IFiguresRepository
    {
        public event FigureAddedEventHandler FigureAdded;
        private readonly List<IFigure> _Figures;

        public FiguresRepository()
        {
            _Figures = new List<IFigure>
            {
                new Triangle
                {
                    Name = "Triangle 1",
                    Base = 12.5,
                    Height = 13
                },
                new Triangle
                {
                    Name = "Triangle 2",
                    Base = 23.4,
                    Height = 14
                }
                ,
                new Square()
                {
                    Name = "Square 1",
                    SideLength = 10.0
                },
                new Circle()
                {
                    Name = "Circle 1",
                    Radius = 10.0
                }
            };
        }

        public List<IFigure> GetFigures()
        {
            return _Figures;
        }

        public void AddFigure(IFigure figure)
        {
            _Figures.Add(figure);
            OnFigureAdded(figure);
        }

        public bool RemoveFigure(IFigure triangle)
        {
            return _Figures.Remove(triangle);
        }

        protected void OnFigureAdded(IFigure figure)
        {
            FigureAddedEventHandler handler = FigureAdded;
            handler?.Invoke(this, new FiguresEventArgs(figure));
        }
    }
}
