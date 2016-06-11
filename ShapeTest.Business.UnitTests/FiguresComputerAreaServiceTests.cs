using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;

namespace ShapeTest.Business.UnitTests
{
    /// <summary>
    /// Summary description for FiguresComputerAreaServiceTests
    /// </summary>
    [TestClass]
    public class FiguresComputerAreaServiceTests : BaseTestClass
    {
        private double ExpectedPrecision = 0;
        private Mock<IFiguresRepository> _MockFiguresRepository;
        [TestInitialize]
        public void Setup()
        {
            _MockFiguresRepository = _MockRepository.Create<IFiguresRepository>();
        }        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ForEmptyListZeroShouldBeReturned()
        {
            // Arrange
            const double expectedResult = 0;

            List<IFigure> figures = new List<IFigure>();
           

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            FiguresComputeAreaService computeAreaService = new FiguresComputeAreaService(_MockFiguresRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }

        [TestMethod]
        public void CalculateAreaForSingleFigure()
        {
            // Arrange
            const double expectedResult = 100;

            List<IFigure> figures = new List<IFigure>()
            {
                new Rectangle()
                {
                    Size = 10
                }
              
            };

            _MockFiguresRepository.Setup(m => m.GetFigures()).Returns(figures);

            FiguresComputeAreaService computeAreaService = new FiguresComputeAreaService(_MockFiguresRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockFiguresRepository.VerifyAll();
        }


       
}

   
}
