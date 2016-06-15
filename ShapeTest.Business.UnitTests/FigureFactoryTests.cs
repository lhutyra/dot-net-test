using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTests.ViewModel.Helpers;

namespace ShapeTest.Business.UnitTests
{
    [TestClass]
    public class FigureFactoryTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        void IsProperTypeReturned()
        {
            Assert.IsTrue(FigureFactory.GetFigure("Rectangle") is Rectangle);
            Assert.IsTrue(FigureFactory.GetFigure("Circle") is Circle);
            Assert.IsTrue(FigureFactory.GetFigure("Triangle") is Triangle);
            Assert.IsTrue(FigureFactory.GetFigure("Square") is Square);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        void IsExceptionThrowIfFigureNotExist()
        {
            FigureFactory.GetFigure(Guid.NewGuid().ToString());
        }
    }
}