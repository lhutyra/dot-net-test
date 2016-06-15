using System;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.Helpers
{
    public class FigureFactory
    {
        public static IFigure GetFigure(string figureType)
        {
            IFigure figure = null;
            if (figureType == "Square")
            {
                figure = new ShapeTest.Business.Entities.Square() { Name = "New Square" };
            }
            else if (figureType == "Triangle")
            {
                figure = new Triangle
                {
                    Name = "New Triangle"
                };
            }
            else if (figureType == "Circle")
            {
                figure = new Circle()
                {
                    Name = "New Circle"
                };
            }

            else if (figureType == "Rectangle")
            {
                figure = new Rectangle()
                {
                    Name = "New Rectangle"
                };
            }
            else
            {
                throw new InvalidFigureException("Invalid figure");
            }
            return figure;

        }
    }
}