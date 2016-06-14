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
        
        private Mock<IFiguresRepository> _MockTFiguresRepository;

        [TestInitialize]
        public void Setup()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);
            _MockTFiguresRepository = _MockRepository.Create<IFiguresRepository>();
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

            _MockTFiguresRepository.Setup(m => m.GetFigures()).Returns(triangles);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockTFiguresRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockTFiguresRepository.VerifyAll();
        }
    }
}
