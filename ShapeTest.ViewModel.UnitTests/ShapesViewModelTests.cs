using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel;
using ShapeTests.ViewModel.Helpers;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class ShapesViewModelTests
    {
        [TestMethod]
        public void ShouldUpdateViewModelOnFiguresChanged()
        {
            // Arrange
            const string expectedName = "NewName";
            const double expectedBase = 42;
            const double expectedHeight = 3.14;

            const double expectedWidth = 5;
            const double expectedLength = 15;

            BaseFigure testFigure = FigureFactory.GetFigure("Triangle") as Triangle;
            ((Triangle)testFigure).Name = expectedName;
            ((Triangle)testFigure).Base = expectedBase;
            ((Triangle)testFigure).Height = expectedHeight;

            BaseViewModel viewModel = new TriangleViewModel();

            // Act
            viewModel.Figure = testFigure;

            // Assert
           ((TriangleViewModel)viewModel).Name.Should().Be(expectedName);
           ((TriangleViewModel)viewModel).Base.Should().Be(expectedBase);
           ((TriangleViewModel)viewModel).Height.Should().Be(expectedHeight);


            testFigure = FigureFactory.GetFigure("Rectangle") as Rectangle;

            // Act
            viewModel.Figure = testFigure;

            ((Rectangle)testFigure).Name = expectedName;
            ((Rectangle)testFigure).Length = expectedWidth;
            ((Rectangle)testFigure).Width = expectedLength;

            // Assert
            ((RectangleViewModel)viewModel).Name.Should().Be(expectedName);
            ((RectangleViewModel)viewModel).Width.Should().Be(expectedWidth);
            ((RectangleViewModel)viewModel).Length.Should().Be(expectedLength);
        }

         

        [TestMethod]
        public void ShouldUpdateSquarePropsWhenViewModelNameChanges()
        {
            // Arrange            
            const string expectedName = "NewName";
            const double expectedSideLenght = 15;            
            var square = FigureFactory.GetFigure("Square") as Square;
            square.Name = expectedName;
            square.SideLength = 10;
            

            SquareViewModel viewModel = new SquareViewModel() { Figure = square };

            // Act
            viewModel.SideLength = expectedSideLenght;
            viewModel.Name = expectedName;
            // Assert
            square.SideLength.Should().Be(expectedSideLenght);
            square.Name.Should().Be(expectedName);
     
        }

        [TestMethod]
        public void ShouldUpdateCirclePropsWhenViewModelNameChanges()
        {
            // Arrange            
            const string expectedName = "New Name";
            const double expectedRadiusLenght = 15;
            var circle = FigureFactory.GetFigure("Circle") as Circle;
            circle.Name = expectedName;
            circle.Radius = 10;


            CircleViewModel viewModel = new CircleViewModel() { Figure = circle };

            // Act
            viewModel.Radius = expectedRadiusLenght;
            viewModel.Name = expectedName;
            // Assert
            circle.Radius.Should().Be(expectedRadiusLenght);
            circle.Name.Should().Be(expectedName);

        }      
    }
}
