using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class FiguresRepository : IFiguresRepository
    {
        public event FigureAddedEventHandler FigureAdded;

        private readonly List<FigureBaseEntity> _figures;
        public List<FigureBaseEntity> GetFigures()
        {
            var figures = new List<FigureBaseEntity>
            {
                new Triangle
                (
                     "Triangle 1",
                     12.5,
                     13
                ),
                new Triangle("Triangle 2",23.4,14),

                new Triangle("Triangle 3",42,22),
                 new Rectangle()
                {
                    Name = "rect1",
                    Size = 15
                }
            };
            return figures;
        }

        public void AddFigure(FigureBaseEntity figure)
        {
            _figures.Add(figure);
            OnFigureAdded(figure);
        }

        public bool RemoveFigure(FigureBaseEntity figure)
        {
            return _figures.Remove(figure);
        }
        protected void OnFigureAdded(FigureBaseEntity triangle)
        {
            FigureAddedEventHandler handler = FigureAdded;
            handler?.Invoke(this, new FiguresEventArgs(triangle));
        }
    }
}
