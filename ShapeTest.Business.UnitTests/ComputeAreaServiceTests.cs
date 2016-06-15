using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTest.Business.UnitTests;

namespace ShapeTest.Business.UnitTest
{
    [TestClass]
    public class ComputeAreaServiceTests : BaseTestClass
    {
        private const double ExpectedPrecision = 0.001;
        
        private Mock<IFiguresRepository> _MockFiguresRepository;

        [TestInitialize]
        public void Setup()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);
            _MockFiguresRepository = _MockRepository.Create<IFiguresRepository>();
        }


        [TestMethod]
        public void ForEmptyListShouldReturnZero()
        {
            // Arrange
            const double expectedResult = 0;

            List<IFigure> figures = new List<IFigure>();

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


        [TestMethod]
        public void ShouldComputeTotalArea()
        {
            // Arrange
            const double expectedResult = 13;

            List<IFigure> triangles = new List<IFigure>
            {
                new Triangle
                    {
                        Base = 2,
                        Height = 4
                    },
                new Triangle
                    {
                        Base = 3,
                        Height = 6
                    }
            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(triangles);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }

        [TestMethod]
        public void CalculateAreaForSinglesSquareFigure()
        {
            // Arrange
            const double expectedResult = 100;
            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            List<IFigure> figures = new List<IFigure>()
            {
                new Square()
                {
                    SideLength = 10
                }
            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);
         
            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


        [TestMethod]
        public void CalculateAreaForSinglesRectangleFigure()
        {
            // Arrange
            const double expectedResult = 250;
            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            List<IFigure> figures = new List<IFigure>()
            {
                new Rectangle()
                {
                    Length = 10,
                    Width = 25
                }
            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


        [TestMethod]
        public void CalculateAreaForSinglesCircleFigure()
        {
            // Arrange
            const double expectedResult = Math.PI * 10 * 10;
            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            List<IFigure> figures = new List<IFigure>()
            {
                new Circle()
                {
                    Radius = 10                    
                }

            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


        [TestMethod]
        public void CalculateAreaForMixedCircleFigures()
        {
            // Arrange
            const double expectedResult = Math.PI * 10 * 10 + 250;
            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            List<IFigure> figures = new List<IFigure>()
            {
                new Circle()
                {
                    Radius = 10
                },
                 new Rectangle()
                {
                    Length = 10,
                    Width = 25
                }

            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


        [TestMethod]
        public void ShouldReturnNaNForIncorrectParameters()
        {
            // Arrange
            const double expectedResult = double.NaN;
            ComputeAreaService computeAreaService = new ComputeAreaService(_MockFiguresRepository.Object);

            List<IFigure> figures = new List<IFigure>()
            {
                new Circle()
                {
                    Radius = -10
                },
                 new Rectangle()
                {
                    Length = 10,
                    Width = 25
                }

            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().Be(expectedResult);

            _MockFiguresRepository.VerifyAll();
        }
    }
}
