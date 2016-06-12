using System;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class FiguresEventArgs : EventArgs
    {
        public FiguresEventArgs(FigureBaseEntity figure)
        {
            Figure = figure;
        }

        public FigureBaseEntity Figure { get; }
    }
}