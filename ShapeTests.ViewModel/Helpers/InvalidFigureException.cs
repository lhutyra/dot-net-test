using System;

namespace ShapeTests.ViewModel.Helpers
{
    public class InvalidFigureException : Exception
    {
        public InvalidFigureException(string message) : base(message)
        {            
        }
    }
}