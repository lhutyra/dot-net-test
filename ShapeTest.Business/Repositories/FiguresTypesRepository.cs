using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class FiguresTypesRepository : IFiguresTypesRepository
    {
        public List<FigureType> GetList()
        {
            var list = new List<FigureType>()
            {
                new FigureType() {FigureName = "Triangle"},
                new FigureType() {FigureName = "Rectangle"}
            };
            return list;
        }
    }
}