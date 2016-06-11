using System;
using System.Linq;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Services
{
    public class FiguresComputeAreaService : IComputeAreaService
    {       
        private readonly IFiguresRepository _FiguresesRepo;

        public FiguresComputeAreaService(IFiguresRepository trianglesRepo)
        {
            _FiguresesRepo = trianglesRepo;
        }
        public double ComputeTotalArea()
        {
            var figures = _FiguresesRepo.GetFigures();            
            return figures.Sum(f=>f.GetArea());
        }
    }
}
