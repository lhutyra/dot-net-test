using System.Collections.Generic;

namespace ShapeTest.Business.Repositories
{
    public class FiguresRepository : IFiguresRepository
    {
        public event FigureAddedEventHandler FigureAdded;

        private readonly List<IFigure> _figures;
        public List<IFigure> GetFigures()
        {
            throw new System.NotImplementedException();
        }

        public void AddFigure(IFigure figure)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveFigure(IFigure figure)
        {
            throw new System.NotImplementedException();
        }
    }
}