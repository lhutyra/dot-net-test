﻿using System.Collections.Generic;
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
        private Mock<ITrianglesRepository> _MockTrianglesRepository;

        [TestInitialize]
        public void Setup()
        {
            _MockTrianglesRepository = _MockRepository.Create<ITrianglesRepository>();
        }

        [TestMethod]
        public void ShouldReturnZeroForNoneFigures()
        {
            List<Triangle> triangles = new List<Triangle>();
                                     

            _MockTrianglesRepository.Setup(m => m.GetTriangles()).Returns(triangles);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockTrianglesRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(0.0, ExpectedPrecision);

            _MockTrianglesRepository.VerifyAll();
        }

        [TestMethod]
        public void ShouldComputeTotalArea()
        {
            // Arrange
            const double expectedResult = 13;

            List<Triangle> triangles = new List<Triangle>
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

            _MockTrianglesRepository.Setup(m => m.GetTriangles()).Returns(triangles);

            ComputeAreaService computeAreaService = new ComputeAreaService(_MockTrianglesRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockTrianglesRepository.VerifyAll();
        }
    }
}
