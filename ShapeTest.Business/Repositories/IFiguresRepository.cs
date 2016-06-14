using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IFiguresRepository
    {
        event FigureAddedEventHandler FigureAdded;

        List<IFigure> GetFigures();

        void AddFigure(IFigure triangle);

        bool RemoveFigure(IFigure triangle);
    }
}