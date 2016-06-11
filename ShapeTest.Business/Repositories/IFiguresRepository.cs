using System.Collections.Generic;

namespace ShapeTest.Business.Repositories
{
    public interface IFiguresRepository
    {
        event FigureAddedEventHandler FigureAdded;

        List<IFigure> GetFigures();

        void AddFigure(IFigure figure);

        bool RemoveFigure(IFigure figure);
    }
}