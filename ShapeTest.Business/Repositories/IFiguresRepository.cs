using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IFiguresRepository
    {
        event FigureAddedEventHandler FigureAdded;

        List<FigureBaseEntity> GetFigures();

        void AddFigure(FigureBaseEntity figure);

        bool RemoveFigure(FigureBaseEntity figure);
    }
}