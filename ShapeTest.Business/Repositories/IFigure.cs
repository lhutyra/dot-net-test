namespace ShapeTest.Business.Repositories
{
    public interface IFigure
    {
        string Name { get; set; }
        double GetArea();
    }
}