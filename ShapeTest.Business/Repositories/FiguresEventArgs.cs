using System;

namespace ShapeTest.Business.Repositories
{
    public class FiguresEventArgs : EventArgs
    {
        public FiguresEventArgs(IFigure figure)
        {
            Figure = figure;
        }
        public IFigure Figure { get; }
    }
}