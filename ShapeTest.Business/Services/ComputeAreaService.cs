using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Services
{
    using System.Linq;

    public class ComputeAreaService : IComputeAreaService
    {
        private readonly IFiguresRepository _FiguresesRepo;

        public ComputeAreaService(IFiguresRepository figuresesRepo)
        {
            _FiguresesRepo = figuresesRepo;
        }

        public double ComputeTotalArea()
        {
            var figures = _FiguresesRepo.GetFigures();
            return figures.Sum(f => f.GetArea());
        }
    }
}
