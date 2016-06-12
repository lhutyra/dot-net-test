using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IFiguresTypesRepository
    {
        List<FigureType> GetList();
    }
}